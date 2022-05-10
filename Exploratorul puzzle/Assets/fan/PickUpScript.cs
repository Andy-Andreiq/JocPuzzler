using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
   
    public Transform Destinatie;
    

    private void OnMouseDown()
    {
          GetComponent<MeshCollider>().enabled = true;
          GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = Destinatie.position;
        this.transform.parent = GameObject.Find("Obiect").transform;
    }

    private void OnMouseUp()
    {   
        GetComponent<MeshCollider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().isKinematic = false ;


    }
}
