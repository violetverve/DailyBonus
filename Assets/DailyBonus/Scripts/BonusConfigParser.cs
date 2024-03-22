using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class BonusConfigParser: MonoBehaviour
{
    private const string _pathString = "Resources/DailyBonusesConfig.json";
    private BonusConfig _bonusesConfig;
    private string _filePath = Path.Combine(Application.dataPath, _pathString);

    private void Awake()
    {
        LoadBonusesConfig();
    }

    public List<Bonus> LoadBonusesConfig()
    {
        if (File.Exists(_filePath))
        {
            string jsonText = File.ReadAllText(_filePath);
            _bonusesConfig = JsonConvert.DeserializeObject<BonusConfig>(jsonText);
        }
        else
        {
            Debug.LogError($"The file at {_filePath} does not exist.");
            return new List<Bonus>();
        }

        return _bonusesConfig.DailyBonuses;
    }

    public List<Bonus> GetBonusList()
    {
        return _bonusesConfig.DailyBonuses;
    }
}


