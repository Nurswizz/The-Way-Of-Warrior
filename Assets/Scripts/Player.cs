using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float hp = 500f;
    private float speed = 5f;
    private float attackRange = 1.5f;


    private Rigidbody2D rb;
    private Transform weapon_pos;
    private Animator anim;
    public Slider health_bar;

    public LayerMask layer;

    private const string idle = "Player_idle";
    private const string move = "Player_move";
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        weapon_pos = GetComponentInChildren<Transform>();
    }
    public void Attack(float damage)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(weapon_pos.position, attackRange, layer);
        foreach (Collider2D hit in hitEnemies)
        {
            Enemy enemy = hit.gameObject.GetComponent<Enemy>();
            enemy.getAtacked(damage);
        }
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(x * speed, y * speed);
        if (x > 0)
        {
            transform.localScale = new Vector2(1.2f, 1.2f);
        }
        else if(x < 0)
        {
            transform.localScale = new Vector2(-1.2f, 1.2f);
        } 

        if (Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0)
        {
            anim.Play(move);
        }
        else
        {
            anim.Play(idle);
        }
       

       
       
    }

    
    public void takeDamage(float damage)
    {
        hp -= damage;
        health_bar.value = hp;
    }

    public float getHp()
    {
        return hp;
    }

    public void heal(float HP)
    {
        hp += HP;
        health_bar.value = hp;

    }



}
