using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private static GameManager gameManagerInstance;
 
    // Start is called before the first frame update
    void Start()
    {
        gameManagerInstance = GameManager._instance;
    }

    public void BackToMainMenu()
    {
        gameManagerInstance.LoadLevel(0);
    }
}
