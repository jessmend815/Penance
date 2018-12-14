using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float spd = 10;
    public float damage = 5;
    Rigidbody2D bod;
    public AudioClip hit;
    public AudioSource src;

    private void Awake()
    {
        src = GameObject.FindGameObjectWithTag("Source").GetComponent<AudioSource>();
        bod = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Invoke("Disable", 3f);
        bod.velocity = transform.right * spd;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            if (!collision.isTrigger)
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                src.PlayOneShot(hit);
                Invoke("Disable", 0.01f);
                collision.gameObject.GetComponent<NPCController>().TakeDamage(damage);
            }
        }
        if (collision.tag == "Enemy")
        {
            if (collision.isTrigger == false)
            {
                collision.GetComponent<SpriteOutline>().enabled = true;
                src.PlayOneShot(hit);
                collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
                Invoke("Disable", 0.01f);
            }
        }
    }
}
