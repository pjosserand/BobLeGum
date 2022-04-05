using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    //UI MainMenu
    public GameObject levelButtonPrefab;
    public GameObject panel;

    //UI In Levels
    public GameObject finishLevelMenu;
    public TextMeshProUGUI txtFinishLevelMenu;
    public TextMeshProUGUI txtScore;
    private string winMsg = "TU AS GAGNE !";
    private string loseMsg = "TU AS PERDU !";

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void DisplayLevelButtons(LevelsData levelsData)
    {
        if (levelButtonPrefab == null)
        {
            levelButtonPrefab = Resources.Load("Prefab/UI/LevelButton") as GameObject;
            return;
        }

        if (panel == null)
        {
            panel = GameObject.Find("/Canvas").transform.GetChild(0).GetChild(1).GetChild(2).gameObject;
        }

        GameObject newLvlBtn;
        TextMeshProUGUI newTxt;
        Transform scoreTxtParent;
        for (int i = 0; i < levelsData.levels.Count; i++)
        {
            var currentLevel = levelsData.levels[i];
            Debug.Log(panel);
            newLvlBtn = Instantiate(levelButtonPrefab,panel.transform.GetChild(0));
            Debug.Log(newLvlBtn.transform);
            newTxt = newLvlBtn.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            //Debug.Log(newTxt);
            newTxt.SetText(currentLevel.lName);
            scoreTxtParent = newLvlBtn.transform.GetChild(1).GetChild(0);
            newTxt = scoreTxtParent.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            newTxt.SetText(currentLevel.lCurrentScore.ToString());
            newTxt = scoreTxtParent.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            newTxt.SetText(currentLevel.lMaxScore.ToString());
        }

    }


    public void UpdateScore(int newScore)
    {
        if (txtScore == null) 
        {
            GameObject newT =GameObject.Find("/Canvas");
            newT = newT.transform.GetChild(2).GetChild(1).GetChild(1).gameObject;
            txtScore = newT.GetComponent<TextMeshProUGUI>();  
        }
        txtScore.SetText(newScore.ToString());
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void DisplayFinishLevelMenu(int win)
    {
        if (finishLevelMenu == null)
        {
            finishLevelMenu = GameObject.Find("/Canvas");
            finishLevelMenu = finishLevelMenu.transform.GetChild(1).gameObject;
            txtFinishLevelMenu = finishLevelMenu.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        }

        if (win > 0)
        {
            txtFinishLevelMenu.SetText(winMsg);
        }
        else
        {
            txtFinishLevelMenu.SetText(loseMsg);
        }

        Time.timeScale = 0.0f;
        finishLevelMenu.SetActive(true);
    }
}