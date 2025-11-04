using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UniqueIdentifier.Editor
{
    public static class IdClassValidator
    {
        public static void Validate()
        {
            var derivedTypes = TypeUtils.GetDerivedTypesFrom<UniqueId>();
            foreach (var carambaIdType in derivedTypes)
            {
                // Check if the class is marked as serializable
                if (!carambaIdType.IsDefined(typeof(SerializableAttribute), false))
                {
                    throw new InvalidOperationException($"Class {carambaIdType.Name} must be marked as [Serializable].");
                }
                
                // Check if the class is declared as partial
                if (!IsPartialClass(carambaIdType))
                {
                    throw new InvalidOperationException($"Class {carambaIdType.Name} must be declared as partial.");
                }
            }
        }
        
        /// <summary>
        /// Partial classes appear multiple times in metadata if defined in separate files
        /// This method assumes partial class detection via multiple TypeDefinition entries
        ///
        /// WARNING: Nested classes inside partial classes may hint at partial usage
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsPartialClass(Type type) => type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), false).Any() || type.DeclaringType != null; 
    }
}