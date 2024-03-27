using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

namespace DailyBonus.UI
{
    public class DailyBonusWindow : MonoBehaviour
    {
        [SerializeField] BonusCardPool _bonusCardPool;
        private int _streakCardIndex;
        private BonusCardUI _currentCard;


        private void Start()
        {   
            _streakCardIndex = BonusManagerFacade.Instance.GetStreakDay() - 1;

            SetCards();
        }

        private void SetCards() 
        {
            foreach (var bonus in BonusManagerFacade.Instance.GetBonusList())
            {
                BonusCardUI bonusCardUI = _bonusCardPool.GetCard();
                bonusCardUI.SetCard(bonus);
                bonusCardUI.SetActive(true);

                SetCardStatus(bonusCardUI);
            }
        }

        private void SetCardStatus(BonusCardUI bonusCardUI)
        {

            if (_bonusCardPool.CountActive - 1 < _streakCardIndex)
            {
                bonusCardUI.SetClaimed();
            }
            else if (_bonusCardPool.CountActive - 1 == _streakCardIndex)
            {
                bonusCardUI.SetCurrent();
                _currentCard = bonusCardUI;

                if (BonusManagerFacade.Instance.GetIsClaimed())
                {
                    ClaimCurrentCard();
                }
            }
        }

        public void ClaimCurrentCard()
        {
            _currentCard.SetClaimed();
        }
         
    }
}
