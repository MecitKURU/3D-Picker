using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public int collectedDiamondValue;
    public Text collectedDiamondValueText;
    public Gradient gradient;
    public float pickedBallCount;

    public Image diamondImg;
    public Transform diamondParent;
    public Transform diamondTarget;


    public float endgameBarValue;
    public Text endgameBarText;
    public Image endgameBar;
    public GameObject failScreen, successScreen;
    public Text diamondText, levelText;
    bool isEnded;
    LevelManager levelManager;

    public static CanvasManager Instance;

    public Image[] fillImages;

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
        levelManager = LevelManager.Instance;

    }
    private void Update()
    {
        UpdateEndgameBar();
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
    public void UpdateDiamondText()
    {
        PlayerPrefs.SetInt("Diamond", collectedDiamondValue + PlayerPrefs.GetInt("Diamond", 0));
        diamondText.text = PlayerPrefs.GetInt("Diamond", 0).ToString();
    }

    private void UpdateEndgameBar()
    {
        endgameBar.fillAmount = Mathf.Lerp(endgameBar.fillAmount, (float)pickedBallCount / levelManager.currentLevel.neededBallCount, Time.deltaTime * 5);
        endgameBarText.text = "%" + (int)(endgameBar.fillAmount * 100);
        endgameBar.color = gradient.Evaluate(endgameBar.fillAmount);

        float value = endgameBar.fillAmount;

        if (value <= 0.2f)
        {
            fillImages[0].fillAmount = value * 5;
        }

        for (int i = 0; i < fillImages.Length; i++)
        {
            fillImages[i].fillAmount = (value - 0.2f * i) * 5;
        }


    }

    public void EndGameBarToEmpty()
    {
        if (pickedBallCount > 0)
        {
            pickedBallCount -= 8 * Time.deltaTime;
        }
        else GameManager.Instance.gameState = InGameStates.Collecting;
    }

    public void ContinueButton()
    {
        CloseSuccessScreen();
    }
    void CloseSuccessScreen()
    {
        successScreen.SetActive(false);
        UpgradeLevelText();
    }
    public void SpawnDiamond()
    {

        collectedDiamondValueText.gameObject.SetActive(true);
        collectedDiamondValueText.text = collectedDiamondValue.ToString();


        collectedDiamondValueText.DOColor(new Color32(0, 0, 0, 0), 1).OnComplete(() =>
        {
            collectedDiamondValueText.color = new Color32(0, 0, 0, 255);
            collectedDiamondValueText.gameObject.SetActive(false);
            UpdateDiamondText();
        });

        for (int i = 0; i < 10; i++)
        {
            Image newDiamond = Instantiate(diamondImg, diamondParent);
            Vector3 randomPos = new Vector3(Random.Range(-150, 150), Random.Range(-150, 150), 0);
            newDiamond.transform.localPosition = randomPos;
        }
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }
}





