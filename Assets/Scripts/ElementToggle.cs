using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElementToggle : MonoBehaviour
{
    Animator anim;

    public GameObject radialMenu;
    public KeyCode toggleKey = KeyCode.Tab;
    public GameObject pauseMenu;
    public static bool gameIsPaused = false;
    public GameObject animationHelper;
    public GameObject stats;
    public GameObject help;
    public static bool weaponMenuOpen = false;

    void Start() {
        anim = GetComponent<Animator>();

        radialMenu.SetActive(false);

        pauseMenu.SetActive(false);
        animationHelper.SetActive(false);
        stats.SetActive(true); // copy in StatsManager
        gameIsPaused = false;
        help.SetActive(false);

        help.transform.Find("Text").GetComponent<Text>().text = DataHolder._helpText;
    }

    void Update()
    {
        // Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            radialMenu.SetActive(!radialMenu.activeSelf);
            if (!weaponMenuOpen)
            {
                Time.timeScale = 0f;
                weaponMenuOpen = true;
                DataHolder._stopMouseFollowing = true;
                Cursor.lockState = CursorLockMode.None;
            } else
            {
                weaponMenuOpen = false;
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
    }

    public void Resume() 
    {
        stats.SetActive(true);
        DataHolder._globalPause = false;
        radialMenu.SetActive(false);
        pauseMenu.SetActive(false);
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
        Time.timeScale = 0f;
        gameIsPaused = true;
        DataHolder._stopMouseFollowing = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Help() {
        help.SetActive(true);
    }

    public void closeHelp() {
        help.SetActive(false);
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
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

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