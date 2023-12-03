using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    // Animator anim;
    public GameObject stats;
    public GameObject hp;
    public GameObject bullets;

    [System.NonSerialized] public int maxHP;
    [System.NonSerialized] public int currentHP;
    [System.NonSerialized] public int bulletCount;
    [System.NonSerialized] public string[] weaponTypes;
    

    void Start() {
        // anim = GetComponent<Animator>();

        stats.SetActive(true);  // copy in ElementToggle
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  // TODO delete
        {
            minusHP(100);
        } 
        if (Input.GetKeyDown(KeyCode.B))
        {
            minusBullets(1);
        } 


        // Get values from DataHolder
        maxHP = DataHolder.maxHP;
        currentHP = DataHolder.currentHP;
        bulletCount = DataHolder.bulletCount;
        weaponTypes = DataHolder.weaponTypes;

        if (currentHP == 0) {
            Debug.LogError("You are dead!"); // TODO delete
        }

        // Apply changes to game objects
        hp.transform.Find("hp_numbers/hp_max").GetComponent<Text>().text = maxHP.ToString();
        hp.transform.Find("hp_numbers/hp_value").GetComponent<Text>().text = currentHP.ToString();
        hp.transform.Find("hp_bar").GetComponent<Image>().fillAmount = (float)currentHP / maxHP;

        bullets.transform.Find("Text").GetComponent<Text>().text = bulletCount.ToString();
    }



    public void minusHP(int hpCount) {
        DataHolder.currentHP = Math.Max(DataHolder.currentHP - hpCount, 0);
    }

    public void minusBullets(int bulletCount) {
        DataHolder.bulletCount = Math.Max(DataHolder.bulletCount - bulletCount, 0);
    }
}