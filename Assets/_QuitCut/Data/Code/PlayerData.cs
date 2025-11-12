using System;
using PersistentData;

namespace QuitCut.Data
{
    [Serializable]
    public class PlayerData : PersistentDataBase
    {
        public DateTime JoinDate = DateTime.MinValue;
        public int UsualCigarettesPerDayCount = 10;
        public float AveragePricePerPack = 4f;

        public override void OnDataLoaded()
        {
            base.OnDataLoaded();
            if (JoinDate == DateTime.MinValue)
            {
                JoinDate = DateTime.UtcNow;
                IsDirty = true;
            }
        }
    }
}