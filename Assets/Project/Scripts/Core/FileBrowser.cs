using SFB;
using UnityEngine;

namespace Assets.Project.Scripts.Core
{
    public static class FileBrowser
    {
        public static string GetPathToImage()
        {
            var extensions = new[] { new ExtensionFilter("Image Files", "png", "jpg", "jpeg") };

            string[] paths = StandaloneFileBrowser.OpenFilePanel("Select Image", "", extensions, false);

            if (paths.Length == 0 || string.IsNullOrEmpty(paths[0]))
            {
                Debug.LogWarning("No file selected.");
                return null;
            }

            return paths[0];
        }
    }
}