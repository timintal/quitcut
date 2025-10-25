using Rewards.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Libraries.Rewards.Runtime
{
    [Serializable]
    public partial class RewardType : Enumeration
    {
        private static Dictionary<string, RewardType> rewardTypes = new();
        
        private RewardType(int id, string name) : base(id, name) => rewardTypes[name] = this;

        public static IEnumerable GetAllTypeNames()
        {
            return Enumeration.GetAll<RewardType>().Select(type => type.Name);
        }
        
        public static RewardType GetByName(string rewardName) => rewardTypes[rewardName];
    }
}