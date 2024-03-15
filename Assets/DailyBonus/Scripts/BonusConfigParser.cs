using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;


public static class BonusConfigParser {

    private static BonusConfig bonusesConfig;
    private static string filePath = Path.Combine(Application.dataPath, "Resources/DailyBonusesConfig.json");

    public static List<Bonus> LoadBonusesConfig()
    {
        if (File.Exists(filePath)) {
            string jsonText = File.ReadAllText(filePath);
            bonusesConfig = JsonUtility.FromJson<BonusConfig>(jsonText);
        }
        else {
            Debug.LogError($"The file at {filePath} does not exist.");
            return new List<Bonus>();
        }

        return bonusesConfig.dailyBonuses;
    }
}
