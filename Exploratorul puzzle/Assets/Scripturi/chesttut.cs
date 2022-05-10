
//Acelasi proces ca la Sciptul pentru activarea loading screenului de la (nivel 3)
//doar cu numele scriptului schimbat(chesttut) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'tut'
//variabilele realizeaza aceleasi actiuni , singurele diferenta fiind variabila din SaveManager
//si conditia ca in scriptul PickUp , cu variabila bs, cheie sa fie adevarata
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chesttut : MonoBehaviour
{
    private bool iese1 = false;
    private bool odata = false;
    public GameObject obiect;
    public PickUp bs;
    public Text pro;
    public Slider loadin;
    public GameObject loadingscreen;
    private void OnTriggerEnter(Collider other)
    {
        iese1 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese1 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese1 == true && bs.cheie == true && odata == false)
        {
            odata = true;
            AudioListener.volume = 0f;
            SaveManager.instance.tut = true;
            SaveManager.instance.Save();
            StartCoroutine(incarca());
        }
    }

    IEnumerator incarca()
    {
       
            AsyncOperation operatiune = SceneManager.LoadSceneAsync(1);

            loadingscreen.SetActive(true);

            while (operatiune.isDone == false)
            {
                float progres = Mathf.Clamp01(operatiune.progress / 0.9f);

                loadin.value = progres;
            pro.text = Mathf.Round(progres * 100f).ToString() + "%";


            yield return null;

            }
        
    }
}
