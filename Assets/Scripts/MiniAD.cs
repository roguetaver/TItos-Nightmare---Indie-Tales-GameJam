using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAD : MinigameManager
{

    public bool a = false;
    protected override void Start() {
        base.Start();

        if(gm.points < 10)
        {
            points = 35;
        }
        else
        {
            points = 55;
        }
    }

    protected override void Update() {
        base.Update();
        if (Input.GetKeyDown(KeyCode.A) && a && points>0){
            points--;
            a = false;
        }
        if (Input.GetKeyDown(KeyCode.D) && !a && points>0){
            points--;
            a = true;
        }
        if (points <= 0){
            WinCall();
        }
    }
}
