using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class tutorialstart : MonoBehaviour
{//parte 1
    //variabile de tip obiect si pentru verificare
    public GameObject pp;
    public GameObject txt;
    private bool aparut = false;
    //parte 2
    public GameObject pick;
    public GameObject dial;
    public GameObject blockrosu;
    private bool aparut2 = false;
    //metoda
    private void Update()
    {//daca conditia este falsa atunci se activeaza
        if (aparut == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("mana", 2);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut = true;
        }
        if (aparut2 == false)
        {//se foloseste comanda de delay cu nume subprogramului respectiv
            Invoke("pickup", 12);
            //variabila devina adevarata pentru a preveni reinceperea
            aparut2 = true;
        }
    }
    //parte 1
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void mana()
    {
        pp.SetActive(true);
        txt.GetComponent<Animation>().Play("pop");
        FindObjectOfType<AudioManager>().Play("tutorial");
        Invoke("inchide", 9);
    }
    //subprogram opreste canvasul si Sunetul
    void inchide()
    {
        pp.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("tutorial");
    }
    //subprogram care activeaza obiectul de tip canvas si de tip text , activand animatia
    //cauta Audiomanagerul si activeaza Sunetul respectiv
    void pickup()
    {
        pick.SetActive(true);
        dial.GetComponent<Animation>().Play("dial");
        FindObjectOfType<AudioManager>().Play("tut2");
        //comenzile de delay cu numele subprogramelor respective
        Invoke("spawn", 2);
        Invoke("gata", 9.5f);
    }
    //dezactiveaza sunetul si canvasul
    void gata()
    {
        pick.SetActive(false);
        FindObjectOfType<AudioManager>().Stop("tut2");
    }
    //Spawneaza un block rosu pe harta 
    void spawn()
    {
        blockrosu.SetActive(true);
    }     
}
