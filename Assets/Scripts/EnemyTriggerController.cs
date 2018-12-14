using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerController : MonoBehaviour
{
    public float damage;
    public AudioClip hit;
    public AudioSource src;

    float cools = 0;

    private void Awake()
    {
        src = GameObject.FindGameObjectWithTag("Source").GetComponent<AudioSource>();
    }

    void ChangeCools()
    {
        cools = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                if (cools <= 0)
                {
                    src.PlayOneShot(hit);
                    cools = 1f;
                    Invoke("ChangeCools", 0.25f);
                }
                collision.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
    }
}
