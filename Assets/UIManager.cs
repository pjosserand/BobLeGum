using UnityEngine;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public GameObject FinishLevelMenu;
    public GameObject DieLevelMenu;
    
    public static UIManager Instance
    {
        get { return _instance ? _instance : (_instance = new GameObject("[UIManager]").AddComponent<UIManager>());} 
        private set{ _instance = value;} 
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void DisplayMenu(GameObject go)
    {
        go.SetActive(true);
    }

    void HideMenu(GameObject go)
    {
        go.SetActive(false);   
    }
    
    public void DisplayFinishLevelMenu()
    {
        Time.timeScale = 0.0f;
        DisplayMenu(FinishLevelMenu);
    }
    
    void HideFinishLevelMenu()
    {
        DisplayMenu(FinishLevelMenu);
    }
}
