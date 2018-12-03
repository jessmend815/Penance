using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {
    public float damage;
    public AudioClip hit;
    public AudioSource src;

    private void Awake()
    {
        src = GameObject.FindGameObjectWithTag("Source").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.tag == "NPC")
            {
                src.PlayOneShot(hit);
                collision.GetComponent<NPCController>().TakeDamage(damage);
            }
            if (collision.tag == "Enemy")
            {
                src.PlayOneShot(hit);
                collision.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }
    }
}
