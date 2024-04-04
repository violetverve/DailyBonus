using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

namespace DailyBonus.UI
{
    public class DailyBonusWindowUI : MonoBehaviour
    {
        [SerializeField] BonusManagerFacadeSO _bonusManagerFacadeSO;
        [SerializeField] BonusCardPoolUI _bonusCardPoolUI;
        private int _streakCardIndex;
        private BonusCardUI _currentCard;


        private void Start()
        {   
            _streakCardIndex = _bonusManagerFacadeSO.GetStreakDay() - 1;

            SetCards();
        }

        private void SetCards() 
        {
            foreach (var bonus in _bonusManagerFacadeSO.GetBonusList())
            {
                BonusCardUI bonusCardUI = _bonusCardPoolUI.GetCard();
                bonusCardUI.SetCard(bonus);
                bonusCardUI.SetActive(true);

                SetCardStatus(bonusCardUI);
            }
        }

        private void SetCardStatus(BonusCardUI bonusCardUI)
        {

            if (_bonusCardPoolUI.CountActive - 1 < _streakCardIndex)
            {
                bonusCardUI.SetClaimed();
            }
            else if (_bonusCardPoolUI.CountActive - 1 == _streakCardIndex)
            {
                bonusCardUI.SetCurrent();
                _currentCard = bonusCardUI;

                if (_bonusManagerFacadeSO.GetIsClaimed())
                {
                    ClaimCurrentCard();
                }
            }
        }

        public void ClaimCurrentCard()
        {
            _currentCard.SetClaimed();
            _currentCard.SetCurrentClaimed();
        }
         
    }
}
