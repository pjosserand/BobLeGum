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

    void DisplayMenu(GameObject go)
    {
        go.SetActive(true);
    }

    void HideMenu(GameObject go)
    {
        go.SetActive(false);   
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
            //Display FinishLevelMenu
            DisplayMenu(finishLevelMenu);
        }
    }
}
