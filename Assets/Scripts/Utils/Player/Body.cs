using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataHolder;

public class Body : MonoBehaviour
{
    public float collisionCooldown = 1.0f;
    public bool isCollisionAvailable = true;
    public AudioClip bulletPickupAudio;

    void OnCollisionEnter(Collision collision) {
        if (!isCollisionAvailable) {
            return;
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (null == enemy) {
            return;
        }

        if (enemy.isDead) {
            return;
        }

        Debug.Log("Collide with " + collision.gameObject.name);
        if (!DataHolder.shieldActivated)
        {
            ReceiveDamage(DataHolder.AnkleGrabberDamage);
        }
        StartCoroutine(HittingCooldown());
    }

    void OnTriggerEnter(Collider collider) {
        if ("Ammo" != collider.tag) {
            return;
        }

        GetComponent<AudioSource>().PlayOneShot(bulletPickupAudio);

        DataHolder.bulletCount += DataHolder.bulletCountAtCrate;
        Destroy(collider.gameObject);
    }

    void ReceiveDamage(int damage) {
        DataHolder.currentHP -= damage;
        if (DataHolder.currentHP < 0) {
            // TODO: switch to game over screen instead
            // Destroy(this.transform.gameObject);
        }
    }

    private IEnumerator HittingCooldown() {
        isCollisionAvailable = false;
        yield return new WaitForSeconds(collisionCooldown);
        isCollisionAvailable = true;
    }
}
