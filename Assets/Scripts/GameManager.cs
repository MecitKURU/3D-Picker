using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    bool _isCollected;
    public static GameManager Instance;
    public InGameStates gameState;
    public int coinCount;
    [SerializeField] Player player;

    public Transform startPoint;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        gameState = InGameStates.Started;
        _isCollected = false;
        LevelManager.Instance.isChangeLevel = false;
        player.StartGame();
    }

    private void Update() {
        
        if(gameState == InGameStates.NotStarted && !IsPointerOverUIObject())
        {
            if(Input.touchCount > 0)
            {
                StartGame();
            }
        }

        if(gameState == InGameStates.EndGame)
        {
            CanvasManager.Instance.UpdateEndGameBarValue();
        }

        if(gameState == InGameStates.Collecting)
        {
            if(!_isCollected)
            {
                CanvasManager.Instance.SpawnDiamond();
                _isCollected = true;
            }
        }


        if(gameState == InGameStates.Completed)
        {
            player.canMove = false;

            player.transform.DOMove(startPoint.position, 2f).OnComplete(()=>
            {
                gameState = InGameStates.NotStarted;
                CanvasManager.Instance.OpenSuccessScreen();
                player.xPos = player.transform.position.x;
                player.zPos = player.transform.position.z;
            });
        }
    }



    public void UpdateCoin(int val)
    {
        coinCount += val;
        CanvasManager.Instance.UpdateCoinText(coinCount);
    }


    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
