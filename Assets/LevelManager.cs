using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCall(){
        StartCoroutine(Play());
    }
    private IEnumerator Play(){
        fade.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Game");
    }

    public void MenuCall(){
        StartCoroutine(Menu());
    }
    private IEnumerator Menu(){
        fade.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(0);
    }
    public void CreditsCall(){
        StartCoroutine(Credits());
    }
    private IEnumerator Credits(){
        fade.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Credits");
    }

    public void DefeatCall(){
        StartCoroutine(Defeat());
    }
    private IEnumerator Defeat(){
        fade.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Defeat");
    }

    public void Quit(){
        Application.Quit();
    }
}
