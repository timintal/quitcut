using System;
using Newtonsoft.Json;

namespace Caramba.PersistentData.Libraries.Caramba.PersistentData
{
    public abstract class PersistentDataBase : IDisposable
    {
        [JsonIgnore]
        public bool IsDirty { get; set; }
        [JsonProperty]
        public virtual string DataId => GetType().Name;
        [JsonIgnore]
        public virtual int Version => 1;

        public virtual void OnDataLoaded(){}

        protected IDisposable disposable;
        
        public void Dispose()
        {
            disposable?.Dispose();
            disposable = null;
        }
    }
}