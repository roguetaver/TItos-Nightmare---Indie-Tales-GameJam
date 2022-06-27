using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreManager : MonoBehaviour
{
    RaycastHit hit;
    private GameManager gm;
    public AudioClip coinClip;
    public GameObject[] Turrets;
    private int TurretsCount;
    private int turretsPrice;
    public Text turretText;
    private GameObject SpikeHandler;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        foreach (Transform child in transform){
            child.gameObject.SetActive(false);
        }
        TurretsCount = - 1;
        turretsPrice = 60;
        turretText.text = turretsPrice.ToString();
        SpikeHandler = GameObject.Find("SpikeHandler");
    }
    private void Update() {
        foreach (Transform child in transform){
            if(child.gameObject.name == "TurretIcon"){
                if(gm.coins >= turretsPrice && TurretsCount < Turrets.Length - 1)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }else{
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
            if(child.gameObject.name == "HeartIcon"){
                if (gm.lives < 3 && gm.coins >= 30){
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }else{
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
            if(child.gameObject.name == "ShieldIcon"){
                if(gm.coins >= 10 && !SpikeHandler.GetComponent<SpikeHandler>().inHand){
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }else{
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name == "TurretIcon" && TurretsCount < Turrets.Length -1 && gm.coins >= turretsPrice)
                {
                    AudioSource.PlayClipAtPoint(coinClip, new Vector3(0, 0, 0));
                    TurretsCount++;
                    Turrets[TurretsCount].SetActive(true);
                    gm.coins -= 60+10*(TurretsCount);
                    gm.coinsText.text = gm.coins.ToString();
                    turretsPrice = 60+10*(TurretsCount+1);
                    turretText.text = turretsPrice.ToString();
                    if(TurretsCount == Turrets.Length-1){
                        turretText.text = "Sold";
                    }
                }
                if(hit.collider.gameObject.name == "HeartIcon" && gm.lives < 3 && gm.coins >= 30){
                    gm.coins -= 30;
                    gm.coinsText.text = gm.coins.ToString();
                    gm.AddLife();
                }
                if(hit.collider.gameObject.name == "ShieldIcon" && gm.coins >= 10 && !SpikeHandler.GetComponent<SpikeHandler>().inHand)
                {
                    AudioSource.PlayClipAtPoint(coinClip, new Vector3(0, 0, 0));
                    gm.coins -= 10;
                    gm.coinsText.text = gm.coins.ToString();
                    GameObject.Find("SpikeHandler").GetComponent<SpikeHandler>().bought = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player"){
            foreach (Transform child in transform){
                child.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Player"){
            foreach (Transform child in transform){
                child.gameObject.SetActive(false);
            }
        }
    }
}
