using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Interfaces
{
    public interface IImageManager
    {
        public Task<Sprite> LoadImage(string path);
        public Task<Sprite> LoadImageFronProject(string imageName);
        public void SaveImageToProject(string imageName);
    }
}
