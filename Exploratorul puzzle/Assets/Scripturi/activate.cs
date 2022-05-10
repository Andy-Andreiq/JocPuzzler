
//Script pentru activarea secretului 1
//Campurile predefinite ale unity-ului, in C#;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//numele scriptului si clasa;
public class activate : MonoBehaviour
{//declarare variabile atribuite 
    public GameObject stop;
    private bool odata = false;
    //Comanda predefinita folosita cand intri intr-un boxcollider ( BoxColliderul Obiectului pe care e scriptul). care inregistreaza trecerea
    private void OnTriggerEnter(Collider other)
    {//conditie pentru activarea obiectelor
        if (odata == false)
        {//Comanda predefinita care cauta in AudioManager un anumit sunet.
            FindObjectOfType<AudioManager>().Play("bam");
            //Comanda predefinita care seteaza un timer dupa care se activeaza un subprogram declarat ( timer 8 secunde , subprogram "trece")
            Invoke("trece", 8);
            //variabila care realiza conditia o singura data ( devine adevarata )
            odata = true;
        }
    }
    //Comanda predefinita folosita cand iesi dintr-un boxcollider (BoxColliderul Obiectului pe care e scriptul). care inregistreaza iesirea
    private void OnTriggerExit(Collider other)
    {//Activeaza obiectul in cauza
        stop.SetActive(true);
    }
    private void trece()
    {//Face referinta la obiectul in cauza , cauta componenta de pe BoxCollider , si activeaza optiunea de trigger (care permite trecerea inapoi prin el)(Puteam sa il dezactivez direct dar acum am vazut :p )
        stop.GetComponent<BoxCollider>().isTrigger = true;
        
    }
}
