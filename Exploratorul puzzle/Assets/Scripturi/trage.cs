using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trage : MonoBehaviour
{//variabila de tip obiect, variabila cu referinta la un script extern 
    //variabile pentru verificare
    public bool Lvr1;
    public Lever lever;
    public bool edat = false;
    public GameObject partelever;
    //metoda care verifica daca exista vreun collider 
    private void OnTriggerEnter(Collider other)
    {
        Lvr1 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Lvr1 = false;
    }
    void Update()
    {//conditii, daca se apasa tasta 'e' si exista un colider si variabila l1 a scriptului extern este adevarata
        if ( Input.GetKeyDown("e") && Lvr1 == true && lever.l1 == true)
        {//variabila devine adevarata si se activeaza componenta animation a obiectului
            edat = true;
            partelever.GetComponent<Animation>().Play("lvrjos");
        }
    }
}
