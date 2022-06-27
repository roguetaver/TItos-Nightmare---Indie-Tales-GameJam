using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private float speed = 2.0f;
    private Vector2 target;
    private Vector2 position;

    public LayerMask wallMask;
    public LayerMask spikeMask;
    Ray ray;
    RaycastHit hit;
    GameManager gm;
    public GameObject particles;
    AudioClip hitClip;
    private GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        hitClip =(AudioClip) Resources.Load("Hit");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        Collider2D[] colliders_obstacle = Physics2D.OverlapCircleAll(transform.position, 0.3f, wallMask);

        if (colliders_obstacle.Length > 0)
        {
            gm.TakeDamage();
            Destroy(gameObject);
        }

        Collider2D[] spike_obstacle = Physics2D.OverlapCircleAll(transform.position, 0.3f, spikeMask);

        if (spike_obstacle.Length > 0)
        {
            AudioSource.PlayClipAtPoint(hitClip, new Vector3(0, 0, 0));
            Destroy(spike_obstacle[0].gameObject);
            DestroyEnemy();

        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject == this.gameObject){
                    DestroyEnemy();
                }   
            }
        }
    }
    public void DestroyEnemy(){
        GameObject part = Instantiate(particles, transform);
        part.transform.SetParent(null);
        gm.AddCoin();
        cam.GetComponent<Animator>().SetTrigger("Shake");
        Destroy(gameObject);
    }
    
}
