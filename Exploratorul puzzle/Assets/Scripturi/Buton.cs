using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Buton : MonoBehaviour
{//variabile care verifica conditii
    private bool mere = false;
    public bool apasat = false;

    //subprograme care verifica trecerea printr-un collider , setat pe obiectul respectiv
    private void OnTriggerEnter(Collider other)
    {
        mere = true;
    }
    private void OnTriggerExit(Collider other)
    {
        mere = false;
    }
    void Update()
    {//conditie care verifica daca apesi 'e' si daca treci prin collider
        if(Input.GetKeyDown("e") && mere == true)
        {//activeaza componenta animation de pe obiect
            GetComponent<Animation>().Play("buton");
            //conditia este aplicata , variabila devine adevarata(nefolositoare)
            apasat = true;
            //comanda folosita pentru a da delay unui subprogram cu nume respectiv si cu timpul respectiv
            Invoke("distrugere", 1);
        }
    }
    //subprogram care este activat mai sus si care distruge obiectul resprectiv
    void distrugere()
    {
        Destroy(gameObject);
    }
}
