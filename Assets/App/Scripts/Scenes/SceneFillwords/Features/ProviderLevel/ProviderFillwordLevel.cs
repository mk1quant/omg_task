using System;
using System.IO;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        //public GridFillWords LoadModel(int index)
        //{
        //    var _levelsData ??= CacheLevelData();

        //    int levelIndex = index - 1;

        //    for(int i = levelIndex; i < _levelData.Lenght; i++)
        //    {
        //        var level = LoadLevel(i);

        //        if (level != null)
        //            return level;
        //    }

        //    throw new Exception();
        //}

        //private char[] CacheLevelData()
        //{
        //    return null;
        //}

        //private void LoadLevel(int i)
        //{

        //}

        public GridFillWords LoadModel(int index)
        {
            int levelIndex = index - 1;

            //string pathToPack = "Assets/App/Resources/Fillwords/pack_0.txt";
            //string pathToWordsList = "Assets/App/Resources/Fillwords/words_list.txt";

            //string[] levels = File.ReadAllLines(pathToPack);
            //string[] words = File.ReadAllLines(pathToWordsList);
            string[] wordsList = Resources.Load<TextAsset>("Fillwords/words_list").text.Split('\r');
            string[] pack = Resources.Load<TextAsset>("Fillwords/pack_0").text.Split('\r');

            for (int i = 0; i < wordsList.Length; i++)
            {
                wordsList[i] = wordsList[i].Trim();
            }
            for (int i = 0; i < pack.Length; i++)
            {
                pack[i] = pack[i].Trim();
            }


            for(int i = levelIndex; i < pack.Length; i++)
            {
                var level = LoadLevel(i, wordsList, pack);

                if (level != null)
                    return level;
            }
            throw new Exception();
            return null;

            //return LoadLevel(levelIndex, wordsList, pack);

            ////напиши реализацию не меняя сигнатуру функции
            //throw new NotImplementedException();
        }

        private GridFillWords LoadLevel(int index, string[] wordsList, string[] pack)
        {
            try
            {


                int size;

                string[] levelLogic = pack[index].Split(' ');
                int wordsCount = levelLogic.Length / 2;

                string[] words = new string[wordsCount]; // массив со словами
                string[] letterArrang = new string[wordsCount]; // массив с расстановками слов

                for (int i = 0, j = 0; i < levelLogic.Length; i = i + 2, j++)
                {
                    words[j] = wordsList[Convert.ToInt32(levelLogic[i])];
                    letterArrang[j] = levelLogic[i + 1];
                }

                foreach (var w in words)
                    Debug.Log("Words: " + w + ", " + w.Length);
                foreach (var w in letterArrang)
                    Debug.Log("Letter arrang: " + w + ", " + w.Length);


                size = GetSize(words);

                char[] fillWord = FillWord(size, letterArrang, words);

                return CreateGrid(size, fillWord);
            }
            catch { return null; }
        }

        private int GetSize(string[] words)
        {
            int wordsLenght = 0;
            foreach (var word in words)
                wordsLenght += word.Length;
            
            int size = (int)Math.Sqrt(wordsLenght);

            if ((size * size) == wordsLenght)
                return size;
            else
            {
                throw new Exception("Wrong size");
                return 0;
            }     
        }

        private char[] FillWord(int size, string[] letterArrang, string[] words)
        {
            char[] fillWord = new char[size * size];

            for (int i = 0; i < letterArrang.Length; i++)
            {
                string[] pos = letterArrang[i].Split(";");
                string word = words[i];

                for (int j = 0; j < word.Length; j++)
                {
                    int position = Convert.ToInt32(pos[j]);

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