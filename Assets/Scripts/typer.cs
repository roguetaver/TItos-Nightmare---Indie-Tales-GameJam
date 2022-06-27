using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typer : MinigameManager
{


    private List<string> originalWords;

    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    int index;



    private void setCurrentWord()
    {      
        setRemainingWord(currentWord);
    }

    private void setRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
       
        if(gm.points < 10)
        {
          originalWords = new List<string>()
          {
                "tito","dark","night","scary","dream","fear"
          };
        }
        else
        {
          originalWords = new List<string>()
          {
                "monster","nightmare","bedroom","crayons","dangerous"
          };
        }

        index = Random.Range(0, originalWords.Count);
        currentWord = originalWords[index];
        setCurrentWord();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter (string typedLetter)
    {
        if (isCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (isWordComplete())
            {
                WinCall();
            }
        }
    }

    private bool isCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0,1);
        setRemainingWord(newString);
    }

    private bool isWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
