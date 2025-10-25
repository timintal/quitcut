using System;
using Caramba.PersistentData.Libraries.Caramba.PersistentData;
using Newtonsoft.Json;
using UnityEngine;

namespace Caramba.PersistentData
{
    public class PlayerPrefsDataHandler : IPersistentDataHandler
    {
        public void Save(PersistentDataBase data)
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(data.DataId, json);
            PlayerPrefs.SetInt(data.DataId + "_version", data.Version);
            PlayerPrefs.Save();
            data.IsDirty = false;
        }

        public void Load<T>(T data) where T : PersistentDataBase
        {
            if (PlayerPrefs.HasKey(data.DataId))
            {
                if (PlayerPrefs.GetInt(data.DataId + "_version") == data.Version)
                {
                    string json = PlayerPrefs.GetString(data.DataId);
                    try
                    {
                        var settings = new JsonSerializerSettings
                        {
                            ObjectCreationHandling = ObjectCreationHandling.Replace
                        };
                        JsonConvert.PopulateObject(json, data, settings);
                    }
                    catch (Exception exception)
                    {
                        Debug.LogError($"Failed to deserialize {data.DataId}: {exception.Message})");
                    }
                }
                else
                {
                    Debug.LogWarning($"Version mismatch for {data.DataId}. Expected version {data.Version}, but found version {PlayerPrefs.GetInt(data.DataId + "_version")}");
                }
                
                
            }
        }
    }
}