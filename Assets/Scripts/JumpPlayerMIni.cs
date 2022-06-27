using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerMIni : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 4.0f;
    public LayerMask deathMask;

    public static bool defeat;

    public bool isGrounded;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.5f, 0.0f);
        isGrounded = false;
        defeat = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            print("pulo");
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        Collider2D[] colliders_obstacle = Physics2D.OverlapCircleAll(transform.position, 0.4f, deathMask);

        if (colliders_obstacle.Length > 0)
        {
            defeat = true;
            Destroy(gameObject);
        }
    }
}
