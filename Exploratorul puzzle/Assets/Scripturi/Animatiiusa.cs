using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class Animatiiusa : MonoBehaviour
{
    // declarare variabile atribuite
    public GameObject usa;
    // face referinta la o componenta dintr-un alt script al altui obiect
    public PickUp bS;
    public Transform player;
    public Transform usatr;
    private bool razwan = false;
    public GameObject can;
    public GameObject text;
    private bool cabum = false;
    //Camp predefinit Unity care Updateaza constant actiunea
    void Update()
    {//conditie pentru activarea mai multor componente , in cazul in care apesi "e"
        // variabilele bs.cheie care reprezinta o componenta a scriptului PickUp
        // care inregistreaza daca ai o cheie in mana
        //razwan care reprezinta variabila care inregistreaza daca te afli intr-un BoxCollider de tip trigger
        //si cabum care reprezinta stagiul usi (daca e sau nu deschisa)
        if (Input.GetKey("e") && bS.cheie == true && razwan == true && cabum == false)
        {//in obiectul usa , cauta componenta animatii si o activeaza(deschidere)
                usa.GetComponent<Animation>().Play("Door_Open");
            //cauta AudioManagerul(un obiect) si ii da comanda de Play(care activeaza sunetul cu numele respectiv)
            FindObjectOfType<AudioManager>().Play("open");
            //foloseste Comanda predefinita de delay pe subprogramele "canta" si "inchisa"atribuindu-le un timp
            Invoke("Canta", 3);
            Invoke("inchisa", 20);
            //activeaza cabum, variabila care arata ca e deschisa
            cabum = true;
            
        }
        //conditie care se activeaza in cazul in care cheia lipseste(cheie este falsa)
        if(Input.GetKey("e") && bS.cheie == false && razwan == true)
        {
            //in obiectul usa cauta componenta animatie si o activeaza(blocare)
            usa.GetComponent<Animation>().Play("Door_Jam");
            //cauta un obiect AudioManager si ii da comanda Play ( care activeaza sunetul cu numele respectiv)
            FindObjectOfType<AudioManager>().Play("gem");
            //activeaza obiectul, care in cazul nostru este un canvas(Element UI)
            can.SetActive(true);
            //Ia componenta animatie din obiectul text si o activeaza;
           text.GetComponent<Animation>().Play("carton");
            //foloseste comanda predefinita pentru delay pe subprogramul dispare(3 secunde)
            Invoke("dispare", 3);
        }
    }
    //Verificare daca playerul este in Collider, razwan devine adevarata daca esti in Collider falsa daca iesi.
    private void OnTriggerEnter(Collider other)
    {
        razwan = true;
    }
    private void OnTriggerExit(Collider other)
    {
        razwan = false;
    }
    //subprogram care activeaza in AudioManager sunetul Cu numele respectiv
    void Canta()
    {
        
        FindObjectOfType<AudioManager>().Play("comoara");
    }
    //subprogram care dezactiveaza obiectul (canvasul)
    void dispare()
    {
        can.SetActive(false);
    }
    // Subprogram care activeaza Componenta usii, animatie, care inchide usa
    void inchisa()
    {
        usa.GetComponent<Animation>().Play("Door_Close");
        Invoke("bam", 2);
    }
    //subprogram care activeaza din nou usa
    void bam()
    {
        cabum = false;
    }        
        
}
