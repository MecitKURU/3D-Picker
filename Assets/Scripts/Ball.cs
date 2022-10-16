using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isCollected;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxEnterForBall")
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 400);
        }
    }
}
