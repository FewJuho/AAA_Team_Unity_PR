using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElementToggle : MonoBehaviour
{
    Animator anim;

    public GameObject radialMenu;
    public GameObject crosshair;
    public KeyCode toggleKey = KeyCode.Tab;
    public GameObject pauseMenu;
    public static bool gameIsPaused = false;
    public GameObject animationHelper;
    public GameObject stats;
    public GameObject help;
    public GameObject gameOver;

    void Start() 
    {
        anim = GetComponent<Animator>();

        radialMenu.SetActive(false);
        crosshair.SetActive(DataHolder._activateCrosshair);
        pauseMenu.SetActive(false);
        animationHelper.SetActive(false);
        stats.SetActive(true); // copy in StatsManager
        gameIsPaused = false;
        help.SetActive(false);
        gameOver.SetActive(false);
        DataHolder.currentHP = DataHolder.maxHP;

        help.transform.Find("Text").GetComponent<Text>().text = DataHolder._helpText;
    }

    void Update()
    {
        // Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!DataHolder._weaponMenuOpen)
            {
                radialMenu.SetActive(true);
                crosshair.SetActive(false);
                Time.timeScale = 0f;
                DataHolder._weaponMenuOpen = true;
                DataHolder._stopMouseFollowing = true;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                DataHolder._weaponMenuOpen = false;
                crosshair.SetActive(DataHolder._activateCrosshair);
                radialMenu.SetActive(false);
                Time.timeScale = 1f;
                DataHolder._stopMouseFollowing = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        // Escape
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            radialMenu.SetActive(false);
            if (gameIsPaused)
                Resume();
            else 
                Pause();            
        }

        BonusLogic.UpdateDamageMultiplier();
        BonusLogic.UpdateJatpack();
        BonusLogic.UpdateShield();
    }

    public void Resume() 
    {
        stats.SetActive(true);
        DataHolder._globalPause = false;
        radialMenu.SetActive(false);
        pauseMenu.SetActive(false);
        crosshair.SetActive(DataHolder._activateCrosshair);
        Time.timeScale = 1f;
        gameIsPaused = false;
        DataHolder._stopMouseFollowing = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause() 
    {
        stats.SetActive(false);
        DataHolder._globalPause = true;
        pauseMenu.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        DataHolder._stopMouseFollowing = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Help() 
    {
        help.SetActive(true);
    }

    public void closeHelp() 
    {
        help.SetActive(false);
    }

    public void gameIsOver() 
    {
        stats.SetActive(false);
        radialMenu.SetActive(false);
        crosshair.SetActive(false);
        pauseMenu.SetActive(false);

        DataHolder._globalPause = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
        DataHolder._stopMouseFollowing = false;
        Cursor.lockState = CursorLockMode.None;
        
        gameOver.SetActive(true);
        anim.StopPlayback();
        anim.Play("GameOverOn");

        // Start the coroutine to wait for the animation
        StartCoroutine(LoadMenuAfterAnimation());
    }

    public void gameWin()
    {
        gameOver.transform.Find("Text").GetComponent<Text>().text = "Congratulations!";
        if (DataHolder._currentLevel == DataHolder._openLevels) {
            DataHolder._openLevels += 1;
        }
        gameIsOver();
    }

    public void gameLose()
    {
        gameOver.transform.Find("Text").GetComponent<Text>().text = "Game over";
        gameIsOver();
    }

    public void playDamageLightAnim() 
    {
        anim.Play("DamageLightOn", -1, 0f);
    }

    public void MenuScene() 
    {
        DataHolder._globalPause = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
        DataHolder._stopMouseFollowing = false;
        animationHelper.SetActive(true);
        anim.Play("PauseBlackoutOn");

        // Start the coroutine to wait for the animation
        StartCoroutine(LoadMenuAfterAnimation());
    }

    private IEnumerator LoadMenuAfterAnimation()
    {
        // Wait until the current animation is complete
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + 1);

        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() 
    {
        Debug.Log("Quit selected");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}