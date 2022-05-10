
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage3 : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public Transform explosionEffect;
    public bool distrus3 = false;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            distrus3 = true;
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("OOF");

        }




    }
}

