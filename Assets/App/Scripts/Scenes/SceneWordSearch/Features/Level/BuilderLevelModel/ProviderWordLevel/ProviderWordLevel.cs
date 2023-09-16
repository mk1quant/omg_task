using System;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public class ProviderWordLevel : IProviderWordLevel
    {
        private const string PATH_LEVELS = "WordSearch/Levels/";

        public LevelInfo LoadLevelData(int levelIndex)
        {
            string path = PATH_LEVELS + levelIndex.ToString();

            var jsonTextFile = Resources.Load<TextAsset>(path);

            if(jsonTextFile != null)
            {
                LevelInfo levelInfo = JsonUtility.FromJson<LevelInfo>(jsonTextFile.ToString());
                return levelInfo;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}