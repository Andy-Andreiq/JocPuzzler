using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class startullabaiat : MonoBehaviour
{//variabile de tip obiect si pentru verificare
    public GameObject canvas;
    public GameObject text;
    private bool merge = false;
    //subprogram care activeaza obiectul de ti canvas
    //cauta si activeaza componenta Animation a textului
    
    void mana ()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("start2");
        //comanda de delay cu numele subprogramului respectiv
        Invoke("stop", 3);
    }
    //subprogram care dezactiveaza canvasul
    void stop()
    {
        canvas.SetActive(false);
    }
    //metoda care verifica conditia , invoke subprogramul mana si transforma variabila de verificat adevarata
    //variabila este transformata pentru a impiedica repetarea procesului de catre metoda
    private void Update()
    {
        if (merge == false)
        {
            Invoke("mana", 1);
            merge = true;
        }
    }
}
