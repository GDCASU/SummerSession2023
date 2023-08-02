using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    public void UpdateScore(int score)
    {
        Debug.Log("here");
        scoreText.text = score.ToString();
    }
}
