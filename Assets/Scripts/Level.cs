using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public int neededBallCount;
    [SerializeField] GameObject rightGate, leftGate;
    public Transform startPoint;
    bool _isPassed;



    public void Passed()
    {
        rightGate.transform.DORotate(new Vector3(0, 0, -90), 1);
        leftGate.transform.DORotate(new Vector3(0, 0, 90), 1);

        _isPassed = true;
    }
}
