using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BonusCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _quantityText;
    [SerializeField] private Image _iconImage;

    [SerializeField] private GameObject _claimedPanel;
    [SerializeField] private GameObject _currentPanel;

    public void SetCard(Bonus dailyBonus)
    {
        _dayText.text = "DAY " + dailyBonus.Day.ToString();
        _quantityText.text = dailyBonus.Quantity.ToString();
        _iconImage.sprite = BonusManagerFacade.Instance.GetItemById(dailyBonus.Id).icon;
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