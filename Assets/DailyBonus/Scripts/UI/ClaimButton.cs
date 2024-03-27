using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DailyBonus.UI
{
    public class ClaimButton : MonoBehaviour
    {  
        [SerializeField] private BonusManagerFacadeSO _bonusManagerFacadeSO;
        [SerializeField] private DailyBonusWindow _dailyBonusWindow;
        [SerializeField] private Button _claimButton;

        private void Start()
        {
            if (_bonusManagerFacadeSO.GetIsClaimed()) {
                SetInteractable(false);
            }
        }
        
        public void ClaimBonus()
        {
            _dailyBonusWindow.ClaimCurrentCard();
            SetInteractable(false);
            _bonusManagerFacadeSO.ClaimBonus();
        }

        public void SetInteractable(bool value)
        {
            _claimButton.interactable = value;
        }
    }
}