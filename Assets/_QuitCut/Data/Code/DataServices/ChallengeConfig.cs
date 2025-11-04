using System;
using UniqueIdentifier;

namespace QuitCut.Data.DataServices
{
    [Serializable]
    public class ChallengeConfig
    {
        public UniqueId Id;
        public string Name;
        public int Level;
        public int DurationDays;
        public int PerDayLimit;
        public int TotalLimit;
    }
}