using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    DoorEvent gameEvent;
    public int eventId;
    [SerializeField] GameObject enemy;
    //[SerializeField] GameObject player;
    [SerializeField] GameObject timer;
    //AudioSource music;
    public bool gameStart = false;
    static AudioClip bgm, chasing;
    AudioSource ads;


    void Awake()
    {
        bgm = Resources.Load<AudioClip>("bgmPlay");
        chasing = Resources.Load<AudioClip>("chasing");
        ads = GetComponent<AudioSource>();
        ads.clip = bgm;
    }

    void Start()
    {
        gameEvent = FindObjectOfType<DoorEvent>();
        //music = player.GetComponent<AudioSource>();
        eventId = 0;
        ads.Play();
    }

    void Update()
    {
        if (gameEvent.doorEvent)
        {
            EventStart(eventId);
            gameEvent.doorEvent = false;
        }

        if (eventId == 1){
            eventId++;
            ads.clip = chasing;
            ads.Play();
        }

        if (eventId == 3) {
            eventId++;
            ads.clip = bgm;
            ads.Play();
        } 
    }

    void EventStart(int id)
    {
        if (eventId == 0)
        {
            GameStart();
            eventId += 1;
        }

        if(eventId == 4) OpeningDoor();
    }

    void GameStart()
    {
        enemy.SetActive(true);
        timer.SetActive(true);
        //music.enabled = !music.enabled;
        gameStart = true;
    }

    void OpeningDoor()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Win");
    }
}
