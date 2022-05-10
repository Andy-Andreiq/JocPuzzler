using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa4 : MonoBehaviour
{

    public float pozZ;
    public float pozX;
    public float pozY;

    public Transform Potiune4;


    public bool placaJ = false;
    

    private void Start()
    {
        RandomPoz();
        Potiune4.transform.position = new Vector3(pozX, pozY, pozZ);
        transform.position = new Vector3(-3.099f, 0.55f, 18.5f);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Potiune_Albastra")
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-3.099f, 0.44f, 18.5f);
            SaveManager.instance.placa4 = true;
            SaveManager.instance.Save();

            placaJ = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Potiune")
        {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-3.099f, 0.55f, 18.5f);

            SaveManager.instance.placa4 = false;
            SaveManager.instance.Save();
            placaJ = false;
        }
    }

    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -3.02f;
            pozY = 0.97f;
            pozZ = -8.15f;
        }
        else if (Rand == 2)
        {
            pozX = 12.55f;
            pozY = 0.97f;
            pozZ = -8.15f;
        }
        else if (Rand == 3)
        {
            pozX = 9.964f;
            pozY = 1.932f;
            pozZ = -19.415f;
        }
     

    }
}
