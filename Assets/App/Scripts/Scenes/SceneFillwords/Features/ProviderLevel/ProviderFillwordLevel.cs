using System;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        private const string PATH_WORDS_LIST = "Fillwords/words_list";
        private const string PATH_PACK = "Fillwords/pack_0";

        private string[] wordsList;
        private string[] pack;

        public ProviderFillwordLevel()
        {
            wordsList = Resources.Load<TextAsset>(PATH_WORDS_LIST).text.Split('\r')
            .Select(line => line.Trim()).ToArray();

            pack = Resources.Load<TextAsset>(PATH_PACK).text.Split('\r')
            .Select(line => line.Trim()).ToArray();
        }

        public GridFillWords LoadModel(int index)
        {
            int levelIndex = index - 1;

            for (int i = levelIndex; i < pack.Length; i++)
            {
                var level = LoadLevel(i);

                if (level != null)
                    return level;
            }

            throw new Exception("No valid level found");
        }

        private GridFillWords LoadLevel(int index)
        {
            try
            {
                string[] levelLogic = pack[index].Split(' ');
                int wordsCount = levelLogic.Length / 2;

                string[] words = new string[wordsCount];
                string[] letterArrang = new string[wordsCount];

                for (int i = 0, j = 0; i < levelLogic.Length; i = i + 2, j++)
                {
                    words[j] = wordsList[Convert.ToInt32(levelLogic[i])];
                    letterArrang[j] = levelLogic[i + 1];
                }

                int size = GetSize(words);

                char[] fillWord = FillWord(size, letterArrang, words);

                return CreateGrid(size, fillWord);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return null;
            }
        }

        private int GetSize(string[] words)
        {
            int wordsLength = words.Sum(word => word.Length);
            int size = (int)Math.Ceiling(Math.Sqrt(wordsLength));

            if (size * size == wordsLength)
            {
                return size;
            }
            else
            {
                throw new Exception("No valid size");
            }   
        }

        private char[] FillWord(int size, string[] letterArrang, string[] words)
        {
            char[] fillWord = new char[size * size];

            for (int i = 0; i < letterArrang.Length; i++)
            {
                string[] positions = letterArrang[i].Split(";");

                if(positions.Distinct().Count() != positions.Length)
                {
                    throw new Exception("Found repetitive position");
                }

                if (positions.Any(position => Convert.ToInt32(position) < 0 || Convert.ToInt32(position) >= size * size))
                {
                    throw new Exception("Invalid position");
                }

                string word = words[i];

                if(word.Length != positions.Length)
                {
                    throw new Exception("Invalid positions count");
                }

                for (int j = 0; j < word.Length; j++)
                {
                    int position = Convert.ToInt32(positions[j]);
                    fillWord[position] = word[j];
                }
            }

            return fillWord;
        }

        private GridFillWords CreateGrid(int size, char[] letters)
        {
            GridFillWords gridFillWords = new GridFillWords(new Vector2Int(size, size));

            for (int i = 0, letterIndex = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++, letterIndex++)
                {
                    gridFillWords.Set(i, j, new CharGridModel(letters[letterIndex]));
                }
            }

            return gridFillWords;
        }
    }
}