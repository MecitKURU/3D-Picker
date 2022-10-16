using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Box : MonoBehaviour
{
    private int _currentBallCount;
    private bool _isPassed;

    [SerializeField] GameObject rightGate, leftGate;
    [SerializeField] Transform boxPlane;
    [SerializeField] int neededBallCount;
    [SerializeField] Text ballCountText;
    void Start()
    {
        UpdateBallCountText();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            _currentBallCount++;
            UpdateBallCountText();

            if(_currentBallCount >= neededBallCount && !_isPassed)
            {
                Debug.Log("passed");
                Passed();
            }
        }
    }

    void Passed()
    {
        boxPlane.DOLocalMoveY(0f, 1).OnComplete(() => Player.Instance.canMove = true);
        rightGate.transform.DORotate(new Vector3(0, 0, -90), 1);
        leftGate.transform.DORotate(new Vector3(0, 0, 90), 1);

        _isPassed = true;
    }


    void UpdateBallCountText()
    {
        ballCountText.text = _currentBallCount + "/" + neededBallCount;
    }
}
