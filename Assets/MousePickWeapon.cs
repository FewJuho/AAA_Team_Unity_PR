using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MousePickWeapon : MonoBehaviour
{
    public GameObject radialMenu;
    public static bool gameIsPaused = false;

    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Resume()
    {
        DataHolder._globalPause = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
        DataHolder._stopMouseFollowing = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        DataHolder._globalPause = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
        DataHolder._stopMouseFollowing = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
