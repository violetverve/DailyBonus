using System.Collections.Generic;
using UnityEngine;
using System;

public class BonusManager : MonoBehaviour {

    public static BonusManager Instance { get; private set; }

    private List<Bonus> DailyBonuses;
    private int streakDay = 0;
    private bool claimed = false;
    
    private void Awake() {
        Instance = this;

        LoadBonuses();

        CheckStreak();
    }


    private void LoadBonuses() {
        DailyBonuses = BonusConfigParser.LoadBonusesConfig();

        foreach (Bonus bonus in DailyBonuses) {
            bonus.bonusItem = GetBonusItem(bonus.reference);
        }
    }

    public void CheckStreak() {
        DateTime lastTimeVisited = GetLastTimeVisited();
        DateTime currentTime = DateTime.UtcNow;
        streakDay = LoadStreakDay();
        
        TimeSpan difference = currentTime - lastTimeVisited;

        int daysDifference = difference.Days;

        if (daysDifference > 1) {
            streakDay = 0;
        } else if (daysDifference == 1) {
            streakDay++;
        }

        if (daysDifference != 0) {
            claimed = false;
        } else {
            claimed = PlayerPrefs.GetInt("IsClaimed", 0) == 1;
        }

        SaveParameters();
    }


    private int LoadStreakDay() {
        return PlayerPrefs.GetInt("StreakDay", -1);
    }

    private DateTime GetLastTimeVisited() {
        string savedTimeString = PlayerPrefs.GetString("LastTimeVisited");

        if (DateTime.TryParse(savedTimeString, out DateTime savedTime)) {
            return savedTime;
        }

        return DateTime.UtcNow;
    }

    private void SaveParameters() {
        SaveLastTimeVisited();
        SaveStreakDay();

        PlayerPrefs.Save();
    }

    private void SaveLastTimeVisited() {
        string currentTime = DateTime.UtcNow.ToString();
        PlayerPrefs.SetString("LastTimeVisited", currentTime);
    }

    private void SaveStreakDay() {
        PlayerPrefs.SetInt("StreakDay", streakDay);
    }

    public List<Bonus> GetDailyBonuses() {
        return DailyBonuses;
    }

    public ItemSO GetBonusItem(string reference) {
        return Resources.Load<ItemSO>($"ScriptableObjects/{reference}");
    }

    public int GetStreakDay() {
        return streakDay;
    }

    public Bonus GetCurrentBonus() {
        return DailyBonuses[streakDay];
    }

    public bool IsClaimed() {
        return claimed;
    }

    public void ClaimBonus() {
        claimed = true;

        PlayerPrefs.SetInt("IsClaimed", claimed? 1 : 0);
    }
   
}
