using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage = 25f;
    private string IDLE = "Weapon_Idle";
    private string ATTACK = "Attack";
    private float cooldown = 0.7f;
    private bool isReady = true;
    public string owner = "PLAYER";
    private float attackRange = 0.5f;
    public LayerMask layer;
    Animator anim;
    Player player;

    public GameObject go;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    { 
        if (owner.Equals("PLAYER"))
            AttackForPlayer();
        else
            AttackForKnight();
    }

    private void AttackForPlayer()
    {
        damage = 50f;
        if (Input.GetMouseButtonDown(0) && isReady)
        {
            isReady = false;
            StartCoroutine(Cooldown());
            anim.Play(ATTACK);
            player.Attack(damage);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            anim.Play(IDLE);
        }
    }

    public void AttackForKnight()
    {
        if (isReady && Vector2.Distance(player.transform.position, transform.position) < attackRange)
        {
            isReady = false;
            StartCoroutine(Cooldown());
            anim.Play(ATTACK);
            player.takeDamage(10f);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            anim.Play(IDLE);
        }
    }

   

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        isReady = true;
    }






}
