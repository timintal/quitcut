using Cysharp.Threading.Tasks;
using Libraries.Rewards.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace UIFramework.FlyingRewardsUIFeedback
{
    public interface IRewardIconProvider
    {
        Sprite GetIcon(RewardType type);
    }
    
    public class FlyingRewardsService : ITickable
    {
        private readonly IRewardIconProvider rewardIconProvider;
        private FlyingRewardsUIFeedbackView flyingRewardsUIFeedbackView;
        private readonly Dictionary<RewardType, List<IRewardUIPositionProvider>> positionProviders = new();
        private IRewardUIPositionProvider _defaultPositionProvider;
        private IRewardUIPositionProvider _overridePositionProvider;
        private readonly List<AnimatedUIReward> animatedRewards = new();

        private bool HasDefaultPositionProvider => _defaultPositionProvider != null;
        private bool HasOverridePositionProvider => _overridePositionProvider != null;
        public bool IsAnimatingRewards => animatedRewards.Count > 0;
        
        public FlyingRewardsService(IRewardIconProvider rewardIconProvider)
        {
            this.rewardIconProvider = rewardIconProvider;
        }
        
        public bool HasPositionProvider(RewardType target)
        {
            return positionProviders.ContainsKey(target) && positionProviders[target].Count > 0;
        }

        public void SetView(FlyingRewardsUIFeedbackView flyingRewardsView)
        {
            flyingRewardsUIFeedbackView = flyingRewardsView;
        }

        public void RegisterDefaultPositionProvider(IRewardUIPositionProvider provider)
        {
            if (_defaultPositionProvider != null)
            {
                Debug.LogWarning("Registering an already registered default position provider.");
                return;
            }
            _defaultPositionProvider = provider;
        }
        
        public void UnregisterDefaultPositionProvider(IRewardUIPositionProvider provider)
        {
            if (_defaultPositionProvider != provider)
            {
                Debug.LogWarning($"Attempting to unregister wrong default position provider.");
                return;
            }
            _defaultPositionProvider = null;
        }
        
        public void RegisterOverridePositionProvider(IRewardUIPositionProvider provider)
        {
            Assert.IsNull(_overridePositionProvider);
            _overridePositionProvider = provider;
        }
        
        public void UnregisterOverridePositionProvider(IRewardUIPositionProvider provider)
        {
            Assert.AreEqual(_overridePositionProvider, provider);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            _overridePositionProvider = null;
        }
        
        public void RegisterPositionProvider(IRewardUIPositionProvider provider)
        {
            if (!positionProviders.ContainsKey(provider.RewardType))
            {
                positionProviders[provider.RewardType] = new List<IRewardUIPositionProvider>();
            }
            if (positionProviders[provider.RewardType].Contains(provider))
            {
                positionProviders[provider.RewardType].Remove(provider);
            }
            positionProviders[provider.RewardType].Add(provider);

        }

        public void UnregisterPositionProvider(IRewardUIPositionProvider provider)
        {
            foreach (var positionProvider in positionProviders)
            {
                positionProvider.Value.Remove(provider);
            }
        }

        private bool TryGetCurrentPositionProvider(RewardType rewardType, out IRewardUIPositionProvider provider)
        {
            if(HasOverridePositionProvider)
            {//set override if it exists
                provider = _overridePositionProvider;
                return true;
            }
            
            if (!positionProviders.TryGetValue(rewardType, out var providers) || providers.Count == 0)
            {
                if (HasDefaultPositionProvider)
                {// if we have a default provider, use it
                    provider = _defaultPositionProvider;
                }
                else
                {
                    provider = null;
                    return false;
                }
            }
            else
            {//get the last provider
                provider = providers[^1];
            }
            return true;
        }

        public async UniTask PlayRewardFeedback(FlyingRewardFeedbackData data)
        {
            if (flyingRewardsUIFeedbackView == null)
            {
                Debug.LogError("FlyingRewardsUIFeedbackView is not set");
                return;
            }
            if (!TryGetCurrentPositionProvider(data.Type, out var provider))
            {
                Debug.LogError($"Position provider for {data.Type} not found");
                return;
            }

            int rewardsCount = data.ParticlesCount > 0 ? data.ParticlesCount : 1;
            var defaultSettings = flyingRewardsUIFeedbackView.GetSettings(data.Type);
            int animationPointsCount = data.AnimationPointsCount > 0 ? data.AnimationPointsCount : defaultSettings.AnimationPointsCount;
            var targetPosition = provider.GetRewardTargetPosition();

            await UniTask.Delay(TimeSpan.FromSeconds(data.InitialDelay > 0 ? data.InitialDelay : defaultSettings.InitialDelay));

            for (int i = 0; i < rewardsCount; i++)
            {
                var flyingRewardUI = flyingRewardsUIFeedbackView.GetRewardPrefab(data.StartPosition, data.Type);
                
                data.StartPosition.z = targetPosition.z;
                var sideOffset = data.SideOffsetMultiplier > 0 ? data.SideOffsetMultiplier : defaultSettings.SideOffsetMultiplier;
                var animationPoints = GenerateAnimationPoints(data.StartPosition, targetPosition, animationPointsCount, sideOffset);

                flyingRewardUI.Init(data.Icon == null ? rewardIconProvider.GetIcon(data.Type) : data.Icon, 
                    string.IsNullOrEmpty(data.Label) ? defaultSettings.Label : data.Label);
                
                if (data.IconSize.x < 0 || data.IconSize.y < 0)
                {
                    flyingRewardUI.SetIconSize(defaultSettings.IconSize);
                }
                else
                {
                    flyingRewardUI.SetIconSize(data.IconSize);
                }

                var reward = new AnimatedUIReward
                {
                    Type = data.Type,
                    AnimationTime = data.AnimationTime < 0 ? flyingRewardUI.defaultData.AnimationTime : data.AnimationTime,
                    AnimationPoints = animationPoints,
                    Progress = 0,
                    OnComplete = data.OnComplete,
                    MovementCurve = data.MovementCurve ?? flyingRewardUI.defaultData.MovementCurve,
                    ScaleCurve = data.ScaleCurve ?? flyingRewardUI.defaultData.ScaleCurve,
                    Transform = flyingRewardUI.transform,
                    OrderNumber = i,
                };

                animatedRewards.Add(reward);

                await UniTask.Delay(TimeSpan.FromSeconds(data.SpawnDelay < 0 ? defaultSettings.SpawnDelay : data.SpawnDelay));
            }
        }

        public async UniTaskVoid PlayFloatAndFadeWidget(Vector3 atPosition, Sprite icon, int amount, float duration)
        {
            if (flyingRewardsUIFeedbackView == null)
            {
                Debug.LogError("FlyingRewardsUIFeedbackView is not set");
                return;
            }
            
            var widget = flyingRewardsUIFeedbackView.GetFloatAndFadeWidgetPrefab(atPosition);
            widget.Init(icon, amount);
            widget.PlayAnimation();
            
            await UniTask.Delay(TimeSpan.FromSeconds(duration));
            
            widget.Release();
        }

        private static List<Vector3> GenerateAnimationPoints(
            Vector3 startPosition,
            Vector3 targetPosition,
            int pointsCount,
            float sideOffsetMultiplier)
        {
            ListPool<Vector3>.Get(out var points);

            if (pointsCount == 2)
            {
                points.Add(startPosition);
                points.Add(targetPosition);
                return points;
            }

            var diff = targetPosition - startPosition;

            Vector3 normal = new Vector3(-diff.y, diff.x, 0);

            if (Random.Range(-1f, 1f) > 0)
            {
                normal = -normal;
            }

            if (pointsCount == 3)
            {
                points.Add(startPosition);
                points.Add(startPosition + diff * Random.Range(0.25f, 0.75f) + normal * (Random.Range(0.1f, 0.75f) * sideOffsetMultiplier));
                points.Add(targetPosition);
                return points;
            }

            if (pointsCount == 4)
            {
                float normalMultiplier = Mathf.Sign(Random.Range(-1f, 1f));
                points.Add(startPosition);
                points.Add(startPosition + diff * Random.Range(-0.25f, 0.25f) + normal * (Random.Range(0.1f, 0.5f) * sideOffsetMultiplier));
                points.Add(startPosition + diff * Random.Range(0.75f, 1.25f) + normal * (normalMultiplier * Random.Range(0.1f, 0.5f) * sideOffsetMultiplier));
                points.Add(targetPosition);
                return points;
            }

            Debug.LogError($"Invalid points count: {pointsCount}");
            points.Add(startPosition);
            points.Add(targetPosition);
            return points;
        }

        public void Tick()
        {
            for (int i = animatedRewards.Count - 1; i >= 0; i--)
            {
                var animatedReward = animatedRewards[i];
                animatedReward.Progress += Time.deltaTime / animatedReward.AnimationTime;
                bool providerExists = TryGetCurrentPositionProvider(animatedReward.Type, out var provider);
                
                if (animatedReward.Progress >= 1 ||
                    !providerExists ||
                    animatedReward.CancellationToken.IsCancellationRequested)
                {
                    animatedReward.Transform.GetComponent<FlyingRewardUI>().Release().Forget();
                    ListPool<Vector3>.Release(animatedRewards[i].AnimationPoints);
                    animatedRewards.RemoveAt(i);

                    if (!animatedReward.CancellationToken.IsCancellationRequested)
                    {
                        animatedReward.OnComplete?.Invoke(animatedReward.OrderNumber);
                        if (providerExists && animatedReward.Progress >= 1)
                            provider.OnRewardReachedTarget?.Invoke();
                    }
                }
                else
                {
                    animatedReward.AnimationPoints[^1] = provider.GetRewardTargetPosition();
                    animatedReward.Transform.position =
                        BezierExtensions.GetPoint(animatedReward.AnimationPoints, animatedReward.EvaluateProgress());
                    animatedReward.Transform.localScale = Vector3.one * animatedReward.ScaleCurve.Evaluate(animatedReward.Progress);
                    
                }
            }
        }
        
        public async UniTask WaitForAllRewards()
        {
            while (IsAnimatingRewards)
            {
                await UniTask.Yield();
            }
        }
    }
}