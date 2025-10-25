using Libraries.Rewards.Runtime;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnimatedUIReward
{
    public RewardType Type;
    public float AnimationTime;
        
    public List<Vector3> AnimationPoints;

    public float Progress;
        
    public Action<int> OnComplete;

    public int OrderNumber;
        
    public Transform Transform;
    
    public CancellationToken CancellationToken;
    
    public AnimationCurve MovementCurve;
    public AnimationCurve ScaleCurve;

    public float EvaluateProgress()
    {
        if (MovementCurve == null)
        {
            return Progress;
        }
        return MovementCurve.Evaluate(Progress);
    }
}