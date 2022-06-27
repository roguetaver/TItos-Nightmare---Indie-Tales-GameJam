using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider progressSlider;
    public MinigameManager mgm;

    public GameObject[] GMs;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        progressSlider = gameObject.GetComponent<Slider>();
        GMs = GameObject.FindGameObjectsWithTag("GM");
        GM = GMs[0];
        progressSlider.value = GM.GetComponent<GameManager>().points;
    }

    // Update is called once per frame
    void Update()
    {
        progressSlider.value = GM.GetComponent<GameManager>().points;
    }
}
