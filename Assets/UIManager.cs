using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static GameManager gameManagerInstance;
    public static UIManager instance;
    public GameObject finishLevelMenu;
    public TextMeshProUGUI txtFinishLevelMenu;
    private string winMsg = "TU AS GAGNE !";
    private string loseMsg = "TU AS PERDU !";
    
    private void Awake()
    {
        if (instance == this  && instance == null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private void Start()
    {
        gameManagerInstance = GameManager.Instance;
        gameManagerInstance.SetUIManager(this);
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
        if (finishLevelMenu != null)
        {
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
}
