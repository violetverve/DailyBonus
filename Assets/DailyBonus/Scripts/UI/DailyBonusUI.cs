using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusUI : MonoBehaviour {

    [SerializeField] private BonusManager bonusManager;
    [SerializeField] private List<GameObject> bonusCards;
    [SerializeField] private Button claimButton;

    private int currentCard = 0;

    private void Start() {
        UpdateBonusCards();

        claimButton.onClick.AddListener(() => {
            ClaimCurrentCard();
            
            bonusManager.ClaimBonus();
        });
    }

    private void UpdateBonusCards() {
        List<Bonus> bonuses = bonusManager.GetDailyBonuses();
        currentCard = bonusManager.GetStreakDay();

        for (int i = 0; i < bonusCards.Count; i++) {

            BonusCardUI bonusCardUI = bonusCards[i].GetComponent<BonusCardUI>();

            if (i < currentCard) {
                bonusCardUI.SetClaimed();
            } else if (i == currentCard) {
                bonusCardUI.SetCurrent();
            }

            if (i < bonuses.Count) {
                bonusCardUI.SetCard(bonuses[i]);
            } else {
                bonusCards[i].SetActive(false);
            }
        }

        if (bonusManager.IsClaimed()) {
            if (currentCard < bonusCards.Count - 1) {
                ClaimCurrentCard();
            }

        }
    }

    private void ClaimCurrentCard() {
        BonusCardUI bonusCardUI = bonusCards[currentCard].GetComponent<BonusCardUI>();
        bonusCardUI.SetClaimed();
        claimButton.interactable = false;
    }


}
