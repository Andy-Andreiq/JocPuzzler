using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public Transform explosionEffect;
    public bool distrus = false;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            distrus = true;
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("OOF");
            
        }
       



    }
}
