using System.Collections.Generic;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using System.Linq;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel
{
    public class FactoryLevelModel : IFactory<LevelModel, LevelInfo, int>
    {
        public LevelModel Create(LevelInfo value, int levelNumber)
        {
            var model = new LevelModel();

            model.LevelNumber = levelNumber;

            model.Words = value.words;
            model.InputChars = BuildListChars(value.words);

            return model;
        }

        private List<char> BuildListChars(List<string> words)
        {
            var levelCharsRepeatMap = new Dictionary<char, int>();

            foreach (var word in words)
            {
                var wordCharsRepeatMap = new Dictionary<char, int>();

                foreach (var letter in word)
                {
                    if (wordCharsRepeatMap.ContainsKey(letter))
                        wordCharsRepeatMap[letter]++;
                    else
                        wordCharsRepeatMap[letter] = 1;
                }

                foreach (var (character, repeatsCount) in wordCharsRepeatMap)
                {
                    if (!levelCharsRepeatMap.ContainsKey(character))
                    {
                        levelCharsRepeatMap[character] = repeatsCount;
                        continue;
                    }

                    if (repeatsCount > levelCharsRepeatMap[character])
                        levelCharsRepeatMap[character] = repeatsCount;
                }
            }

            var charsList = new List<char>();

            foreach (var (character, repeatsCount) in levelCharsRepeatMap)
            {
                charsList.AddRange(Enumerable.Repeat(character, repeatsCount));
            }

            return charsList;
        }
    }
}