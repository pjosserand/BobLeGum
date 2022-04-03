using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    private int _numberOfLevels;
    //private Rect 
    // Start is called before the first frame update
    void Start()
    {
        _numberOfLevels = SceneManager.sceneCountInBuildSettings - 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
