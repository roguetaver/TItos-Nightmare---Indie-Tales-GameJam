using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontDestroyOnLoad : MonoBehaviour
{

    public static AudioSource m_AudioSource;
    public AudioMixer mixer;


    private void Start()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(0.1f) * 20);
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);


        m_AudioSource = GetComponent<AudioSource>();

        
    }
    public static void pause()
    {
        m_AudioSource.Pause();
    }
    public static void play()
    {
        m_AudioSource.Play();
    }

}
