using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Player player;
    public bool startCheck;
    public float timer;

    public static Movement Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxEnter")
        {
            startCheck = true;
            player.canMove = false;
            other.tag = "Untagged";
        }

        if(other.tag == "FinishLine")
        {
            GameManager.Instance.gameState = InGameStates.EndGame;
        }
        if(other.tag == "Multiplier")
        {
            CanvasManager.Instance.collectedDiamondValue = other.GetComponent<Multiplier>().value;
        }
    }

    private void Update()
    {
        if(startCheck)
        {
            timer += Time.deltaTime;

            if(timer >= 3)
            {
                CanvasManager.Instance.OpenFailScreen();
                timer = 0;
                startCheck = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball.isCollected == false)
            {
                Debug.Log("aaa");
                CanvasManager.Instance.pickedBallCount++;
                ball.isCollected = true;
            }
        }
    }
}
