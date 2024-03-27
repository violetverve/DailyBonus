using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DailyBonus.UI
{
    public class ClaimButton : MonoBehaviour
    {  
        [SerializeField] private DailyBonusWindow _dailyBonusWindow;
        [SerializeField] private Button _claimButton;

        private void Start()
        {
            if (BonusManagerFacade.Instance.GetIsClaimed()) {
                SetInteractable(false);
            }
        }
        
        public void ClaimBonus()
        {
            _dailyBonusWindow.ClaimCurrentCard();
            SetInteractable(false);
            BonusManagerFacade.Instance.ClaimBonus();
        }

        public void SetInteractable(bool value)
        {
            _claimButton.interactable = value;
        }
    }
}