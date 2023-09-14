using System;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public class ProviderWordLevel : IProviderWordLevel
    {
        public LevelInfo LoadLevelData(int levelIndex)
        {
            string path = "WordSearch/Levels/" + levelIndex.ToString();

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

            return null;

            //напиши реализацию не меняя сигнатуру функции
            //throw new NotImplementedException();
        }
    }
}