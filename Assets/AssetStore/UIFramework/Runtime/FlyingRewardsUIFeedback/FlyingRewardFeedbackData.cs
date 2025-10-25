using Libraries.Rewards.Runtime;
using System;
using UnityEngine;

[Serializable]
public class FlyingRewardFeedbackData
{
    [HideInInspector]
    public RewardType Type;
    public Sprite Icon = null;
    public Vector2 IconSize = new Vector2(-1, -1);
    public string Label = string.Empty;
    [HideInInspector]
    public int ParticlesCount = -1;
    public float AnimationTime = -1;
    public float SpawnDelay = -1;
    public float InitialDelay = -1;
    [HideInInspector]
    public Vector3 StartPosition;
    public Action<int> OnComplete = null;
    public int AnimationPointsCount = -1;
    public float SideOffsetMultiplier = -1;

    public AnimationCurve MovementCurve = null;
    public AnimationCurve ScaleCurve = null;
    
    public static FlyingRewardFeedbackData FromData(FlyingRewardFeedbackData data)
    {
        FlyingRewardFeedbackData newData = new FlyingRewardFeedbackData();
        newData.Type = data.Type;
        newData.Icon = data.Icon;
        newData.IconSize = data.IconSize;
        newData.Label = data.Label;
        newData.ParticlesCount = data.ParticlesCount;
        newData.AnimationTime = data.AnimationTime;
        newData.SpawnDelay = data.SpawnDelay;
        newData.InitialDelay = data.InitialDelay;
        newData.StartPosition = data.StartPosition;
        newData.OnComplete = data.OnComplete;
        newData.AnimationPointsCount = data.AnimationPointsCount;
        newData.SideOffsetMultiplier = data.SideOffsetMultiplier;
        newData.MovementCurve = data.MovementCurve;
        newData.ScaleCurve = data.ScaleCurve;
        return newData;
    }
}