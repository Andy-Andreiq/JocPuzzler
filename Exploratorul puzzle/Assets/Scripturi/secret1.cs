using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret1 : MonoBehaviour
{//variabile de verificare si variabile de tip obiect(canvas & text)
    private bool mere = false;
    private bool odata = false;
    public GameObject text;
    public GameObject can;
//variabila care verifica daca exista coliziune , in collider
    private void OnTriggerEnter(Collider other)
    {
        mere = true;
    }
    private void OnTriggerExit(Collider other)
    {
        mere = false;
    }
    private void Update()
    {//conditii, care verifica daca actiunea a fost facuta si daca , colliderul e activ
        if (mere == true && odata == false)
        {//instanta secret1 , se salveaza in Baza de Date 
            SaveManager.instance.secret1 = true;
            SaveManager.instance.Save();
            //comanda de delay utilizata pentru subprogramul respectiv
            Invoke("papa", 4);
            //variabila care realizeaza actiunea isi schimba valoarea pentru a nu se incepe iar actiunea
            odata = true;
            //canvasul este activat , iar in obiectul text se cauta componenta animatie , care se activeaza
            can.SetActive(true);
            text.GetComponent<Animation>().Play("glow");
        }
    }

    
    //script care distruge obiectul pe care se afla scriptul si care dezactiveaza canvasul
void papa()
    {
        Destroy(gameObject);
        can.SetActive(false);
    }
}
