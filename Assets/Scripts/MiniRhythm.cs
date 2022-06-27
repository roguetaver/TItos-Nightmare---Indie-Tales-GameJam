using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniRhythm : MinigameManager
{

    public bool missed;

    public float noteSpeed;



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        fail = false;

        if (gm.points < 10)
        {
            noteSpeed = 2f;
        }
        else
        {
            noteSpeed = 3.3f;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (missed)
        {
            LooseCall();
        }

    }
}
