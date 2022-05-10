using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class intralvl1 : MonoBehaviour
{//variabile de verificare , si setare obiecte pentru loadingscreen
    //setare text si setare slider
    private bool wai = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //vatiabila verifica daca exista coliziune
    private void OnTriggerEnter(Collider other)
    {
        wai = true;
    }
    private void OnTriggerExit(Collider other)
    {
        wai = false;
    }

    private void Update()
    {//conditii, daca exista coliziune si apesi 'e'
        if (Input.GetKeyDown("e") && wai == true)
        {//volumul AudioListener-ului se seteaza la 0 si incepe corutina
            AudioListener.volume = 0f;
            StartCoroutine(incarca());
        }
    }
    IEnumerator incarca()
    {
        //comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
        //incarca actionand pe fundal
        //operatiune folosita pentru schimbarea de scene 
        //fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(2);
        //activeaza variabila de loading screen(canvas)
        loadingscreen.SetActive(true);
        //cat timp operatiunea nu este terminata 
        while (operatiune.isDone == false)
        {//creeaza o variabila progres care realizeaza calcule matematice, cu raspunsul intre 0 si 1
            //progresul actiunii fiin impartit la 0.9, pentru a da rezultate inclusiv cu 1
            float progres = Mathf.Clamp01(operatiune.progress / 0.9f);
            //sliderul ia valoarea progresului, schimbandu-se in functie de el
            loadin.value = progres;
            //textul realizeaza un calcul matematic , care rotunjeste progresul
            //il inmulteste cu 100 pentru ca progresul sa fie intre 0% si 100%
            //Transforma variabila in data de tip String si adauga semnul"%"
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";

            //returneaza argumentul null
            yield return null;

        }

    }
}
