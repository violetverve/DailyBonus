using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using DailyBonus.Inventory;

namespace DailyBonus
{
    [CreateAssetMenu(fileName = "BonusConfigParser", menuName = "DailyBonus/BonusConfigParser")]
    public class BonusConfigParserSO : ScriptableObject
    {
        private const string _filePath = "Assets/DailyBonus/DailyBonusesConfig.json";
        private BonusConfig _bonusesConfig;

        public void LoadBonusesConfig()
        {
            if (File.Exists(_filePath))
            {
                string jsonText = File.ReadAllText(_filePath);
                _bonusesConfig = JsonConvert.DeserializeObject<BonusConfig>(jsonText);

                SetBonusIds();
            }
            else
            {
                Debug.LogError($"The file at {_filePath} does not exist.");
            }
        }

        public List<Bonus> GetBonusList()
        {
            return _bonusesConfig.DailyBonuses;
        }

        private void SetBonusIds()
        {
            foreach (var bonus in _bonusesConfig.DailyBonuses)
            {
                if (Enum.TryParse(bonus.Name, out Item enumValue))
                {
                    bonus.SetItemId(enumValue);
                }
                else
                {
                    Debug.LogWarning($"Failed to parse enum value from string '{bonus.Id}' for bonus.");
                }
            }
        }

    }

}
