using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//nume script
public class ChestDesert : MonoBehaviour
{// variabile pentru verificare, obiect pentru canvasul loadingscreenului
    //pentru text, pentru slider si pentru cufar
    public bool iese = false;
    public bool apare = false;
    private bool odata = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    public GameObject chest;
    private float pozx = -12.849f;
    private float pozy = -7.29f;
    private float pozz = 20.22f;
    //subprogram care verifica daca te afli in collider
    private void OnTriggerEnter(Collider other)
    {
        iese = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese = false;
    }

    private void Update()
    {//conditie care verifica in SaveManager daca variabilele placa1,2,3,4,5 sunt adevarata, variabile folosite
        //pentru activarea permanenta a chestului
        if (SaveManager.instance.placa1 == true && SaveManager.instance.placa2 == true && SaveManager.instance.placa3 == true && SaveManager.instance.placa4 == true && SaveManager.instance.placa5 == true && odata == false)
        {//activarea chestului si transformarea pozitie lui si folosirea variabilei"odata" o singura data
            chest.transform.position = new Vector3(pozx, pozy, pozz);
            odata = true;
        }
        //conditie pentru apasarea tastei 'e' si dacate afli in collider
        if (Input.GetKeyDown("e") && iese == true)
        {//setarea volumul din audiolistener la 0 , componenta predefinita pentru inregistrare sunete
            AudioListener.volume = 0f;
            //salvarea completarii nivelului 2
            SaveManager.instance.lvl2 = true;
            SaveManager.instance.Save();
            //inceperea Corutinei incarca
            StartCoroutine(incarca());
        }
    }
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

