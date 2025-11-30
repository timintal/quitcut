using System;

namespace QuitCut.Data.DataServices
{
    [Serializable]
    public class SavedChallengeInfo
    {
        public int Id;
        public ChallengeId ChallengeId;
        public DateTime StartDate;
        public DateTime EndDate;
        public ChallengeState State;
    }
}