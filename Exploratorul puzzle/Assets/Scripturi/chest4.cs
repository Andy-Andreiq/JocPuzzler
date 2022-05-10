//Acelasi proces ca la Sciptul pentru activarea loading screenului ,doar cu numele scriptului schimbat(nivel4) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'lvl4'
//variabilele realizeaza aceleasi actiuni , singura diferenta fiind variabila din SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class chest4 : MonoBehaviour
{
    public bool iese4 = false;
    public GameObject obiect;
    public bool apare4 = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
    private void OnTriggerEnter(Collider other)
    {
        iese4 = true;
    }
    private void OnTriggerExit(Collider other)
    {
        iese4 = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown("e") && iese4 == true)
        {
            AudioListener.volume = 0f;
            obiect.GetComponent<Animation>().Play("spin");
            SaveManager.instance.lvl4 = true;
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
