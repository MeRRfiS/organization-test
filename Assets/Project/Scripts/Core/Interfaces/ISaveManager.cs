using Assets.Project.Scripts.Core.Data;

namespace Assets.Project.Scripts.Core.Interfaces
{
    public interface ISaveManager
    {
        public void SaveToFile(string fileName, object objectToWrite);
        public void LoadDataFromFile(string fileName, object objectToOverwrite);
    }
}