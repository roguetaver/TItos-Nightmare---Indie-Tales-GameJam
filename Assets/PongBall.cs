using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    float waitTime;
    float startWaitTime;
    bool launch;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        startWaitTime = 0.8f;
        waitTime = startWaitTime;
        launch = false;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if(waitTime <= 0 && !launch)
        {
            Launch();
            launch = true;
        }
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(gameObject);
        }
    }
}
