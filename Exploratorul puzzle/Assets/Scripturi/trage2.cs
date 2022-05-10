using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trage2 : MonoBehaviour
{//variabila de tip obiect, variabila cu referinta la un script extern 
    //variabile pentru verificare
    public bool Lvr2;
    public Lever lever2;
    public bool edat1 = false;
    public GameObject partelever2;
    //metoda care verifica daca exista vreun collider 
    private void OnTriggerEnter(Collider other)
    {
        Lvr2 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Lvr2 = false;
    }
    void Update()
    {//conditii, daca se apasa tasta 'e' si exista un colider si variabila l2 a scriptului extern este adevarata
        if ( Input.GetKeyDown("e") && Lvr2 == true && lever2.l2 == true)
        {//variabila devine adevarata si se activeaza componenta animation a obiectului
            edat1 = true;
            partelever2.GetComponent<Animation>().Play("lvrjos2");
        }
    }
}
