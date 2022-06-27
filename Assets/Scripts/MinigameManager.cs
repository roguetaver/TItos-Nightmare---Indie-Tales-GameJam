using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public bool fail;
    private bool isOver;
    public float timer;
    public int points;
    public GameManager gm;

    GameObject room;
    GameObject player;

    public AudioClip victory;
    public AudioClip loose;
    public GameObject happyFace;
    public GameObject sadFace;

    protected virtual void Start()
    {
        room = GameObject.Find("Room");
        room.SetActive(false);
        player = GameObject.Find("Player");
        player.SetActive(false);
        fail = true;
        timer = 7f;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.isOnMinigame = true;

    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            if (fail && !isOver){
                AudioSource.PlayClipAtPoint(loose, new Vector3(0, 0, 0));
                player.SetActive(true);
                room.SetActive(true);
                gm.isOnMinigame = false;
                Destroy(gameObject);
            }else if(!isOver){
                AudioSource.PlayClipAtPoint(victory, new Vector3(0, 0, 0));
                player.SetActive(true);
                room.SetActive(true);
                gm.isOnMinigame = false;
                gm.AddPoint();
                Destroy(gameObject);
            }
        }
    }
    protected void LooseCall(){
        if (!isOver){
            StartCoroutine(Loose());
        }
    }
    public void WinCall(){
        if (!isOver){
            StartCoroutine(Win());
        }
    }
    private IEnumerator Loose(){
        isOver=true;
        AudioSource.PlayClipAtPoint(loose, new Vector3(0, 0, 0));
        yield return new WaitForSeconds(1);
        player.SetActive(true);
        room.SetActive(true);
        gm.isOnMinigame = false;
        Destroy(gameObject);
    }
    private IEnumerator Win(){
        isOver=true;
        AudioSource.PlayClipAtPoint(victory, new Vector3(0, 0, 0));
        gm.AddPoint();
        yield return new WaitForSeconds(1);
        player.SetActive(true);
        room.SetActive(true);
        gm.isOnMinigame = false;
        Destroy(gameObject);
    }
}
