//Folosirea Engine-ului de UI si Scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//nume script
public class chest3 : MonoBehaviour
{//variabile de verificare,variabile pentru obiecte din scena (canvas,etc.)
    //variabile pentru text si pentru slider;
    private bool iese3 = false;
    public GameObject obiect;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    //verificare daca te afli in collider
    private void OnTriggerEnter(Collider other)
    {
        iese3 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese3 = false;
    }

    private void Update()
    {
        //conditie , daca apesi 'e' si esti in collider
        if (Input.GetKeyDown("e") && iese3 == true)
        {//se seteaza volumul la 0 al componentei audiolistener
            //(componenta predefinita pentru receptarea sunetului)
            AudioListener.volume = 0f;
            //activarea animatiei obiectului respectiv
            obiect.GetComponent<Animation>().Play("spin");
            //Salvare in SaveManager a variabilei lvl3(inregistrata in baza de date)
            SaveManager.instance.lvl3 = true;
            SaveManager.instance.Save();
            //inceperea unei actiuni a unui subprogram nou
            StartCoroutine(incarca());
        }
    }
    //subprogram care te lasa sa iteratezi prin lista de controale
    IEnumerator incarca()
    {
//comanda predefinita care creeaza o variabila ce face asincron operatiunea cu derularea jocului
//incarca actionand pe fundal
//operatiune folosita pentru schimbarea de scene 
//fiind setata la indexul din Built 
        AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);
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
