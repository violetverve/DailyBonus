using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DailyBonus.UI
{
    public class ClaimedIconUI : MonoBehaviour
    {   
        [SerializeField] private Image _tickIcon;
        [SerializeField] private float _fadeInDuration = 0.5f;
        [SerializeField] private float _scaleUpDuration = 0.5f;
        [SerializeField] private float _rotateDuration = 0.5f;
        [SerializeField] private float _rotationAngle = 15f;

        void Start()
        {
            _tickIcon.color = new Color(_tickIcon.color.r, _tickIcon.color.g, _tickIcon.color.b, 0);
            _tickIcon.transform.localScale = Vector3.zero;
            _tickIcon.transform.localRotation = Quaternion.Euler(0, 0, -_rotationAngle);

            AnimateTickIcon();
        }

        private void AnimateTickIcon()
        {
            float fullOpacity = 1f;

            _tickIcon.DOFade(fullOpacity, _fadeInDuration).SetEase(Ease.OutQuad);

            _tickIcon.transform.DOScale(fullOpacity, _scaleUpDuration).SetEase(Ease.OutBack);

            _tickIcon.transform
                .DOLocalRotate(Vector3.zero, _rotateDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.OutBack)
                .From(new Vector3(0, 0, _rotationAngle));
        }

    }
}