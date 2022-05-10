//Acelasi proces ca la Sciptul pentru activarea loading screenului de la (nivel 3)
//doar cu numele scriptului schimbat(chestsmech) si
//Datele din SaveManager, inlocuind variabila 'lvl3' cu 'lvl1'
//variabilele realizeaza aceleasi actiuni , singura diferenta fiind variabila din SaveManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class chestsmech : MonoBehaviour
{
    public bool iese1 = false;
    public GameObject obiect;
    public bool apare = false;
    public GameObject loadingscreen;
    public Text pro;
    public Slider loadin;
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

        if (Input.GetKeyDown("e") && iese1 == true)
        {
            obiect.GetComponent<Animation>().Play("spin");
            AudioListener.volume = 0f;
            SaveManager.instance.lvl1 = true;
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
