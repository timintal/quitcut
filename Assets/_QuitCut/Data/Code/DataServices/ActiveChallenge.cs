using System;
using R3;

namespace QuitCut.Data.DataServices
{
    [Serializable]
    public class ActiveChallenge
    {
        public SavedChallengeInfo SavedData;
        
        public ReactiveProperty<ChallengeState> State = new(ChallengeState.Active);
        public ReactiveProperty<float> Progress = new(0);
        public ReactiveProperty<float> DailyLimitProgress = new(0);
        public ReactiveProperty<float> TotalLimitProgress = new(0);
    }
}