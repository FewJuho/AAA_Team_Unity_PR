using GLTF.Schema;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints = 100; // TODO: different enemies?

    private bool isdead = false;
    public Animator animator;
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
        if (isdead)
        {
            return;
        }
        Vector3 lookAt = _player.transform.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);

        transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _player.transform.position) < 5.0f)
        {
            animator.SetTrigger("BiteTrigger");
        }
    }

    public void ReactToDamage(int damage) {
        if (isdead)
        {
            return;
        }
        healthPoints -= damage * (int)DataHolder.damageMultiplier;
        animator.SetTrigger("HitTrigger");
        if (healthPoints <= 0) {
            isdead = true;
            // TODO: add animation before nonexistence
            ++DataHolder.killedEnemiesCount;
            Debug.Log("Kill " + DataHolder.killedEnemiesCount.ToString());
            Instantiate(ammoPrefab, this.transform.position,  Quaternion.identity);
            animator.SetBool("Dies", true);
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.transform.gameObject);
    }
}
