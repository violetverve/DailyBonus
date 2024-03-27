using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DailyBonus.Inventory;

namespace DailyBonus
{
    public class BonusManagerFacade : MonoBehaviour
    {
        public static BonusManagerFacade Instance { get; private set; }

        [SerializeField] private ItemStorage _itemStorage;
        [SerializeField] private BonusConfigParser _bonusConfigParser;
        [SerializeField] private BonusManager _bonusManager;

        private void Awake()
        {
            Instance = this;
        }

        public ItemSO GetItemById(Item id)
        {
            return _itemStorage.GetItemById(id);
        }

        public List<Bonus> GetBonusList()
        {
            return _bonusConfigParser.GetBonusList();
        }

        public int GetStreakDay()
        {
            return _bonusManager.GetStreakDay();
        }

        public bool GetIsClaimed()
        {
            return _bonusManager.GetIsClaimed();
        }
        
        public void ClaimBonus()
        {
            _bonusManager.ClaimBonus();
        }

    }
}