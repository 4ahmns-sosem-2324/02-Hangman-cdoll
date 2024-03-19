using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HangmanManager : MonoBehaviour
{
    public TextMeshProUGUI guessedWordText;
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI remainingAttemptsText;
    public string[] words;
    public int maxAttempts = 6;
    public GameObject Retry;

    private string secretWord;
    private string guessedWord;
    private List<char> guessedLetters;
    private int remainingAttempts;

    public SpriteRenderer[] hangman;
    

    void Start()
    {
        guessedLetters = new List<char>();
        remainingAttempts = maxAttempts;
        ChooseRandomWord();
        guessedWord = new string('-', secretWord.Length);
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Exit game on Escape key
        {
            Application.Quit();
        }

        if (Input.anyKeyDown && Input.inputString.Length > 0 && char.IsLetter(Input.inputString[0])) // Check for letter input
        {
            char guessedLetter = char.ToUpper(Input.inputString[0]);
            if (!guessedLetters.Contains(guessedLetter))
            {
                guessedLetters.Add(guessedLetter);
                CheckLetter(guessedLetter);
            }
        }

        if (guessedWord == secretWord)
        {
            infoText.text = "You Win!";
        }
        else if (remainingAttempts <= 0)
        {
            infoText.text = "You Lose! The word was: " + secretWord;
        }

        if (remainingAttempts == 9)
        {
            hangman[0].enabled = true;
        }
        else if (remainingAttempts == 8)
        {
            hangman[1].enabled = true;
        }
        else if (remainingAttempts == 7)
        {
            hangman[2].enabled = true;
        }
        else if (remainingAttempts == 6)
        {
            hangman[3].enabled = true;
        }
        else if (remainingAttempts == 5)
        {
            hangman[4].enabled = true;
        }
        else if (remainingAttempts == 4)
        {
            hangman[5].enabled = true;
        }
        else if (remainingAttempts == 3)
        {
            hangman[6].enabled = true;
        }
        else if (remainingAttempts == 2)
        {
            hangman[7].enabled = true;
        }
        else if (remainingAttempts == 1)
        {
            hangman[8].enabled = true;
        }
        else if (remainingAttempts == 0)
        {
            hangman[9].enabled = true;
            Retry.SetActive(true);
           
        }
    }

    public void RetryButton()
    {
        
        SceneManager.LoadScene(0);
    }

    void ChooseRandomWord()
    {
        secretWord = words[Random.Range(0, words.Length)].ToUpper();
    }

    void CheckLetter(char letter)
    {
        bool found = false;
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guessedWord = guessedWord.Substring(0, i) + letter + guessedWord.Substring(i + 1);
                found = true;
            }
        }

        if (!found)
        {
            remainingAttempts--;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        guessedWordText.text = guessedWord;
        remainingAttemptsText.text = "Attempts Remaining: " + remainingAttempts;
    }
}
