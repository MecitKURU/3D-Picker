using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public int _levelIndex, mainLevelIndex;
    public static LevelManager Instance;
    public GameObject[] levels;
    public bool isChangeLevel;
    public Transform levelsParent;
    Level previousLevel, currentLevel;
    
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

        _levelIndex = PlayerPrefs.GetInt("LevelNumber", 0);
        mainLevelIndex = PlayerPrefs.GetInt("MainLevelNumber", 0);
    }

    private void Start()
    {
        
        SpawnLevel();
        Player.Instance.gameObject.transform.position = currentLevel.startPoint.position;
        Player.Instance.zPos = Player.Instance.transform.position.z;
        Camera.main.transform.parent = null;
    }

    private void Update()
    {

        if(GameManager.Instance.gameState == InGameStates.Completed)
        {
            
        }

        if (GameManager.Instance.gameState == InGameStates.EndGame)
        {
            if (!isChangeLevel)
            {
                ChangeLevel();
            }
        }
    }

    public void ChangeLevel()
    {
        if (mainLevelIndex < levels.Length - 1)
        {
            PlayerPrefs.SetInt("LevelNumber", _levelIndex + 1);
            PlayerPrefs.SetInt("MainLevelNumber", mainLevelIndex + 1);
        }

        else if (mainLevelIndex >= levels.Length - 1)
        {
            PlayerPrefs.SetInt("LevelNumber", Random.Range(0, levels.Length));
            PlayerPrefs.SetInt("MainLevelNumber", mainLevelIndex + 1);
        }

        SpawnLevel();

        isChangeLevel = true;
    }

    void SpawnLevel()
    {
        _levelIndex = PlayerPrefs.GetInt("LevelNumber");
        mainLevelIndex = PlayerPrefs.GetInt("MainLevelNumber");
        GameObject newLevel = Instantiate(levels[_levelIndex], levelsParent);
        newLevel.transform.localPosition = new Vector3(0, 0, _levelIndex * 110);
        currentLevel = newLevel.GetComponent<Level>();
        GameManager.Instance.startPoint = currentLevel.startPoint;
    }
}
