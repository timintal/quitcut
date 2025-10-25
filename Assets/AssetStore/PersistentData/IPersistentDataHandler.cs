using Caramba.PersistentData.Libraries.Caramba.PersistentData;

namespace Caramba.PersistentData
{
    public interface IPersistentDataHandler
    {
        public void Save(PersistentDataBase data);
        public void Load<T>(T data) where T : PersistentDataBase;
    }
}