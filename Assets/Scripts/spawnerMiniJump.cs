using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerMiniJump : MonoBehaviour
{
    public GameObject Obstacle;
    private float startCoolDown;
    private float cooldown;

    public GameObject[] miniGameScripts;
    public GameObject miniGameScript;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1f;
        miniGameScripts = GameObject.FindGameObjectsWithTag("jumpScript");
        miniGameScript = miniGameScripts[0];
        startCoolDown = miniGameScript.GetComponent<MiniGameJump>().cooldown;
        print(startCoolDown);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(cooldown <= 0)
        {
            var position = new Vector3(1.9f, -1f, 0);
            GameObject obst = Instantiate(Obstacle, position, Quaternion.identity);
            obst.transform.SetParent(transform.parent);
            cooldown = startCoolDown;
        }
    }
}
