using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class easter : MonoBehaviour
{//creare variabile , folosita dupa si Transformarea , care ajuta la schimbarea pozitiei
    public bool petre = false;
    public Transform destin;
    //subprogram care se activeaza cand dai click
    void OnMouseDown()
    {
        //variabila devine adevarata
        petre = true;
        //se cauta componenta din rigidbody si se dezactiveaza gravitatie 
        //se blocheaza rotatia si miscarea obiectului
        //iar colliderul , pentru mesh se dezactiveaza
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().isKinematic = true;
        //se trimite obiectul pe care este scriptul in pozitia in care am setat destinatia
        this.transform.position = destin.position;
        //obiectul cu scriptul devine un 'Child' al Obiectului"Obiect"care ii devine "Parent"
        //"Parent" insemnand parinte, adica un obiect mai mare , din care face parte
        //spre exemplu daca bagi un text intr-un panou, acesta devine automat 'Child', Iar panoul 'Parent'
        this.transform.parent = GameObject.Find("Obiect").transform;

    }
    //subprogram care se activeaza cand ridici clickul
    void OnMouseUp()
    {//variabila devine falsa
        petre = false;
        //obiectul isi pierde tagul de 'Child' 
        this.transform.parent = null;
        //Se activeaza gravitatia si colliderul la obiect
        //Se deblocheaza rotatia si miscarea obiectului
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<Rigidbody>().freezeRotation = false ;
        GetComponent<Rigidbody>().isKinematic = false ;
    }
}
