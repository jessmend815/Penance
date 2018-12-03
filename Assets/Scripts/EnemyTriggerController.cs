﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerController : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
    }
}
