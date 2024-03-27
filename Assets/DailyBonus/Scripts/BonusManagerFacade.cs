using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DailyBonus.Inventory;

namespace DailyBonus
{
    [CreateAssetMenu(fileName = "BonusManagerFacade", menuName = "DailyBonus/BonusManagerFacade")]
    public class BonusManagerFacadeSO : ScriptableObject
    {
        [SerializeField] private ItemStorageSO _itemStorageSO;
        [SerializeField] private BonusConfigParserSO _bonusConfigParserSO;
        [SerializeField] private BonusManagerSO _bonusManagerSO;

        public ItemSO GetItemById(Item id)
        {
            return _itemStorageSO.GetItemById(id);
        }

        public IEnumerable<Bonus> GetBonusList()
        {
            foreach (var bonus in _bonusConfigParserSO.GetBonusList())
            {
                yield return bonus;
            }
        }

        public int GetStreakDay()
        {
            return _bonusManagerSO.GetStreakDay();
        }

        public bool GetIsClaimed()
        {
            return _bonusManagerSO.GetIsClaimed();
        }
        
        public void ClaimBonus()
        {
            _bonusManagerSO.ClaimBonus();
        }

    }
}