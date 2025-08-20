using Assets.Project.Scripts.Core.Data;
using Assets.Project.Scripts.Core.Interfaces;
using System.IO;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Managers
{
    public class SaveManager : ISaveManager
    {
        public void SaveToFile(string fileName, object objectToWrite)
        {
            var filePath = Path.Combine(Application.persistentDataPath, fileName);

            var json = JsonUtility.ToJson(objectToWrite);
            Debug.Log($"{json}");

            using (var file = File.Open(filePath, FileMode.OpenOrCreate))
            {
                file.Dispose();
                File.WriteAllText(filePath, json);
            }
        }

        public void LoadDataFromFile(string fileName, object objectToOverwrite)
        {
            var filePath = Path.Combine(Application.persistentDataPath, fileName);
            Debug.Log($"filePath \"{filePath}\"");

            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"File \"{filePath}\" not found!");
                return;
            }
            FileStream file = File.Open(filePath, FileMode.Open);

            file.Dispose();
            var json = File.ReadAllText(filePath);
            Debug.Log($"{json}");
            JsonUtility.FromJsonOverwrite(json, objectToOverwrite);
        }
    }
}