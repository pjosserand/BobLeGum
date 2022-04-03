using System.Data;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private static UIManager uiManagerInstance;
    private int[] _coinsFound;
    private int[] _coinsMax;
    private int numberOfLevels=1;
    private string _path; 
    
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
        uiManagerInstance = UIManager.Instance;
    }
    
    public void FinishLevel()
    {
        uiManagerInstance.DisplayFinishLevelMenu();
    }
    
    public void LooseGame()
    {
        LoadLevel();
    }
    
    public void ExitGame()
    {
        //Debug.Log("Exit Application");
        Application.Quit();
    }

    private void LoadInteractiveLevel(int level)
    {
        Debug.Log("Load Level " + level);
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
            LoadInteractiveLevel(level);
        }
        else
        {
            LoadScene(level);
        }

    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
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
