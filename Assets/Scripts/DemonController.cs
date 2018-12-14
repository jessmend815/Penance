using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonController : EnemyController
{
    public float hp = 50;
    public float maxHp = 50;
    public GameObject deadDemon;
    Animator anim;
    Vector3 startPos;
    public float chaseDistance;
    public float attackRange;
    public float spd;
    float cools = 0f;
    float chaseCools = 0f;
    float dodgeCools = 0f;
    public float dodgeSpd;
    Rigidbody2D rb;
    Image health;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        startPos = transform.position;
        hp = maxHp;
        int animToPick = Random.Range(0, 2);
        if (animToPick == 0) anim.Play("Demon");
        else anim.Play("DemonBack");
    }

    private void Update()
    {
        switch (curState)
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
            Instantiate(deadDemon, transform.position, Quaternion.identity);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
            PlayerController.player.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (cools > 0)
        {
            cools -= Time.deltaTime;
        }

        if (chaseCools > 0) chaseCools -= Time.deltaTime;
        if (dodgeCools > 0) dodgeCools -= Time.deltaTime;

        if (dodgeCools <= 0) rb.velocity = Vector3.zero;

        health.fillAmount = hp / maxHp;
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
            chaseCools = 0.75f;
            curState = states.attack;
        }

        if (PlayerController.player.transform.position.y > transform.position.y)
        {
            anim.Play("DemonBack");
        }
        else
        {
            anim.Play("Demon");
        }

        var step = spd * Time.deltaTime;

        if (distance > 1.5f) transform.position = Vector3.MoveTowards(transform.position, PlayerController.player.transform.position, step);
    }

    public override void Attack()
    {
        if (PlayerController.player.transform.position.y > transform.position.y)
        {
            anim.Play("DemonBackAttack");
        }
        else
        {
            anim.Play("DemonAttack");
        }
        if (chaseCools <= 0)
        {
            Vector3 dir = PlayerController.player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + Random.Range(-30, 30);
            Quaternion quat = Quaternion.Normalize(Quaternion.AngleAxis(angle, Vector3.down));
            Vector2 direction = new Vector2(quat.x, quat.y);
            rb.velocity = direction * dodgeSpd;
            dodgeCools = 0.25f;
            curState = states.chase;
        }
    }
}
