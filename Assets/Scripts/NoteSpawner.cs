using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    public GameObject[] Notes;
    public float startCoolDown;
    private float cooldown;
    private GameObject currentNote;
    int index;
    public int numberOfNotes;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0 && numberOfNotes > 0)
        {
            var position = new Vector3(1.6f, -0.65f, 0);
            index = Random.Range(0,Notes.Length);
            currentNote = Notes[index];
            GameObject obst = Instantiate(currentNote, position, Quaternion.identity);
            obst.transform.SetParent(transform.parent);
            cooldown = startCoolDown;
            numberOfNotes--;
        }
    }
}
