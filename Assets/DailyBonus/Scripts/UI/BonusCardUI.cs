using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DailyBonus.UI
{
    public class BonusCardUI : MonoBehaviour
    {
        [SerializeField] private BonusManagerFacadeSO _bonusManagerFacadeSO;
        
        [Header("UI Elements")]
        [SerializeField] private TextMeshProUGUI _dayText;
        [SerializeField] private TextMeshProUGUI _quantityText;
        [SerializeField] private Image _iconImage;

        [Header("Panels")]
        [SerializeField] private GameObject _claimedPanel;
        [SerializeField] private GameObject _currentPanel;

        public void SetCard(Bonus dailyBonus)
        {
            _dayText.text = "DAY " + dailyBonus.Day;
            _quantityText.text = dailyBonus.Quantity.ToString();
            _iconImage.sprite = _bonusManagerFacadeSO.GetItemById(dailyBonus.Id).Icon;
        }

        public void SetClaimed()
        {
            _claimedPanel.SetActive(true);
        }

        public void SetCurrent()
        {
            _currentPanel.SetActive(true);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

    }
}