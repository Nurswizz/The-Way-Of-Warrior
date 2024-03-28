using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hahah
public class Enemy : MonoBehaviour
{
    private float hp = 15f;
    
    public void getAtacked(float damage)
    {
       
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public float getHP()
    {
        return hp;
    }
}
