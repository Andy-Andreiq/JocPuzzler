using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    private Rigidbody rb;
    private bool targetHit;
    public int damage;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {   //stick to the first target u hit
        if (targetHit)
            return;
        else
            targetHit = true;

        //check if u hit an enemy
        if (collision.gameObject.GetComponent<DamageScript>() != null)
        {
           DamageScript enemy = collision.gameObject.GetComponent<DamageScript>();
           
            
            enemy.TakeDamage(damage);
           

            Destroy(gameObject);


        }

        if(collision.gameObject.GetComponent<Damage2>() != null)
        {
            Damage2 inamic = collision.gameObject.GetComponent<Damage2>();

            inamic.TakeDamage(damage);

            Destroy(gameObject);

        }


        if (collision.gameObject.GetComponent<Damage3>() != null)
        {
            Damage3 mata = collision.gameObject.GetComponent<Damage3>();

            mata.TakeDamage(damage);

            Destroy(gameObject);

        }



        //Rigidbody Kinematic so it cant move anymore

        rb.isKinematic = true;

        //Make sure projectile moves with target
        transform.SetParent(collision.transform);
    }
}
