using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsText : MonoBehaviour
{
    Text pointsText;
    public MinigameManager mgm;
    void Start()
    {
        pointsText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        pointsText.text = mgm.points.ToString();
    }
}
