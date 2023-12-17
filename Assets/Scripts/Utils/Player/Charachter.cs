using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataHolder;

public class Body : MonoBehaviour
{
    public int healthPoints = 100;
    public float collisionCooldown = 0.1f;
    public bool isCollisionAvailable = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (!isCollisionAvailable) {
            return;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (null == enemy) {
            return;
        }

        Debug.Log("Collide with " + collision.gameObject.name);
        ReceiveDamage(enemy.hitDamage);
        StartCoroutine(HittingCooldown());
    }

    void OnTriggerEnter(Collider collider) {
        if ("Ammo" != collider.tag) {
            return;
        }

        DataHolder.bulletCount += DataHolder.bulletCountAtCrate;
        Destroy(collider.gameObject);
    }

    void ReceiveDamage(int damage) {
        DataHolder.currentHP -= damage;
        if (DataHolder.currentHP < 0) {
            // TODO: switch to game over screen instead
            Destroy(this.transform.gameObject);
        }
    }

    private IEnumerator HittingCooldown() {
        isCollisionAvailable = false;
        yield return new WaitForSeconds(collisionCooldown);
        isCollisionAvailable = true;
    }
}
