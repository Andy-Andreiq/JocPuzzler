using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class trage3 : MonoBehaviour
{//variabila de tip obiect, variabila cu referinta la un script extern 
    public bool Lvr3;
    public Lever lever3;
    public bool edat2 = false;
    public GameObject partelever3;
    //metoda care verifica daca exista vreun collider 
    private void OnTriggerEnter(Collider other)
    {
        Lvr3 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Lvr3 = false;
    }
    void Update()
    {//conditii, daca se apasa tasta 'e' si exista un colider si variabila l3 a scriptului extern este adevarata
        if ( Input.GetKeyDown("e") && Lvr3 == true && lever3.l3 == true)
        {//variabila devine adevarata si se activeaza componenta animation a obiectului
            edat2 = true;
            partelever3.GetComponent<Animation>().Play("lvrjos3");
        }
    }
}
