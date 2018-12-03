using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerController : MonoBehaviour
{
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
            if (collision.tag == "Player")
            {
                src.PlayOneShot(hit);
                collision.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
    }
}
