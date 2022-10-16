using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{

    public Image diamondImg;
    public Transform diamondParent;
    public Transform diamondTarget;


    public float endgameBarValue;
    public Text endgameBarText;
    public Image endgameBar;
    public GameObject failScreen, successScreen;
    public Text coinText, levelText;

    public static CanvasManager Instance;
    bool isEnded;

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

    private void Start()
    {
        endgameBarValue = 100;
    }

    public void OpenFailScreen()
    {
        GameManager.Instance.gameState = InGameStates.Failed;
        failScreen.SetActive(true);
    }
    public void OpenSuccessScreen()
    {
        successScreen.SetActive(true);
    }

    public void UpgradeLevelText()
    {
        levelText.text = "LEVEL " + (LevelManager.Instance.mainLevelIndex + 1);
    }

    public void UpdateCoinText(int val)
    {
        coinText.text = val.ToString();
    }

    private void UpdateEndgameBar()
    {
        //endgameBarValue = Mathf.Lerp(endgameBarValue, 0, Time.deltaTime * 0.5f);

        endgameBar.fillAmount = endgameBarValue / 100;
        endgameBarText.text = "%" + (int)endgameBarValue;
    }

    public void UpdateEndGameBarValue()
    {
        if (!isEnded)
        {
            DOTween.To(() => endgameBarValue, x => endgameBarValue = x, 0, 2f).OnComplete(() =>
            {
                GameManager.Instance.gameState = InGameStates.Collecting;
                isEnded = false;
            });

            isEnded = true;
        }

        UpdateEndgameBar();
    }
    public void ContinueButton()
    {
        Invoke("CloseSuccessScreen", 0.2f);
    }
    void CloseSuccessScreen()
    {
        successScreen.SetActive(false);
        UpgradeLevelText();
    }
    public void SpawnDiamond()
    {
        for (int i = 0; i < 10; i++)
        {
            Image newDiamond = Instantiate(diamondImg, diamondParent);
            Vector3 randomPos = new Vector3(Random.Range(-150, 150), Random.Range(-150, 150), 0);
            newDiamond.transform.localPosition = randomPos;
        }
    }
}





