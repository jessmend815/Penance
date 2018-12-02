﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            //GetComponent<NPCController>().TakeDamage(damage);
        }
        if (collision.tag == "Enemy")
        {
            GetComponent<EnemyController>().TakeDamage(damage);
        }
    }
}
