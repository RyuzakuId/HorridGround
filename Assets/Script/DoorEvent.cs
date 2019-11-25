using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{    
    public bool doorEvent = false;
    [SerializeField] GameObject pintu;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            doorEvent = true;
            pintu.SetActive(false);
        }
    }

} // Class
