using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class tutorialstart2 : MonoBehaviour
{    //variabile de tip obiect si pentru verificare
    //parte 3
    public GameObject pick;
    public GameObject dial;
    public GameObject usa;
    private bool aparut2 = false;
    private void Update()
    {//daca conditia este falsa atunci se activeaza
        if (aparut2 == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("pickup", 24);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut2 = true;
        }
    }
    //parte 3
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void pickup()
    {
        pick.SetActive(true);
        dial.GetComponent<Animation>().Play("spawnat");
        FindObjectOfType<AudioManager>().Play("tut3");
        Invoke("spawn", 7);
        Invoke("gata", 11f);
    }
    //subprogram opreste canvasul
    void gata()
    {
        pick.SetActive(false);
    }
    //Spawneaza o usa pe harta 
    void spawn()
    {
        usa.SetActive(true);
    }
}
