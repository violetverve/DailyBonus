using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusUI : MonoBehaviour
{
    [SerializeField] private List<BonusCardUI> _bonusCardList;
    [SerializeField] private Button _claimButton;
    private int _streakDay;

    private void Start()
    {   
        UpdateBonusCards();

        _claimButton.onClick.AddListener(() =>
        {
            ClaimCurrentCard();
            BonusManagerFacade.Instance.ClaimBonus();
        });
    }

    private void UpdateBonusCards()
    {
        List<Bonus> bonuses = BonusManagerFacade.Instance.GetBonusList();

        _streakDay = BonusManagerFacade.Instance.GetStreakDay();

        for (int i = 0; i < _bonusCardList.Count; i++)
        {
            var bonusCardUI = _bonusCardList[i];

            if (i < _streakDay)
            {
                bonusCardUI.SetClaimed();
            }
            else if (i == _streakDay)
            {
                bonusCardUI.SetCurrent();
            }

            if (i < bonuses.Count)
            {
                bonusCardUI.SetCard(bonuses[i]);
            }
            else
            {
                _bonusCardList[i].SetActive(false);
            }
        }

        if (BonusManagerFacade.Instance.GetIsClaimed())
        {
            if (_streakDay < _bonusCardList.Count - 1)
            {
                ClaimCurrentCard();
            }

        }
    }

    private void ClaimCurrentCard()
    {
        BonusCardUI bonusCardUI = _bonusCardList[_streakDay];
        bonusCardUI.SetClaimed();
        _claimButton.interactable = false;
    }


}
