using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class cade : MonoBehaviour
{//variabila care face referinta la un script si alte doua variabile de verificare
    public erupe da;
    private bool nuafost = true;
    public bool meteorit = false;
    //subprogram predefinit pentru updatarea scenei
    private void Update()
    {//cautarea de conditii, daca in scriptul "erupe" cometa e adevarat 
        //si daca actiunea a mai fost realizata
        if (da.cometa == true && nuafost == true)
        {//cauta componenta animatie si o activeaza
            GetComponent<Animation>().Play("fly");
            //comanda predefinita pentru delay la subprogramul sunet ,de 1 secunda
            Invoke("sunet", 1);
            //variabila nuafost devine false pentru ca actiunea sa nu se repete,
            //meteorit devine adevarata ( folosita in alt script)
            nuafost = false;
            meteorit = true;
        }
    }
    //subprogram care cauta AudioManager-ul si activeaza sunetul 
    void sunet()
    {
        FindObjectOfType<AudioManager>().Play("picat");
    }
}
