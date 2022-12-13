using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int pos;

    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            goUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            goDown();
        }
    }

    public void goUp()
    {
        if(pos > 0)
        {
            pos--;

            transform.position = new Vector3(-7, spawnPoints[pos].transform.position.y, 0);
        }
    }

    public void goDown()
    {
        if(pos + 1 < spawnPoints.Length)
        {
            pos++;

            transform.position = new Vector3(-7, spawnPoints[pos].transform.position.y, 0);
        }
    }
}
