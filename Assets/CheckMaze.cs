using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMaze : MonoBehaviour
{
    public MinigameManager mgm;
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        if (other.gameObject.name == "Target"){
            mgm.WinCall();
        }
    }
}
