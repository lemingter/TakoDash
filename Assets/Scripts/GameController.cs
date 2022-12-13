using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cookie;
    public GameObject[] spawnPoints;

    private float spawnTimer;
    public float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = timeToSpawn;
            Instantiate(cookie, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, new Quaternion());
        }
    }
}
