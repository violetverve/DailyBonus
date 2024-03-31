using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DailyBonus.UI
{
    public class CurrentCardUI : MonoBehaviour
    {   
        [Header("Animations")]
        [SerializeField] private float _scaleUpDuration = 1f;
        [SerializeField] private float _scaleDownDuration = 1f;
        [SerializeField] private Vector3 _targetScale = new Vector3(1.05f, 1.05f, 1.05f);
        private Vector3 _originalScale;

        private void Start()
        {
            _originalScale = transform.localScale;
            AnimateScale();
        }

        private void AnimateScale()
        {
            var sequence = DOTween.Sequence();

            sequence.Append(ScaleTo(_targetScale, _scaleUpDuration, Ease.OutQuad))
                    .Append(ScaleTo(_originalScale, _scaleDownDuration, Ease.InQuad))
                    .SetLoops(-1, LoopType.Yoyo);
        }

        private Tween ScaleTo(Vector3 targetScale, float duration, Ease ease)
        {
            return transform.DOScale(targetScale, duration).SetEase(ease);
        }

    }
}
