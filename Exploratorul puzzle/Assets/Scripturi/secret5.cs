using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret5 : MonoBehaviour
{//variabile folosite pentru verificare si de tip obiect
    private bool apasat = false;
    private bool ini = false;
    public GameObject text;
    public GameObject canv;
    //verificare daca exista coliziune cu un collider
    private void OnTriggerEnter(Collider other)
    {
        ini = true;
    }
    private void OnTriggerExit(Collider other)
    {
        ini = false;
    }

    void Update()
    {//conditii, daca 'e' este apasat, variabila apasat este false
        //apasas fiind o variabila care realizeaza decat o data actiunea
        //si exista coliziune
        if (Input.GetKeyDown("e") && apasat == false && ini == true)
        {//se salveaza completarea secretului 5
            SaveManager.instance.secret5 = true;
            SaveManager.instance.Save();
            //se activeaza canvasul
            canv.SetActive(true);
            //se cauta si se activeaza componenta animation
            text.GetComponent<Animation>().Play("hehe");
            //se foloseste comanda pentru delay cu numele subprogramului respectiv
            Invoke("mana", 2);
            //variabila devine adevarata pentru a stope reluarea actiunii
            apasat = true;
        }
    }
    //subprogram care dezactiveaza canvasul(element UI)
    void mana()
    {
        canv.SetActive(false);
    }
}
