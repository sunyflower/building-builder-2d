using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int scoreValue = 0;
    TMP_Text score;

    private void Awake()
    {
        Instance = this;
    }


    //przypisanie komponentu tekstu do zmiennej score
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }


    //dodawanie punktu, bierze inta i transformuje w text
    public void AddScore()
    {
        scoreValue++;
        score.text = scoreValue.ToString();
    }
}
