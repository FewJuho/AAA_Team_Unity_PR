using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthPoints = 100; // TODO: different enemies?

    public bool isDead = false;
    public Animator animator;
    public float speed = 2.0f;
    public int hitDamage = 250;
    public GameObject ammoPrefab;
    public AudioClip deathAudio;
    public AudioClip attackAudio;
    private GameObject _player;
    private bool attackAudioIsPlaying = false;
    void Start()
    {
        _player = GameObject.Find("v2.0");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
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
            if (!attackAudioIsPlaying)
            {
                StartCoroutine(AttackAudio());
            }
        }
    }

    public void ReactToDamage(int damage) {
        if (isDead)
        {
            return;
        }
        healthPoints -= damage * (int)DataHolder.damageMultiplier;
        animator.SetTrigger("HitTrigger");
        if (healthPoints <= 0) {
            isDead = true;
            GetComponent<AudioSource>().PlayOneShot(deathAudio);
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

    IEnumerator AttackAudio()
    {
        attackAudioIsPlaying = true;
        yield return new WaitForSeconds(2.0f);
        GetComponent<AudioSource>().PlayOneShot(attackAudio);
        yield return new WaitForSeconds(4.0f);
        attackAudioIsPlaying = false;
    }
}
