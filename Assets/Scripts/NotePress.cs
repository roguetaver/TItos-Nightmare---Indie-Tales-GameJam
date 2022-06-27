using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePress : MonoBehaviour
{
    public bool canBePressed;
    
    private float runSpeed;

    public KeyCode keyToPress;
    public LayerMask wallMask;

    public GameObject[] miniGameScripts;
    public GameObject miniGameScript;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        miniGameScripts = GameObject.FindGameObjectsWithTag("rhythmScript");
        miniGameScript = miniGameScripts[0];
        runSpeed = miniGameScript.GetComponent<MiniRhythm>().noteSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(-runSpeed, 0f);

        if (Input.GetKeyDown(keyToPress)){
            if (canBePressed)
            {
                Destroy(gameObject);
            }
            else
            {
                miniGameScript.GetComponent<MiniRhythm>().missed = true;
                print("errou");
            }
        }
        if(Input.anyKey && !(Input.GetMouseButton(0)|| Input.GetMouseButton(1) || Input.GetMouseButton(2) || Input.GetKeyDown(keyToPress)))
        {
            miniGameScript.GetComponent<MiniRhythm>().missed = true;
            print("errou");
        }
        
        

        Collider2D[] colliders_obstacle = Physics2D.OverlapCircleAll(transform.position, 0.2f, wallMask);

        if (colliders_obstacle.Length > 0)
        {
            miniGameScript.GetComponent<MiniRhythm>().missed = true;
            print("errou");
            Destroy(gameObject);
            

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NoteActivator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NoteActivator")
        {
            canBePressed = false;
        }
    }

}
