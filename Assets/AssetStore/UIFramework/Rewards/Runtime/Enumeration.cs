using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Rewards.Runtime
{
    public abstract class Enumeration : IComparable, IEquatable<Enumeration>
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public int Id { get; private set; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        [JsonConstructor]
        protected Enumeration()
        {
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                    BindingFlags.Static |
                    BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public bool Equals(Enumeration other) => Name == other.Name && Id == other.Id;

        public override int GetHashCode() => HashCode.Combine(Name, Id);

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
    }
    
}