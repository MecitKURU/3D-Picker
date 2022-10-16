using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    Vector3 smoothedPos;
    void Start()
    {
        offset = transform.position - player.position;
        smoothedPos = transform.position;
    }
    void FixedUpdate()
    {
        Vector3 targetPos = offset + player.position;
        smoothedPos = Vector3.Lerp(smoothedPos, targetPos, Time.deltaTime * 10);
        transform.position = new Vector3(transform.position.x, transform.position.y, smoothedPos.z);
    }
}
