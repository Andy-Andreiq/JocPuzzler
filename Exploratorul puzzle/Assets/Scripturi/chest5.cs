//Script pentru activarea loading screenului la fiecare nivel (nivel 4)


//Acelasi proces ca la Sciptul pentru activarea loading screenului de la (nivel 3)
//doar cu numele scriptului schimbat(nivel5) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'lvl5'
//variabilele realizeaza aceleasi actiuni , singura diferenta fiind variabila din SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class chest5 : MonoBehaviour
{
    public bool iese5 = false;
    public GameObject obiect;
    public bool apare5 = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    private void OnTriggerEnter(Collider other)
    {
        iese5 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese5 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese5 == true && apare5 == false)
        {
            AudioListener.volume = 0f;
            obiect.GetComponent<Animation>().Play("spin");
            SaveManager.instance.lvl5 = true;
            SaveManager.instance.Save();
            apare5 = true;
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
