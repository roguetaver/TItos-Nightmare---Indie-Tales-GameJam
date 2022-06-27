using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPong : MinigameManager
{

    private GameObject pongGoal;
    private GameObject paddle;
    private GameObject ball;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        pongGoal = GameObject.Find("Goal");
        fail = false;

        paddle = GameObject.Find("Paddle");
        ball = GameObject.Find("ball");

        if (gm.points <= 10)
        {
            Vector3 scale = new Vector3(0.45f, paddle.transform.localScale.y, paddle.transform.localScale.z);
            paddle.transform.localScale = scale;
            ball.GetComponent<PongBall>().speed = 2f;
        }
        else
        {
            Vector3 scale = new Vector3(0.35f, paddle.transform.localScale.y, paddle.transform.localScale.z);
            paddle.transform.localScale = scale;
            ball.GetComponent<PongBall>().speed = 3f;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        

        

        if (pongGoal.GetComponent<PongGoal>().defeat)
        {
            fail = true;
            LooseCall();
        }
    }
}
