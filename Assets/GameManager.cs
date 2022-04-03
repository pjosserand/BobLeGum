using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public  UIManager uiManagerInstance;
    //Arrays of var : each index => Level
    public int currentLevel;
    public float[] moveSpeed;
    private int[] _coinsFound;
    public int[] _coinsMax;
    private int numberOfLevels=1;
    private string _path;
    private int win;
    
    public static GameManager Instance
    {
        get { return _instance ? _instance : (_instance = new GameObject("[GameManager]").AddComponent<GameManager>());} 
        private set{ _instance = value;} 
    }

    void Awake(){
        _path = Application.persistentDataPath + "/player.data";
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _coinsFound = new int[numberOfLevels];
        _coinsMax = new int [numberOfLevels];
        moveSpeed = new float[numberOfLevels];
        moveSpeed[0] = 4.0f;
        uiManagerInstance = UIManager.instance;
        win = 0;
    }

    public float GetLevelMoveSpeed()
    {
        currentLevel= SceneManager.GetActiveScene().buildIndex -1;
        return moveSpeed[currentLevel];
    }

    public void SetUIManager(UIManager newInstance)
    {
        uiManagerInstance = newInstance;
    }
    
    //******************************************Victory Conditions****************************************************//
    public void LooseGame()
    {
        win = -1;
        uiManagerInstance.DisplayFinishLevelMenu(win);
    }

    public void WinGame()
    {
        win = 1;
        uiManagerInstance.DisplayFinishLevelMenu(win);
    }
    
    public void ExitGame()
    {
        //Debug.Log("Exit Application");
        Application.Quit();
    }

    //******************************************Load Level****************************************************//

    private void LoadInteractiveLevel(int level)
    {
        win = 0;
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1.0f;
        }
        LoadScene(level);
        uiManagerInstance = UIManager.instance;
    }
    
    public void LoadLevel(int level = -1)
    {
        if (level < 0)
        {
            LoadInteractiveLevel(SceneManager.GetActiveScene().buildIndex);
        }
        else if (level > 0)
        {
            //Level
            LoadInteractiveLevel(level);
        }
        else
        {
            //Main Menu
            LoadScene(level);
        }

    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    //******************************************Save System****************************************************//

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(_path, FileMode.Create);
        PlayerData data = new PlayerData(_coinsFound,_coinsMax);
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public bool LoadData()
    {
        if (File.Exists(_path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            if (data != null)
            {
                _coinsFound = data.coinsFound;
                _coinsMax = data.coinsMax;
            }
            stream.Close();
            return true;
        }
        else
        {
            return false;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
