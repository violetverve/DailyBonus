using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class BonusManager : MonoBehaviour
{
    private const string IS_CLAIMED = "IsClaimed";
    private const string STREAK_DAY = "StreakDay";
    private const string LAST_TIME_VISITED = "LastTimeVisited";

    private int _streakDay = 0;
    private bool _claimed = false;

    private void Awake()
    {
        CheckStreak();

        CheckClaimed();

        SaveParameters();
    }

    public void CheckStreak()
    {
        DateTime lastTimeVisited = GetLastTimeVisited();
        DateTime currentTime = DateTime.Now;
        _streakDay = LoadStreakDay();

        if (lastTimeVisited.Date < currentTime.Date)
        {
            if (lastTimeVisited.Date != DateTime.Today.AddDays(-1))
            {
                _streakDay = 0;
            }
            else
            {
                _streakDay++;
            }
        }

        if (lastTimeVisited.Date != currentTime.Date) {
            _claimed = false;
        } else {
            _claimed = PlayerPrefs.GetInt(IS_CLAIMED, 0) == 1;
        }
    }

    private void CheckClaimed()
    {
        _claimed = PlayerPrefs.GetInt(IS_CLAIMED, 0) == 1;
    }

    private int LoadStreakDay()
    {
        return PlayerPrefs.GetInt(STREAK_DAY, -1);
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

        PlayerPrefs.Save();
    }

    private void SaveLastTimeVisited()
    {
        string currentTime = DateTime.Now.ToString();
        PlayerPrefs.SetString(LAST_TIME_VISITED, currentTime);
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
        return _claimed;
    }

    public void ClaimBonus()
    {
        _claimed = true;

        PlayerPrefs.SetInt(IS_CLAIMED, _claimed ? 1 : 0);
    }

}
