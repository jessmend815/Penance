using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSquidController : EnemyController
{
    public bool isClose = false;
    public float hp = 50;
    public float maxHp = 50;
    public float blood = 50;
    public GameObject deadSquid;
    Animator anim;
    Vector3 startPos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        startPos = transform.position;
        hp = maxHp;
        int animToPick = Random.Range(0, 2);
        if (animToPick == 0) anim.Play("ZombieSquid");
        else anim.Play("ZombieSquidBack");
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

    private void Update()
    {
        switch(curState)
        {
            case states.idle:
                Idle();
                break;
            case states.chase:
                Chase();
                break;
            case states.attack:
                Attack();
                break;
        }

        if (hp <= 0)
        {
            Instantiate(deadSquid, transform.position, Quaternion.identity);
            PlayerController.player.blood += blood;
            Destroy(gameObject);
        }
    }

    public override void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public override void Idle()
    {

    }

    public override void Chase()
    {

    }

    public override void Attack()
    {

    }

    public override void Death()
    {

    }
}
