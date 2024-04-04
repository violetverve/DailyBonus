using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


namespace DailyBonus
{
    [CreateAssetMenu(fileName = "BonusManager", menuName = "DailyBonus/BonusManager")]
    public class BonusManagerSO : ScriptableObject
    {
        private const string IS_CLAIMED = "IsClaimed";
        private const string STREAK_DAY = "StreakDay";
        private const string LAST_TIME_VISITED = "LastTimeVisited";
        
        [SerializeField] private BonusConfigParserSO _bonusConfigParserSO;

        private int _streakDay;
        private bool _isClaimed;

        private void OnEnable()
        {
            _bonusConfigParserSO.LoadBonusesConfig();
            
            UpdateStreak();

            UpdateClaimed();

            SaveParameters();
        }

        public void UpdateStreak()
        {
            _streakDay = LoadStreakDay();

            if (DayChanged())
            {
                if (StreakBroken())
                {
                    _streakDay = 1;
                }
                else
                {
                    _streakDay++;
                }
            }
        }

        private bool StreakBroken()
        {
            return GetLastTimeVisited().Date != DateTime.Today.AddDays(-1);
        }


        private void UpdateClaimed()
        {
            if (DayChanged())
            {
                _isClaimed = false;
            }
            else
            {
                _isClaimed = LoadClaimed();
            }

        }


        private bool DayChanged()
        {
            DateTime lastTimeVisited = GetLastTimeVisited();
            DateTime currentTime = DateTime.Now;

            return lastTimeVisited.Date != currentTime.Date;
        }

        private int LoadStreakDay()
        {
            return PlayerPrefs.GetInt(STREAK_DAY, 1);
        }

        private bool LoadClaimed()
        {
            return PlayerPrefs.GetInt(IS_CLAIMED, 0) == 1;
        }

        private DateTime GetLastTimeVisited()
        {
            string savedTimeString = PlayerPrefs.GetString(LAST_TIME_VISITED);

            if (DateTime.TryParse(savedTimeString, out DateTime savedTime))
            {
                return savedTime;
            }

            return DateTime.Now;
        }

        private void SaveParameters()
        {
            SaveLastTimeVisited();
            SaveStreakDay();
            SaveClaimed();

            PlayerPrefs.Save();
        }

        private void SaveLastTimeVisited()
        {
            string currentTime = DateTime.Now.ToString();
            PlayerPrefs.SetString(LAST_TIME_VISITED, currentTime);
        }

        private void SaveClaimed()
        {
            PlayerPrefs.SetInt(IS_CLAIMED, _isClaimed ? 1 : 0);
        }

        private void SaveStreakDay()
        {
            PlayerPrefs.SetInt(STREAK_DAY, _streakDay);
        }

        public int GetStreakDay()
        {
            return _streakDay;
        }

        public bool GetIsClaimed()
        {
            return _isClaimed;
        }

        public void ClaimBonus()
        {
            _isClaimed = true;

            SaveClaimed();
        }

    }
}
