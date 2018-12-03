using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSquidController : EnemyController
{
    public float hp = 50;
    public float maxHp = 50;
    public GameObject deadSquid;
    Animator anim;
    Vector3 startPos;
    public float chaseDistance;
    public float attackRange;
    public float spd;
    public GameObject bullet;
    float cools = 0f;

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
            Destroy(gameObject);
        }

        if (cools > 0)
        {
            cools -= Time.deltaTime;
        }
    }

    public override void TakeDamage(float damage)
    {
        hp -= damage;
    }

    public override void Idle()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.player.transform.position);
        if (distance <= chaseDistance)
        {
            curState = states.chase;
        }

        if (transform.position != startPos)
        {
            var step = spd * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
        }
    }

    public override void Chase()
    {
        float distance = Vector3.Distance(transform.position, PlayerController.player.transform.position);
        if (distance > chaseDistance)
        {
            curState = states.idle;
        }
        if (distance < attackRange && cools <= 0)
        {
            curState = states.attack;
        }

        if (PlayerController.player.transform.position.y > transform.position.y)
        {
            anim.Play("ZombieSquidBack");
        }
        else
        {
            anim.Play("ZombieSquid");
        }

        var step = spd * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, PlayerController.player.transform.position, step);
    }

    public override void Attack()
    {
        if (PlayerController.player.transform.position.y > transform.position.y)
        {
            anim.Play("ZombieSquidBack");
        }
        else
        {
            anim.Play("ZombieSquid");
        }

        Vector3 dir = PlayerController.player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + Random.Range(-30, 30);
        Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        cools = 0.75f;
        curState = states.chase;
    }
}
