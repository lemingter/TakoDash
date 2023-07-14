using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - (Time.deltaTime * speed), transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreController scoreController = FindObjectOfType<ScoreController>();
        
        if (collision.tag == "Player")
        {
            scoreController.increaseScore();
            FindObjectOfType<GameController>().HitCookie();
        }
        else if (collision.tag == "End")
        {
            scoreController.breakCombo();
        }
        else
        {
            return;
        }

        Destroy(gameObject);
    }
}
