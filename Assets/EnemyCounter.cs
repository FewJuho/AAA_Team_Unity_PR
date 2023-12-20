using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text enemyCounter;

    void Update()
    {
        enemyCounter.text = "Enemies Left: " + (10 - DataHolder.killedEnemiesCount).ToString();
    }
}
