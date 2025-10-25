using System.Collections.Generic;
using System.Linq;
using Caramba.PersistentData.Libraries.Caramba.PersistentData;
using VContainer.Unity;

namespace Caramba.PersistentData
{
    public class DataManager : IInitializable, ITickable
    {
        private readonly List<PersistentDataBase> datas;
        private readonly IPersistentDataHandler dataHandler;

        public IEnumerable<PersistentDataBase> Datas => datas;
        
        public DataManager(IEnumerable<PersistentDataBase> datas, IPersistentDataHandler dataHandler)
        {
            this.datas = datas.ToList();
            this.dataHandler = dataHandler;
        }
        
        public T GetData<T>() where T : PersistentDataBase => datas.OfType<T>().FirstOrDefault();

        public void Initialize()
        {
            foreach (var dataBase in datas)
            {
                dataHandler.Load(dataBase);
                dataBase.IsDirty = false;
                dataBase.OnDataLoaded();
            }
        }
        
        public void AddData(PersistentDataBase data)
        {
            datas.Add(data);
            dataHandler.Load(data);
            data.IsDirty = false;
            data.OnDataLoaded();
        }

        public void Tick()
        {
            foreach (var dataBase in datas)
            {
                if (dataBase.IsDirty)
                {
                    dataHandler.Save(dataBase);
                }
            }
        }
    }
}