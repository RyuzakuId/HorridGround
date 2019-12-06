using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelController : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] GameObject wall;
    bool isPanelPushed = false;
    [SerializeField] Text pc;


    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPanelPushed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isPanelPushed = false;
    }

    void Update()
    {
        if (isPanelPushed)
        {
            DestroyWall();
        }
    }

    void DestroyWall()
    {
        Destroy(wall);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Debug.Log(gameObject.name + " is Destroyed.");
        if (pc != null)
            pc.enabled = !pc.enabled;
    }
}
