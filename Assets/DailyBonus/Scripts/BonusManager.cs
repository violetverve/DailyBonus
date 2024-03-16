using System.Collections.Generic;
using UnityEngine;
using System;

public class BonusManager : MonoBehaviour {

    [SerializeField] List<ItemSO> ItemSOs;
    private List<Bonus> DailyBonuses;
    private int streakDay = 0;
    private bool claimed = false;
    
    private void Awake() {
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
        DateTime currentTime = DateTime.Now;
        streakDay = LoadStreakDay();

        if (lastTimeVisited.Date < currentTime.Date) {
            if (lastTimeVisited.Date != DateTime.Today.AddDays(-1)) {
                streakDay = 0;
            } else {
                streakDay++;
            }
        }

        if (lastTimeVisited.Date != currentTime.Date) {
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

        return DateTime.Now;
    }

    private void SaveParameters() {
        SaveLastTimeVisited();
        SaveStreakDay();

        PlayerPrefs.Save();
    }

    private void SaveLastTimeVisited() {
        string currentTime = DateTime.Now.ToString();
        PlayerPrefs.SetString("LastTimeVisited", currentTime);
    }

    private void SaveStreakDay() {
        PlayerPrefs.SetInt("StreakDay", streakDay);
    }

    public List<Bonus> GetDailyBonuses() {
        return DailyBonuses;
    }

    public ItemSO GetBonusItem(string reference) {
        foreach (ItemSO item in ItemSOs) {
            if (item.name == reference) {
                return item;
            }
        }

        return null;
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
