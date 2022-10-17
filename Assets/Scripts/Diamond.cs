using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{
    Vector3 target;
    private void Start()
    {
        target = CanvasManager.Instance.diamondTarget.position;
        transform.DOScale(Vector3.one * 0.4f, 1f);
        transform.DOMove(target, 1.1f).SetEase(Ease.InFlash).OnComplete(() =>
        {
            GameManager.Instance.gameState = InGameStates.Completed;
            Destroy(this.gameObject);
        });
    }
}
