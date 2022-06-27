using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameJump : MinigameManager
{

    public float cooldown;
    public float speed;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        fail = false;
        //seta cooldown e speed dos obstaculos
        

        if (gm.points < 10)
        {
            cooldown = 3f;
            speed = -3f;
        }
        else
        {
            cooldown = 1.5f;
            speed = -3f;
        }

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (JumpPlayerMIni.defeat)
        {
            LooseCall();
            fail = true;   
        }

        

        

    }
}
