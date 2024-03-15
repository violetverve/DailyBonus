using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BonusCardUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Image iconImage;

    [SerializeField] private GameObject claimedPanel;
    [SerializeField] private GameObject currentPanel;

    public void SetCard(Bonus dailyBonus) {
        dayText.text = "DAY " + dailyBonus.day.ToString();
        quantityText.text = dailyBonus.quantity.ToString();
        iconImage.sprite = dailyBonus.bonusItem.icon;
    }

    public void SetClaimed() {
        claimedPanel.SetActive(true);
    }

    public void SetCurrent() {
        currentPanel.SetActive(true);
    }

}