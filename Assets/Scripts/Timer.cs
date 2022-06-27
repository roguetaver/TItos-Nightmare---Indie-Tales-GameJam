using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Slider timerSlider;
    public MinigameManager mgm;
    void Start()
    {
        timerSlider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        timerSlider.value = mgm.timer;
    }
}
