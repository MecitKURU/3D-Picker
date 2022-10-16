using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxEnter")
        {
            player.canMove = false;
            other.tag = "Untagged";
        }

        if(other.tag == "FinishLine")
        {
            GameManager.Instance.gameState = InGameStates.EndGame;
        }
    }
}
