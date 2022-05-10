using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//nume script
public class des : MonoBehaviour
{//definire variabila verificare , diferite obiecte (canvas, obiecte scena),transform player
    //folosit pentru transformarea pozitiei playerului
    public GameObject usa;
    public Transform player;
    private bool razwan = false;
    public GameObject req;
    public GameObject text;
    public GameObject sfarsit;
    public GameObject audem;
    public GameObject pauza;

    void Update()
    {//conditii, daca apesi 'e' si te afli in collider si nivelul 5 este completat
        if (Input.GetKey("e") && razwan == true && SaveManager.instance.lvl5 == true)
        {//dezactivare sistem pauza
            pauza.SetActive(false);
            //deschiderea usii folosing animatia
            usa.GetComponent<Animation>().Play("Door_Open");
            //oprirea tuturor sunetelor posibile
            audem.GetComponent<AudioManager>().Stop("Meniu");
            audem.GetComponent<AudioManager>().Stop("doom");
            audem.GetComponent<AudioManager>().Stop("ultiamte");
            //folosirea comenzii pentru delay cu , utilizand subprogramu hai ( in 1.5 secunde)
            Invoke("hai", 1.5f);
        }
        //conditie daca apesi e , si daca esti in collider , dar nivelul 5 nu e completat
        if (Input.GetKey("e") && razwan == true && SaveManager.instance.lvl5 == false)
        {//se activeaza animatia dupa cautarea componentei usa
            usa.GetComponent<Animation>().Play("Door_Jam");
            //se activeaza un canvas(element UI)
            req.SetActive(true);
            //se cauta componenta animatie in text si se activeaza
            text.GetComponent<Animation>().Play("dur");
            //se foloseste comanda de delay , pentru subprogramu 'gata'(3 secunde)
            Invoke("gata", 3);
        }
    }
    //subprogram predefinit care verifica statutul coliderului
    private void OnTriggerEnter(Collider other)
    {
        razwan = true;
    }
    private void OnTriggerExit(Collider other)
    {
        razwan = false;
    }
    //subprogram care dezactiveaza un canvas
    void gata()
    {
        req.SetActive(false);
    }
    //subprogram care activeaza canvasul de sfarsit,opreste timpul,deblocheaza si face vizibil cursorul
    //Ia componenta AudioManager si activeaza muzica de Sfarsit
void hai()
    {
        sfarsit.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audem.GetComponent<AudioManager>().Play("sfarsit");
    }
}
