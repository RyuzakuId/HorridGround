using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopClue : MonoBehaviour
{
    Text pc;
    float wt = 0f;

    void Awake()
    {
        pc = GetComponentInChildren<Text>();
    }

    void FixedUpdate()
    {
        if (pc.enabled)
        {
            if(wt > 15f || PauseScript.isPaused)
            {
                pc.enabled = !pc.enabled;
                wt = 0f;
            }
            wt += 0.1f;
        }
    }
}
