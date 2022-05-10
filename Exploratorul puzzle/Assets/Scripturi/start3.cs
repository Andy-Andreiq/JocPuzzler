using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class start3 : MonoBehaviour
{//variabile de tip obiecte si pentru verificare
    public GameObject canvas;
    public GameObject text;
    private bool afost= false;

    private void Update()
    {//conditie, variabila este utilizata doar o singura data,aceasta fiin falsa
        if (afost == false)
        {//comanda de delay cu nume subprogramului respectiv
            Invoke("canva", 2);
        }
    }
    //subprogram utilizat pentru activarea obiectului de tip canvas
    //cautarea si activarea componentei de tip animation a textului
    //transformarea variabilei , in adevarata
    //invokarea subprogramului cu numele respectiv
void canva()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("animeisan");
        afost = true;
        Invoke("ies", 3);
    }
    //sugprogram care dezactiveaza obiectul de tip canvas
    void ies()
    {
        canvas.SetActive(false);
    }
}
