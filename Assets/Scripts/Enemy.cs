using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//hahah
public class Enemy : MonoBehaviour
{
    public float hp = 100f;
    public float range = 100f;
    private float arrow_rate = 12f;
    private float cool_down = 2f;
    private bool isReady = true;
    private float speed = 3f;
    public bool isBow = true;

    private Rigidbody2D rb;
    public Slider health_bar;
    public Transform player;    
    public GameObject arrow;
    private GameObject clone;
    public Animator anim;
    private Animator anim_enemy;

            
    private Vector2 moveTo;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim_enemy = GetComponent<Animator>();
        player = GameObject.FindWithTag("pos").GetComponent<Transform>();
    }
    private void Update()
    {

        if (isBow)
        {
            if (clone != null) clone.transform.position = Vector2.MoveTowards(clone.transform.position, moveTo, arrow_rate * Time.deltaTime);
            if (searchForPlayer())
            {
                anim.Play("Shot");
                anim_enemy.Play("idle");
                Attack();
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                anim_enemy.Play("razboinik");
            }

            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1.2f, 1.2f, 1);
            }
            else
            {
                transform.localScale = new Vector3(1.2f, 1.2f, 1);
            }
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            anim_enemy.Play("Walk");
            if (Vector2.Distance(player.transform.position, transform.position) < 0.5f)
            {
                Weapon weapon = GetComponentInChildren<Weapon>();
                anim_enemy.Play("knight");
                weapon.AttackForKnight();
            }

            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1.4f, 1.4f);
            }
            else
                transform.localScale = new Vector2(-1.4f, 1.4f);
        }


        
        

    }
    public void getAtacked(float damage)
    {
       
        hp -= damage;
        health_bar.value = hp;
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().heal(50);
            Destroy(clone);
        }

        
    }
    public float getHP()
    {
        return hp;
    }
    
    public void setHP(float hp)
    {
        this.hp = hp;
    }

    public void Attack()
    {
      
            if (isReady)
            {
                isReady = false;
                StartCoroutine(Cooldown());
                clone = Instantiate(arrow, transform.position, Quaternion.identity);
                moveTo = player.transform.position;
                clone.transform.rotation = Quaternion.Euler(0, 0, MathForGame.angle(player.transform.position.x, player.transform.position.y, transform.position.x, transform.position.y));
                anim.Play("Idle_bow");
            }
    }

   
    private bool searchForPlayer()
    {
        return Vector2.Distance(transform.position, player.transform.position) < 7f;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cool_down);
        Destroy(clone);
        isReady = true;
    }

}
