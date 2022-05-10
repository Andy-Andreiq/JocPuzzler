using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class distrugere : MonoBehaviour
{ //variabile pentru verificare , pentru referinta la script extern is pentru obiecte
    public GameObject nasa;
    public GameObject perete;   
    private bool nic;
    public easter mm;
    private bool pietre;
    //subprogram pentru verificarea activitatii colliderului
    private void OnTriggerEnter(Collider other)
    {
        nic = true;
    }
    private void OnTriggerExit(Collider other)
    {
        nic = false;
    }

    void Update()
    {//conditie daca apesi 'f' si 'petre' este adevarat in scriptul extern si colliderul e adevarat
        if(Input.GetKeyDown("f") && mm.petre == true && nic ==true)
        {//in obiectul perete cauta animation cu numele de "New Animation"
            perete.GetComponent<Animation>().Play("New Animation");
            //variabila petre devine adevarata
            pietre = true;
            //cauta obiectul AudioManager si opreste muzica
                FindObjectOfType<AudioManager>().Stop("padure");
            //seteaza rotatia elementului care creeaza lumina , pentru a realiza un efect de noapte
            nasa.transform.rotation = Quaternion.Euler(-67.399f,620.278f,-408.156f);
        }
    }
}

