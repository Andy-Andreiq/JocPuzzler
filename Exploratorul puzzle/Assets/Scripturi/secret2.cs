using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nume script
public class secret2 : MonoBehaviour
{//variabila care transforma pozitia
    //variabile de tip obiecte
    //variabile folosite pentri verificare
    public Transform destin;
    public GameObject canvas;
    public GameObject text;
    private bool gata = false;
    //Subprogram predefinit care actioneaza la click
    void OnMouseDown()
    {//cauta componenta "Rigidbody" a obiectului pe care se afla scriptul si dezactiveaza gravitatia
        //Cauta componenta Mesh-ului Colliderului  si o dezactiveaza. 
        //cauta componenta obiectului si blocheaza rotatia
        //transforma pozitia obiectului la "Obiect" si il face 'Child'
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        this.transform.position = destin.position;
        this.transform.parent = GameObject.Find("Obiect").transform;
        //se salveaza in baza de date ca secretul a fost descoperit
        SaveManager.instance.secret22 = true;
        SaveManager.instance.Save();
        //comanda de delay , cu numele subprogramului respectiv
        Invoke("papa", 4);
        //conditie care activeaza comanda de delay 
        if (gata == false)
        {
            Invoke("mere", 1);
        }
    }
    //subprogram care distruge obiectul cu scriptul
    void papa()
    {
        Destroy(gameObject);
    }
    //subprogram care dezactiveaza canvasul
    void gg()
    {
        canvas.SetActive(false);
    }
    //subprogram care activeaza canvasul, activeaza animatia textului
    //transforma variabila gata adevarata, pentru a nu se putea repeta campul
    
    void mere()
    {
        canvas.SetActive(true);
        text.GetComponent<Animation>().Play("aparities");
        gata = true;
        //comanda folosita pentru delay pentru subprogramul respectiv
        Invoke("gg", 3);
    }
}
