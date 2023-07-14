using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int pos;

    public GameObject[] sprites;

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
        if(pos != 2)
        {
            sprites[pos++].SetActive(false);
            sprites[pos].SetActive(true);
        }
    }

    public void goDown()
    {
        if (pos != 0)
        {
            sprites[pos--].SetActive(false);
            sprites[pos].SetActive(true);
        }
    }
}
