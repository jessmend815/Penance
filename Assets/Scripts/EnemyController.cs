using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public virtual void Idle() { }

    public virtual void Chase() { }

    public virtual void Attack() { }

    public virtual void Death() { }

    public virtual void TakeDamage(float damage) { }
}
