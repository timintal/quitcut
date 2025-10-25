using Libraries.Rewards.Runtime;
using System;
using UnityEngine;

public interface IRewardUIPositionProvider
{
    RewardType RewardType { get; }
    Vector3 GetRewardTargetPosition();
    Action OnRewardReachedTarget { get; }
}