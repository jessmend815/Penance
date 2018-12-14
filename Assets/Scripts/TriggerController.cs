using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {
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
            if (collision.tag == "NPC")
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                if (cools <= 0)
                {
                    cools = 1f;
                    src.PlayOneShot(hit);
                    Invoke("ChangeCools", 0.5f);
                }
                collision.GetComponent<NPCController>().TakeDamage(damage);
            }
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                if (cools <= 0)
                {
                    src.PlayOneShot(hit);
                    cools = 1f;
                    Invoke("ChangeCools", 0.5f);
                }
                collision.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.tag == "NPC")
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                if (cools <= 0)
                {
                    src.PlayOneShot(hit);
                    cools = 1f;
                    Invoke("ChangeCools", 0.5f);
                }
                float dmg = 0.5f;
                collision.GetComponent<NPCController>().TakeDamage(dmg);
            }
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                if (cools <= 0)
                {
                    src.PlayOneShot(hit);
                    cools = 1f;
                    Invoke("ChangeCools", 0.5f);
                }
                float dmg = 0.5f;
                collision.GetComponent<EnemyController>().TakeDamage(dmg);
            }
        }
    }
}
