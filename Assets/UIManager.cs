using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    //UI MainMenu
    public GameObject levelButtonPrefab;
    public GameObject panel;

    //UI In Levels
    public GameObject finishLevelMenu;
    public TextMeshProUGUI txtFinishLevelMenu;
    public TextMeshProUGUI txtScore;
    private string _winMsg = "TU AS GAGNE !";
    private string _loseMsg = "TU AS PERDU !";

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
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
            newLvlBtn = Instantiate(levelButtonPrefab,panel.transform.GetChild(0));
            newTxt = newLvlBtn.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
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
        Time.timeScale = pause ? 0.0f : 1.0f;
    }

    public void DisplayFinishLevelMenu(int win)
    {
        if (finishLevelMenu == null)
        {
            finishLevelMenu = GameObject.Find("/Canvas");
            finishLevelMenu = finishLevelMenu.transform.GetChild(1).gameObject;
            txtFinishLevelMenu = finishLevelMenu.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        }

        txtFinishLevelMenu.SetText(win > 0 ? _winMsg : _loseMsg);

        Time.timeScale = 0.0f;
        finishLevelMenu.SetActive(true);
    }
}