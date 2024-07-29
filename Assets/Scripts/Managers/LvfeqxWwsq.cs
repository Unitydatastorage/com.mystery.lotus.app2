using Content;
using Entities;
using UnityEngine;

namespace Managers
{
    public class LvfeqxWwsq
    {
        private const string PassedLevelsKey = "PassedLevels";
        private const string ScoreKey = "ScoreKey";
        
        private readonly LevelsDatabase _levelsDatabase;

        public int PassedLevels => PlayerPrefs.GetInt(PassedLevelsKey);
        public int LevelsCount => _levelsDatabase.GameFields.Length;

        public int Score
        {
            get => PlayerPrefs.GetInt(ScoreKey);
            set => PlayerPrefs.SetInt(ScoreKey, value);
        }

        public int LastLevelIndex => PlayerPrefs.GetInt(PassedLevelsKey) < _levelsDatabase.GameFields.Length
            ? PlayerPrefs.GetInt(PassedLevelsKey)
            : _levelsDatabase.GameFields.Length - 1;
            
        
        public LvfeqxWwsq(LevelsDatabase levelsDatabase)
        {
            _levelsDatabase = levelsDatabase;

            if (!PlayerPrefs.HasKey(PassedLevelsKey))
            {
                PlayerPrefs.SetInt(PassedLevelsKey, 0);
            }

            if (!PlayerPrefs.HasKey(ScoreKey))
            {
                PlayerPrefs.SetInt(ScoreKey, 0);
            }
        }

        public LongTerm GetLevelData(int index) =>
            _levelsDatabase.GameFields[index];

        public void IncreasePassedLevels(int currentLevel)
        {
            if (currentLevel == PassedLevels)
                PlayerPrefs.SetInt(PassedLevelsKey, PassedLevels + 1);
        }
    }
}