using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text enemyCounter;

    public ElementToggle toggle;
    void Update()
    {
        enemyCounter.text = "Enemies Left: " + (toggle.killCountToWin - DataHolder.killedEnemiesCount).ToString();
    }
}
