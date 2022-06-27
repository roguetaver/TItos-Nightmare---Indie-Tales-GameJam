using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJumpObstacle : MonoBehaviour
{

    Rigidbody2D body;
    private float runSpeed;
    public LayerMask wallMask;

    public GameObject[] miniGameScripts;
    public GameObject miniGameScript;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        miniGameScripts = GameObject.FindGameObjectsWithTag("jumpScript");
        miniGameScript = miniGameScripts[0];
        runSpeed = miniGameScript.GetComponent<MiniGameJump>().speed;
    
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(runSpeed, 0f);

        Collider2D[] colliders_obstacle = Physics2D.OverlapCircleAll(transform.position, 0.2f, wallMask);

        if (colliders_obstacle.Length > 0)
        {
            Destroy(gameObject);
        }
    }
}
