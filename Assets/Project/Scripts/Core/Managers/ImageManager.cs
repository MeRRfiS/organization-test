using Assets.Project.Scripts.Core.Interfaces;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Core.Managers
{
    public class ImageManager : IImageManager
    {
        private byte[] _imageData;

        public async Task<Sprite> LoadImage(string path)
        {
            _imageData = await File.ReadAllBytesAsync(path);
            Texture2D texture = new Texture2D(256, 256);
            texture.LoadImage(_imageData);

            var sprite = Sprite.Create(texture, 
                                       new Rect(0, 0, texture.width, texture.height), 
                                       new Vector2(0.5f, 0.5f));

            return sprite;
        }

        public async Task<Sprite> LoadImageFronProject(string imageName)
        {
            string path = Path.Combine(Application.persistentDataPath, imageName);
            var sprite = await LoadImage(path);

            return sprite;
        }

        public async void SaveImageToProject(string imageName)
        {
            string path = Path.Combine(Application.persistentDataPath, imageName);
            await File.WriteAllBytesAsync(path, _imageData);
        }
    }
}