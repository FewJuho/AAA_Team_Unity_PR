using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_level_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int info = DataHolder._currentLevel;
        Debug.Log("Current level LunarLandscape3D id : " + info.ToString());   
    }
}
