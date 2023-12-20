using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints = 100; // TODO: different enemies?

    public float speed = 2.0f;
    public int hitDamage = 250;
    public GameObject ammoPrefab;

    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("v2.0");
    }

    void Update()
    {
        Vector3 lookAt = _player.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void ReactToDamage(int damage) {
        healthPoints -= damage * (int)DataHolder.damageMultiplier;
        if (healthPoints <= 0) {
            // TODO: add animation before nonexistence
            ++DataHolder.killedEnemiesCount;
            Debug.Log("Kill " + DataHolder.killedEnemiesCount.ToString());
            Instantiate(ammoPrefab, this.transform.position,  Quaternion.identity);
            Destroy(this.transform.gameObject);
        }
    }
}
