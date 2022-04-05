using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public  UIManager uiManagerInstance;
    //Arrays of var : each index => Level
    public int currentLevel;
    public LevelsData levelsData;
    private string _path;
    private int _win;
    private int _currentScore = 0;
    
   /* public static GameManager Instance
    {
      /*  get { return _instance ? _instance : (_instance = new GameObject("[GameManager]").AddComponent<GameManager>());} 
        private set{ _instance = value;} */

    void Awake(){
        _path = Application.persistentDataPath + "/player.data";
        if (_instance != this && _instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _win = 0;
        uiManagerInstance = UIManager.instance;
        uiManagerInstance.DisplayLevelButtons(levelsData); 
    }
    
    public float GetLevelMoveSpeed()
    {
        currentLevel= SceneManager.GetActiveScene().buildIndex -1;
        return levelsData.levels[currentLevel].lMoveSpeed;
    }

    //******************************************Victory Conditions****************************************************//
    public void LooseGame()
    {
        _win = -1;
        uiManagerInstance.DisplayFinishLevelMenu(_win);
        ResetScore();
    }

    public void WinGame()
    {
        _win = 1;
        uiManagerInstance.DisplayFinishLevelMenu(_win);
        SaveScore();
    }
    
    public void ExitGame()
    {
        //Debug.Log("Exit Application");
        Application.Quit();
    }

    //******************************************Load Level****************************************************//

    private void LoadInteractiveLevel(int level)
    {
        _win = 0;
        if (Time.timeScale <= 0)
        {
            Time.timeScale = 1.0f;
        }

        LoadScene(level);
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
            Time.timeScale = 1.0f;
            Invoke("CallLevelButtons",0.2f);
        }
    }

    public void CallLevelButtons()
    {
        uiManagerInstance.DisplayLevelButtons(levelsData);
    }
    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        uiManagerInstance = UIManager.instance;
    }
    
    //******************************************Save System****************************************************//
    /*
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
                _coinsFou0nd = data.coinsFound;
                _coinsMax = data.coinsMax;
            }
            stream.Close();
            return true;
        }
        else
        {
            return false;
        }
    }*/
    //******************************************Score System****************************************************//
    public void AddToScore(int newScore)
    {
        Debug.Log("_currentScore :" + _currentScore);
        Debug.Log("newScore :" + newScore);
        _currentScore += newScore;
        uiManagerInstance.UpdateScore(_currentScore);
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }

    private void SaveScore()
    {
        levelsData.levels[currentLevel].lCurrentScore = _currentScore;
        _currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
