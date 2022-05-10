using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class erupe : MonoBehaviour
{//variabile pentru referinta la scriptul buton , obiect, si pentru verificare
    public Buton adv;
    private bool fost = false;
    public bool cometa = false;
    public GameObject sfera;
    void Update()
    {//conditii , daca in scriptul buton apasat este adevarat si fost e adevarat
        //fost fiind o variabila pentru verificarea si realizarea o singura data a actiunii
        if(adv.apasat == true && fost == false)
        {//comanda de delay pentru subprogramul 'erupere' (3 secunde)
            Invoke("erupere", 3);
            //variabila fost devine adevarata
            fost = true;
        }

    }
    //subprogram pentru eruperea vulcanului care activeaza variabila cometa folosita intru-un alt script
    //Se cauta componenta animation si se activeaza animatia cu numele corespunzator
    //se activeaza animatia obiectului 'sfera' prin gasirea componentei
    //se activeaza sunetul cu numele respectiv , prin gasirea obiectului AudioManager
    void erupere()
    {
        cometa = true;
        GetComponent<Animation>().Play("vulcan");
        sfera.GetComponent<Animation>().Play("nou");
        FindObjectOfType<AudioManager>().Play("explozie");
    }
}
