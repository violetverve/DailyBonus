using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DailyBonus.UI
{
    public class BonusCardPoolUI : MonoBehaviour
    {
        [SerializeField] private BonusCardUI _bonusCardPrefab;
        [SerializeField] private int _defaultCapacity = 7;
        [SerializeField] private int _maxSize = 8;
        private ObjectPool<BonusCardUI> _bonusCardPool;
        
        public int CountActive => _bonusCardPool.CountActive;

        private void Awake()
        {
            _bonusCardPool = new ObjectPool<BonusCardUI>(
                createFunc: CreateBonusCard,
                actionOnGet: ActivateBonusCard,
                actionOnRelease: DeactivateBonusCard,
                actionOnDestroy: DestroyBonusCard,
                collectionCheck: false,
                defaultCapacity: _defaultCapacity,
                maxSize: _maxSize
            );
        }

        private BonusCardUI CreateBonusCard()
        {
            BonusCardUI bonusCardUI = Instantiate(_bonusCardPrefab, transform);
            bonusCardUI.gameObject.SetActive(false);
            return bonusCardUI;
        }

        private void ActivateBonusCard(BonusCardUI bonusCardUI)
        {
            bonusCardUI.gameObject.SetActive(true);
        }

        private void DeactivateBonusCard(BonusCardUI bonusCardUI)
        {
            bonusCardUI.gameObject.SetActive(false);
        }

        private static void DestroyBonusCard(BonusCardUI bonusCardUI)
        {
            Destroy(bonusCardUI.gameObject);
        }

        public BonusCardUI GetCard()
        {
            return _bonusCardPool.Get();
        }

    }
}