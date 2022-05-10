using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa1 : MonoBehaviour
{
    public bool placaJ = false;
    public float pozX;
    public float pozZ;
    public float pozY;

    public Transform Potiune1;
    

    string nume = "Potiune_Mov";
    /// <------------------------------------> ANIMATIE PENTRU POTIUNEA MOV <-------------------------------> \\\
    private void Start()
    {
        RandomPoz();
        Potiune1.transform.position = new Vector3(pozX, pozY, pozZ);     
        transform.position = new Vector3(-7.38f, 0.55f, 18.5f);
    } 
  
        private void OnTriggerEnter(Collider other)
        {
        
        if (other.gameObject.name == nume)
        
        {
            FindObjectOfType<AudioManager>().Play("button");
            transform.position = new Vector3(-7.38f, 0.44f, 18.5f);
            SaveManager.instance.placa1 = true;
            SaveManager.instance.Save();
            placaJ = true;
           
        }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Potiune")
            {
            FindObjectOfType<AudioManager>().Stop("button");
            transform.position = new Vector3(-7.38f, 0.55f, 18.5f);
            SaveManager.instance.placa1 = false ;
            SaveManager.instance.Save();

            placaJ = false;
            }
        }

    public void RandomPoz()
    {
        int Rand = Random.Range(1, 3);
        if (Rand == 1)
        {
            pozX = -15.03f;
            pozY = 1.12f;
            pozZ = 15.9f;
        }
        else if (Rand == 2)
        {
            pozX = -20.4f;
            pozY = 0.92f;
            pozZ = -5.97f;
        }
        else if (Rand == 3)
        {
            pozX = 6.62f;
            pozY = 0.92f;
            pozZ = -7.49f;
        }

        
    }


}
