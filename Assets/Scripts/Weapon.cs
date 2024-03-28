using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float damage = 5f;
    private string IDLE = "Weapon_Idle";
    private string ATTACK = "Attack";
    Animator anim;
    Player player;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play(ATTACK);
            player.Attack(damage);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            anim.Play(IDLE);
        }
    }

    public float makeDamage()
    {
        return damage;
    }

    
   
    

}
