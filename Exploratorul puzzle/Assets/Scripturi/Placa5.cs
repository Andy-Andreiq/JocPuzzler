using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa5 : MonoBehaviour
{
    public bool placaJ = false;

    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune5;



    string nume = "Potiune_Gri";
    private void Start()
    {
        RandomPoz();
        Potiune5.transform.position = new Vector3(pozX, pozY, pozZ);
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == nume)
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-1.587f, 0.44f, 18.5f);
            SaveManager.instance.placa5 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
        {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-1.587f, 0.55f, 18.5f);
            SaveManager.instance.placa5 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }
    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = 8.91f;
            pozY = 0.96f;
            pozZ = 20.014f;
        }
        else if (Rand == 2)
        {
            pozX = 7.363f;
            pozY = 2.95f;
            pozZ = 20.27f;
        }
        else if (Rand == 3)
        {
            pozX = -0.15f;
            pozY = 0.98f;
            pozZ = 25.87f;
        }
 

    }

}
