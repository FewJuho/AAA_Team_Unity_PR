using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collide with " + collision.gameObject.name);
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (null != enemy) {
            ReceiveDamage(enemy.hitDamage);
        }
    }

    void ReceiveDamage(int damage) {
        healthPoints -= damage;
        if (healthPoints < 0) {
            // TODO: switch to game over screen instead
            Destroy(this.transform.gameObject);
        }
    }
}
