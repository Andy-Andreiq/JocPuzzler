using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class mega : MonoBehaviour
{//setare variabilelor de tip float cu roll de coordonate
    //setare variabilelor de tip obiecte pentru folosire
    //setarea variabilelor pentru verificare
    public GameObject podea;
    private bool es = false;
    public GameObject player;
    private float pozx = -0.48f;
    private float pozy = 4.98f;
    private float pozz = -46.35f;
    public GameObject audem;
    private bool odata = false;
    //subprogram variabila verifica coliziunea in Collider
    private void OnTriggerEnter(Collider other)
    {
        es = true;
    }
    private void OnTriggerExit(Collider other)
    {
        es = false;
    }
    private void Update()
    {//Conditii, daca apesi tasta 'e' si esti variabila de coliziune este adevarata si toate secretele au fost descoperite
        //si variabila odata (verifica si face actiune o singura data) este falsa
        if (Input.GetKeyDown("e") && es == true && odata == false && SaveManager.instance.secret22 == true && SaveManager.instance.secret3 == true && SaveManager.instance.secret4 == true && SaveManager.instance.secret5 == true)
        {//variabila devine adevarata,Se gaseste componenta BoxCollider al obiectului podea si devine trigger
       
            odata = true;
            podea.GetComponent<BoxCollider>().isTrigger = true;
            //se opresc toate sunetele posibile prin referinta la AudioManager
            audem.GetComponent<AudioManager>().Stop("Meniu");
            audem.GetComponent<AudioManager>().Stop("doom");
            audem.GetComponent<AudioManager>().Stop("ultimate");
            //Se activeaza Din Componenta Audiomanager Muzica cu numele respectiv
            audem.GetComponent<AudioManager>().Play("ricardo");
            //se foloseste comanda de delay pentru un subprogram separat
        }
        //Conditii, daca BoxColliderul obiectului podea este trigger si apesi tasta 'f'
        if (podea.GetComponent<BoxCollider>().isTrigger == true && Input.GetKeyDown("f"))
        {//BoxColliderul obiectului dezactiveaza triggerul si Playerul este transportat la coordonatele anterioare
            podea.GetComponent<BoxCollider>().isTrigger = false;
            player.transform.position = new Vector3(pozx, pozy, pozz);
            //Din Componenta AudioManager se opreste muzica respectiva , si se porneste muzica de meniu
            audem.GetComponent<AudioManager>().Stop("ricardo");
            audem.GetComponent<AudioManager>().Play("Meniu");
            //reactivarea variabilei pentru a putea reintra
            odata = false;
        }
    }

}
