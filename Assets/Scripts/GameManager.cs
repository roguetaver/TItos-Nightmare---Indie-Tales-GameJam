using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int points;
    public int lives;
    public int coins;
    public Text coinsText;

    public bool isOnMinigame;

    public Image[] hearts;
    public GameObject[] heartsParticles;


    public LevelManager levelManager;
    public AudioClip hitClip;
    public AudioClip lifeUpClip;

    void Start()
    {
        coins = 0;
        points = 0;
        lives = 3;
    }

    public void AddCoin(){
        coins += 1;
        coinsText.text = coins.ToString();
    }
    public void AddPoint(){
        points += 1;
        if(points >= 20){
            Cursor.visible = true;
            levelManager.CreditsCall();
        }
    }
    public void TakeDamage(){
        lives -= 1;
        AudioSource.PlayClipAtPoint(hitClip, new Vector3(0, 0, 0));
        if (lives <= 0){
            Cursor.visible = true;
            levelManager.DefeatCall();
        }
        UpdateLive();
    }
    public void AddLife(){
        lives += 1;
        AudioSource.PlayClipAtPoint(lifeUpClip, new Vector3(0, 0, 0));
        UpdateLive();
    }
    public void UpdateLive(){
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i<lives){
                hearts[i].enabled = true;
            }else{
                if (hearts[i].enabled == true){
                    heartsParticles[i].GetComponent<ParticleSystem>().Clear();
                    heartsParticles[i].GetComponent<ParticleSystem>().Play();
                }
                hearts[i].enabled = false;
            }
        }
    }
}
