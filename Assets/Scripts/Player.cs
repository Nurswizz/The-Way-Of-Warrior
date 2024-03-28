using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static float hp = 100f;
    private static float speed = 5f;
    private static float attackRange = 0.5f;
    private Rigidbody2D rb;

    private Transform weapon_pos;
    private Animator anim;
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

}
