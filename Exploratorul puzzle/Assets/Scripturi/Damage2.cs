using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage2 : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public Transform explosionEffect;
    public bool distrus2 = false;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            distrus2 = true;
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("OOF");

        }




    }
}