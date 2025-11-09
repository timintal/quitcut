using System;
using UniqueIdentifier;

namespace QuitCut
{
    [Serializable]
    public partial class ChallengeId : UniqueId
    {
        public ChallengeId() : base(LongGuid.None) { }
        public ChallengeId(LongGuid guid) : base(guid) { }

        public ChallengeId(string id) : base(LongGuid.FromBase64String(id)){}
    }
}
