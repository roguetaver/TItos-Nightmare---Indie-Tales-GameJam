using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //float maxY = 4.5f;
    //float minY = -4.5f;
    //float maxX = 8.5f;
    //float minX = -8.5f;
    float maxY = 6f;
    float minY = -6f;
    float maxX = 10f;
    float minX = -10f;
    float startEnemyCooldown;
    float enemyCooldown;

    GameManager gm;

    public int fase;
    private int lado;

    public GameObject[] enemy;

    void spawnRight(int n)
    {
        for(int i = 0; i < n; i++)
        {
            var position = new Vector3(maxX,Random.Range(minY, maxY),0);
            Instantiate(enemy[Random.Range(0,enemy.Length)], position, Quaternion.identity);
        }      
    }

    void spawnLeft(int n)
    {
        for (int i = 0; i < n; i++)
        {
            var position = new Vector3(minX,Random.Range(minY, maxY),0);
            Instantiate(enemy[Random.Range(0,enemy.Length)], position, Quaternion.identity);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        startEnemyCooldown = 4f;
        enemyCooldown = startEnemyCooldown;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        fase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.points <= 2)
        {
            fase = 1;
        }
        else if(2 < gm.points && gm.points <= 6)
        {
            fase = 2;
        }
        else if (6 < gm.points && gm.points <= 12)
        {
            fase = 3;
        }
        else if (12 < gm.points && gm.points <= 17)
        {
            fase = 4;
        }
        else if (17 < gm.points && gm.points <= 20)
        {
            fase = 5;
        }
        // 1 inimigo a cada 9 seg
        if (fase == 1)
        {
            startEnemyCooldown = 9f;
            enemyCooldown -= Time.deltaTime;
            if (enemyCooldown <= 0)
            {
                lado = Random.Range(1, 3);
                if (lado == 1)
                {
                    spawnLeft(1);
                }
                else if (lado == 2)
                {
                    spawnRight(1);
                }
                enemyCooldown = startEnemyCooldown;
            }
               
        }
        //2 inimigos a cada 3 seg
        else if(fase == 2)
        {
            startEnemyCooldown = 3.5f;
            enemyCooldown -= Time.deltaTime;
            if (enemyCooldown <= 0)
            {
                lado = Random.Range(0, 3);
                spawnLeft(lado);

                spawnRight(2 - lado);
               
                enemyCooldown = startEnemyCooldown;
            }
        }
        //3 inimigos a cada 3 seg
        else if (fase == 3)
        {
            startEnemyCooldown = 4f;
            enemyCooldown -= Time.deltaTime;
            if (enemyCooldown <= 0)
            {
                lado = Random.Range(0, 4);
                spawnLeft(lado);

                spawnRight(3 - lado);
                enemyCooldown = startEnemyCooldown;
            }
        }
        //2 inimigos a cada 2 segundos
        else if (fase == 4)
        {
            startEnemyCooldown = 2f;
            enemyCooldown -= Time.deltaTime;
            if (enemyCooldown <= 0)
            {
                lado = Random.Range(0, 3);
                spawnLeft(lado);

                spawnRight(2 - lado);
                enemyCooldown = startEnemyCooldown;
            }
        }
        //3 inimigos a cada 1.25 seg
        else if (fase == 5)
        {
            startEnemyCooldown = 1.25f;
            enemyCooldown -= Time.deltaTime;
            if (enemyCooldown <= 0)
            {
                lado = Random.Range(0, 4);
                spawnLeft(lado);

                spawnRight(3 - lado);
                enemyCooldown = startEnemyCooldown;
            }
        }


    }
}
