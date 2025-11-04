// Copied from: https://github.com/brunomikoski/ScriptableObjectCollection/blob/master/Scripts/Runtime/Core/LongGuid.cs

using System;
using UnityEngine;

namespace UniqueIdentifier
{
    [Serializable]
    public struct LongGuid : IEquatable<LongGuid>
    {
        [SerializeField] private long value1;
        [SerializeField] private long value2;
        
        public static readonly LongGuid None = new(0, 0);

        public LongGuid(long guidValue1, long guidValue2)
        {
            value1 = guidValue1;
            value2 = guidValue2;
        }

        public static LongGuid NewGuid()
        {
            var guid = Guid.NewGuid();
            var guidBytes = guid.ToByteArray();
            var guidValue1 = BitConverter.ToInt64(guidBytes, 0);
            var guidValue2 = BitConverter.ToInt64(guidBytes, 8);

            return new LongGuid(guidValue1, guidValue2);
        }

        public (long, long) GetRawValues() => (value1, value2);

        public bool IsValid() => value1 != 0 || value2 != 0;

        public override string ToString() => value1.ToString("X16") + value2.ToString("X16");

        public override bool Equals(object obj)
        {
            if (obj is LongGuid other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(LongGuid other) => value1 == other.value1 && value2 == other.value2;

        public override int GetHashCode() => HashCode.Combine(value1, value2);

        public static bool operator ==(LongGuid left, LongGuid right) => left.Equals(right);

        public static bool operator !=(LongGuid left, LongGuid right) => !(left == right);

        public byte[] ToByteArray()
        {
            var byteArray = new byte[16];
            BitConverter.GetBytes(value1).CopyTo(byteArray, 0);
            BitConverter.GetBytes(value2).CopyTo(byteArray, 8);
            return byteArray;
        }
        
        public static LongGuid FromByteArray(byte[] byteArray)
        {
            if (byteArray.Length != 16)
            {
                throw new ArgumentException("Invalid byte array length. Expected 16 bytes.");
            }

            var guidValue1 = BitConverter.ToInt64(byteArray, 0);
            var guidValue2 = BitConverter.ToInt64(byteArray, 8);

            return new LongGuid(guidValue1, guidValue2);
        }
        
        public string ToBase64String() => Convert.ToBase64String(ToByteArray());

        public static LongGuid FromBase64String(string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            return FromByteArray(byteArray);
        }
    }
}
