using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimTitle : MonoBehaviour
{
    Tweener tweener;

    void Start()
    {
        tweener = transform.DOScale(1.1f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

}
