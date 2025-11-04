using System;
using Caramba.PersistentData.Libraries.Caramba.PersistentData;

namespace QuitCut.Data
{
    [Serializable]
    public class PlayerData : PersistentDataBase
    {
        public DateTime JoinDate = DateTime.MinValue;

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