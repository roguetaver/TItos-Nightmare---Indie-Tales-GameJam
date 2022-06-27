using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstacaoCheck : MonoBehaviour
{
    int minigameNum;
    public GameObject[] minigames;
    public bool isOn;
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player" && isOn){
            OpenMini();
        }
    }
    public void CheckPlayer(){
        if (Physics2D.OverlapCircle(gameObject.transform.position, .3f, playerLayer)){
            OpenMini();
        }
    }

    public void OpenMini(){
        if(gameObject.transform.parent.gameObject.GetComponent<EtacoesScript>().miniNum<minigames.Length){
            Instantiate(minigames[gameObject.transform.parent.gameObject.GetComponent<EtacoesScript>().miniNum], Vector2.zero, Quaternion.identity);
            gameObject.transform.parent.gameObject.GetComponent<EtacoesScript>().miniNum ++;
        }else{
            Instantiate(minigames[Random.Range(0, minigames.Length)], Vector2.zero, Quaternion.identity);   
        }
        isOn = false;
        gameObject.GetComponent<Animator>().SetTrigger("Fade");
        gameObject.transform.parent.gameObject.GetComponent<EtacoesScript>().isOn = false;
        gameObject.transform.parent.gameObject.GetComponent<EtacoesScript>().timerBlink = 0;
        gameObject.transform.parent.gameObject.GetComponent<EtacoesScript>().timeToMinigame = Random.Range(2f,5f);
    }
}
