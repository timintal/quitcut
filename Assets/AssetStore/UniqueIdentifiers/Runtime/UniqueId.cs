using Newtonsoft.Json;
using System;
using UnityEngine;

namespace UniqueIdentifier
{
    [Serializable, JsonConverter(typeof(UniqueIdJsonConverter))]
    public abstract class UniqueId : IEquatable<UniqueId>
    {
        [field: SerializeField] 
        public LongGuid Guid { get; private set; }
        
        protected UniqueId(LongGuid guid) => Guid = guid;

        protected UniqueId(UniqueId otherId) : this(otherId.Guid) { }

        public static readonly UniqueId None = new NoneUniqueId();

        public bool Equals(UniqueId obj) => obj != null && Guid.Equals(obj.Guid);
        
        public override int GetHashCode() => Guid.GetHashCode();

        public override bool Equals(object obj) => obj is UniqueId other && Equals(other);
        
        public override string ToString() => Guid.ToString();
        
        public static bool operator ==(UniqueId left, UniqueId right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(UniqueId left, UniqueId right) => !(left == right);
    }
}