using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtacoesScript : MonoBehaviour
{
    public float timer;
    public float timerBlink;
    public float timeToMinigame;
    public int estNum;
    public bool isOn;
    GameManager gm;
    public int miniNum;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        timer = 0;
        timeToMinigame = Random.Range(2f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOn && !gm.isOnMinigame){
            timer += Time.deltaTime;
            if(timer >= timeToMinigame){
                estNum = Random.Range(0,4);
                gameObject.transform.GetChild(estNum).gameObject.GetComponent<Animator>().SetTrigger("Blink");
                gameObject.transform.GetChild(estNum).gameObject.GetComponent<EstacaoCheck>().isOn = true;
                isOn = true;
                timer = 0;
                gameObject.transform.GetChild(estNum).gameObject.GetComponent<EstacaoCheck>().CheckPlayer();
            }
        }
        else if (!gm.isOnMinigame){
            timerBlink += Time.deltaTime;
            if (timerBlink >= 4){
                gameObject.transform.GetChild(estNum).gameObject.GetComponent<Animator>().SetTrigger("Fade");
                gameObject.transform.GetChild(estNum).gameObject.GetComponent<EstacaoCheck>().isOn = false;
                isOn = false;
                timerBlink = 0;
                timeToMinigame = Random.Range(2f,5f);
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawSphere(gameObject.transform.GetChild(estNum).transform.position, .3f);
    }
}
