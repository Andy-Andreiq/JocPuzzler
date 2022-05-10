using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class tutorialfinal : MonoBehaviour
{//variabile de tip obiect si pentru verificare
    //parte 4
    public GameObject gatat;
    public GameObject text;
    public GameObject chest;
    private bool aparut3 = false;
    private void Update()
    {//daca conditia este falsa atunci se activeaza
        if (aparut3 == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("dai", 37);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut3 = true;
        }
    }
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void dai()
    {
        gatat.SetActive(true);
        text.GetComponent<Animation>().Play("lase");
        FindObjectOfType<AudioManager>().Play("tut4");
        Invoke("bag", 11);
        Invoke("fin", 13);
    }
    //subprogram opreste canvasul
    void fin()
    {
        gatat.SetActive(false);
    }
    //subprogramul spawneaza chestul final
    void bag()
    {
        chest.SetActive(true);
    }
}
