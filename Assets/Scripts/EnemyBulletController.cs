﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
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
        if (collision.tag == "Player")
        {
            if (collision.isTrigger == false)
            {
                src.PlayOneShot(hit);
                PlayerController.player.TakeDamage(damage);
                Invoke("Disable", 0.01f);
            }
        }
    }
}
