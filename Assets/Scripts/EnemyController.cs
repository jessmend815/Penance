using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public enum states { idle, chase, attack };
    public states curState = states.idle;

    public virtual void Idle() { }

    public virtual void Chase() { }

    public virtual void Attack() { }

    public virtual void TakeDamage(float damage) { }
}
