using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Interfaces
{
    public interface IImageManager
    {
        public Task<Sprite> LoadImage(string path);
        public Task<Sprite> LoadImageFromProject(string imageName);
        public void SaveImageToProject(string imageName);
    }
}
