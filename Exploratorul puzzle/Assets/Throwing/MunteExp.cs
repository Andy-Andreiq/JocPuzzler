using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunteExp : MonoBehaviour
{

   public bool hasExploded = false;
    public GameObject explosion;
    public GameObject munte;


    private void Awake()
    {
        int storevalue1 = GameObject.FindGameObjectWithTag("Tinta1").GetComponent<DamageScript>().health;
        int storevalue2 = GameObject.FindGameObjectWithTag("Tinta2").GetComponent<DamageScript>().health;
        int storevalue3 = GameObject.FindGameObjectWithTag("Tinta3").GetComponent<DamageScript>().health;

        if (storevalue1 <= 0 && storevalue2 <= 0 && storevalue3 <= 0)
        {
            
            hasExploded = true;
        }

    }


   /* void Explode()
    {


        Instantiate(explosion, transform.position, transform.rotation);
        munte.GetComponent<Animation>().Play("AnimMunte");
        FindObjectOfType<AudioManager>().Play("mountainsound");

    }
*/

}
