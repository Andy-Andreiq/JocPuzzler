using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptText : MonoBehaviour
{
    public GameObject canvas;
    public GameObject text;

    bool apare = false;



    void Update()
    {  if (apare == false)

            canvas.SetActive(true);
        text.GetComponent<Animation>().Play("lvl2");
        Invoke("SPP", 3);
        apare = true;
    }

    void SPP()
    {
        apare = true;
       canvas.SetActive(false);

    }
}
