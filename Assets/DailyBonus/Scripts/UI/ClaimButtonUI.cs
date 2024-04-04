using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DailyBonus.UI
{
    public class ClaimButtonUI : MonoBehaviour
    {  
        [SerializeField] private BonusManagerFacadeSO _bonusManagerFacadeSO;
        [SerializeField] private DailyBonusWindowUI _dailyBonusWindow;
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