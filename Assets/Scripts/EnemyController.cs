﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public bool isClose = false;
    public float hp = 10;
    public float blood = 50;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isClose = false;
        }
    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
}
