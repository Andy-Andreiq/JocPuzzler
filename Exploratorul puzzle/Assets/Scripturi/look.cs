using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    public float senzitivitate = 100f;

    public Transform corp;

    float Rotatiex = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float coordx = Input.GetAxis("Mouse X") * senzitivitate * Time.deltaTime;
        float coordy = Input.GetAxis("Mouse Y") * senzitivitate * Time.deltaTime;

        Rotatiex -= coordy;
        Rotatiex = Mathf.Clamp(Rotatiex, -75f, 75f);

        transform.localRotation = Quaternion.Euler(Rotatiex, 0f, 0f);

        corp.Rotate(Vector3.up * coordx);
    }
}
