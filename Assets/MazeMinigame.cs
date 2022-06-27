using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMinigame : MinigameManager
{
    public GameObject[] maze;
    protected override void Start(){
        base.Start();
        if(gm.points < 10)
        {
            maze[0].SetActive(true);
        }
        else
        {
            maze[1].SetActive(true);
        }
    }
    protected override void Update(){
        base.Update();
    }
}
