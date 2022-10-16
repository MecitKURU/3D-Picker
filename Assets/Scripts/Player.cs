using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float swipeSpeed, movementSpeed;
    public float xPos, zPos;
    public Vector3 targetPos;

    public static Player Instance;
    public bool canMove;
    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        canMove = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //collision.gameObject.transform.parent = gameObject.transform.parent;
        }
    }

    private void FixedUpdate()
    {

        if (GameManager.Instance.gameState == InGameStates.Started)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    xPos += touch.deltaPosition.x * Time.deltaTime * swipeSpeed;
                    xPos = Mathf.Clamp(xPos, -1.5f, 1.5f);
                }
            }

            zPos += Time.deltaTime * movementSpeed;
            
        }

        else if(GameManager.Instance.gameState == InGameStates.EndGame)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    xPos += touch.deltaPosition.x * Time.deltaTime * swipeSpeed;
                    xPos = Mathf.Clamp(xPos, -1.5f, 1.5f);
                }

            }

            zPos += Time.deltaTime * movementSpeed * 3;
        }

        if (canMove)
        {
            targetPos = new Vector3(xPos, transform.position.y, zPos);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * movementSpeed);
        }
    }
}
