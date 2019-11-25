using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float currentTime;
    [SerializeField] float startingTime;

    [SerializeField] Text timer;

    GameControl gc;

    void Start()
    {
        currentTime = startingTime;
        gc = FindObjectOfType<GameControl>();
    }

    void Update()
    {
        if (currentTime > 0 && gc.gameStart) {
            currentTime -= 1 * Time.deltaTime;
            timer.text = currentTime.ToString("00");
        }
    }
}
