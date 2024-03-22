using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonusUI : MonoBehaviour
{
    [SerializeField] private List<BonusCardUI> _bonusCardList;
    [SerializeField] private Button _claimButton;
    private int _streakCardIndex;

    private void Start()
    {   
        _streakCardIndex = BonusManagerFacade.Instance.GetStreakDay() - 1;

        UpdateCards();
        CheckToClaimCurrentCard();

        _claimButton.onClick.AddListener(() =>
        {
            ClaimCurrentCard();
            BonusManagerFacade.Instance.ClaimBonus();
        });
    }


    private void UpdateCards()
    {
        List<Bonus> bonusList = BonusManagerFacade.Instance.GetBonusList();

        for (int i = 0; i < _bonusCardList.Count; i++)
        {
            UpdateCardData(i, bonusList);

            UpdateCardStatus(i);
        }
    }

    private void UpdateCardData(int index, List<Bonus> bonusList)   
    {
        if (index < bonusList.Count)
        {
            _bonusCardList[index].SetCard(bonusList[index]);
        }
        else
        {
            _bonusCardList[index].SetActive(false);
        }
    }

    private void UpdateCardStatus(int index)
    {
        if (index < _streakCardIndex)
        {
            _bonusCardList[index].SetClaimed();
        }
        else if (index == _streakCardIndex)
        {
            _bonusCardList[index].SetCurrent();
        }
    }

    private void CheckToClaimCurrentCard()
    {
        if (BonusManagerFacade.Instance.GetIsClaimed())
        {
            if (_streakCardIndex < _bonusCardList.Count)
            {
                ClaimCurrentCard();
            }
        }
    }

    private void ClaimCurrentCard()
    {
        BonusCardUI bonusCardUI = _bonusCardList[_streakCardIndex];
        bonusCardUI.SetClaimed();
        _claimButton.interactable = false;
    }


}
