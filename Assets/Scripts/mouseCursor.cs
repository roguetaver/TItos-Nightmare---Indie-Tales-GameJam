using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public GameObject particles;
    public AudioClip shotClip;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            GameObject part = Instantiate(particles, transform);
            AudioSource.PlayClipAtPoint(shotClip, new Vector3(0, 0, 0));
            part.transform.SetParent(null);

        }
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;   
    }
}
