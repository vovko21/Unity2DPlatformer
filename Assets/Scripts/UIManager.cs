using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Update()
    {
        ChangeText();
    }

    public void ChangeText()
    {
        scoreText.text = "Cherries: " + ScoreController.Score;
    }
}
