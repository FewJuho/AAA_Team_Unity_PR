using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject GfxPanel;
    public GameObject LoadGamePanel;

    public int openLevels;
    public Text openLevelsText;
    private int GlobalLevelCount = 6;


    void Start () {
        anim = GetComponent<Animator>();

        openLevels = DataHolder._openLevels;

        // //new key
        // PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);

        openLevelsText.text = openLevels.ToString();
    }


    // ------ Open different panels level 1 --------

    public void openOptions()
    {
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);

        anim.Play("buttonTweenAnims_on");

        playClickSound();
    }

    public void openStartGameOptions()
    {
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);

        anim.Play("buttonTweenAnims_on");

        playClickSound();
    }

    // ------ Open different panels level 2 --------

    public void openOptions_Game()
    {
        GamePanel.SetActive(true);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);

        anim.Play("OptTweenAnim_on");

        playClickSound();
    }

    public void openOptions_Controls()
    {
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(true);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);

        anim.Play("OptTweenAnim_on");

        playClickSound();
    }

    public void openOptions_Gfx()
    {
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(true);
        LoadGamePanel.SetActive(false);

        anim.Play("OptTweenAnim_on");

        playClickSound();
    }

    public void openContinue_Load()
    {
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(true);

        setLevelsActive();

        // anim.Play("OptTweenAnim_on");
        anim.Play("showLevels_on");

        playClickSound();
    }

    // ------ Game management --------

    public void newGame(int level)
    {
        Debug.Log("New game is level: " + level.ToString());
        DataHolder._currentLevel = level;
        if (level == 1)
            SceneManager.LoadScene("LunarLandscape3D");
        else
            Debug.LogError("BUG: level not loaded, check MainMenuController.newGame");
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

    // ------ Back Buttons --------

    public void back_options()
    {
        anim.Play("buttonTweenAnims_off");

        playClickSound();
    }

    public void back_options_panels()
    {
        anim.Play("OptTweenAnim_off");
        
        playClickSound();

    }

    public void back_from_levels()
    {
        anim.Play("showLevels_off");

        playClickSound();
    }

    // ------ Developer Features --------

    public void openLevelsPlus()
    {
        openLevels += 1;
        DataHolder._openLevels = openLevels;
        openLevelsText.text = openLevels.ToString();
    }

    public void openLevelsMinus()
    {
        openLevels -= 1;
        DataHolder._openLevels = openLevels;
        openLevelsText.text = openLevels.ToString();
    }

    // ------ Sounds --------

    public void playHoverClip()
    {
       
    }

    void playClickSound() {

    }

    // ----------------------

    public void setLevelsActive() {
        for (int i = 1; i <= GlobalLevelCount; i++)
        {
            string objectName = "LoadSlot_" + i;
            GameObject loadSlot = GameObject.Find(objectName);

            Image image = loadSlot.GetComponent<Image>();
            image.color = Color.gray;

            if (loadSlot != null)
            {
                if (i <= openLevels)
                    loadSlot.transform.Find("saveName").GetComponent<Button>().interactable = true;
                else
                    loadSlot.transform.Find("saveName").GetComponent<Button>().interactable = false;
            }
            else
            {
                Debug.Log("Объект " + objectName + " не найден");
            }
        }
    }
}
