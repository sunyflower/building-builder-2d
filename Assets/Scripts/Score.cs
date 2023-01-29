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

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    //dodawanie punktu
    public void AddScore()
    {
        scoreValue++;
        score.text = "" + scoreValue;
    }
}
