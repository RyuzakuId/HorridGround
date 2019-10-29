using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilang : MonoBehaviour
{
    public GameObject hilang, muncul;

    public void buttonHilang()
    {
        hilang.SetActive(false);
        muncul.SetActive(true);
    }
}
