using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "ScriptableObjects/LevelsData", order = 1)]

public class LevelsData : ScriptableObject
{
    public List<Level> levels;

    [System.Serializable]
    public class Level
    {
        public string lName;
        public float lMoveSpeed;
        public int lCurrentScore;
        public int lMaxScore;
    }
}
