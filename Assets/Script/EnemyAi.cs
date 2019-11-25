using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAi : MonoBehaviour
{
    public Transform player;
    //[SerializeField] AudioSource music;
    Timer timer;
    [SerializeField] GameObject pintu;
    GameControl gc;

    NavMeshAgent enemyAI;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        gc = FindObjectOfType<GameControl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<NavMeshAgent>();
        enemyAI.speed = 18f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAI.SetDestination(player.position);
        enemyAI.speed += 0.1f * Time.deltaTime;
        FaceTarget();

        if (timer.currentTime < 0.5f)
        {
            Destroy(gameObject);
            gc.eventId += 1;
            pintu.SetActive(true);
            //music.enabled = !music.enabled;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
