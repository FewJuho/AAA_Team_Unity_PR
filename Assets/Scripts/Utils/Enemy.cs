using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints = 100; // TODO: different enemies?
    public float speed = 5.0f;
    public int hitDamage = 10;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("First Person Controller");
    }

    void Update()
    {
        Vector3 lookAt = _player.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void ReactToDamage(int damage) {
        healthPoints -= damage;
        if (healthPoints <= 0) {
            // TODO: add animation before nonexistence
            Destroy(this.transform.gameObject);
        }
    }
}
