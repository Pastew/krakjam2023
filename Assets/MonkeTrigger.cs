using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonkeTrigger : MonoBehaviour
{
    Tweener tweener;

    private void OnEnable()
    {
        tweener = transform.DOScale(0.2f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.MonkeButton();
            gameObject.SetActive(false);
        }
    }
}