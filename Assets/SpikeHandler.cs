using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHandler : MonoBehaviour
{
    public Vector3 mousePos;
    public GameObject spike;
    public GameObject spikeTemp;
    GameObject gobj;
    public bool bought;
    public bool placed;
    public bool inHand;

    // Start is called before the first frame update
    void Start()
    {
        placed = true;
        inHand = false;

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        if (bought)
        {
            gobj = Instantiate(spikeTemp, mousePos, Quaternion.identity);
            bought = false;
            placed = false;
            inHand = true;
        }

        if (Input.GetMouseButtonDown(0) && !placed)
        {
            if (mousePos.x > 3 || mousePos.x < -3) // || mousePos.y > 2.5 || mousePos.y < -2.5
            {
                Destroy(gobj);
                Instantiate(spike, mousePos, Quaternion.identity);
                placed = true;
                inHand = false;
            }
            else
            {
                print("erro");
            }
        }
    }
}
