using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public static class SceneManager
    {
        public static Scene ActiveScene { get => activeScene; }
        private static Scene activeScene;

        public static void LoadMap(string map)
        {
            var mapData = Assets.ContentManager.Load<Map>(map);

            LoadScene(new MapScene(mapData));
        }

        public static void LoadScene(Scene scene)
        {
            if(ActiveScene != null)
                ActiveScene.End();
            
            activeScene = null;

            scene.Start();
            activeScene = scene;
        }
    }
}
