using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
    [SerializeField]
    private Text _highScoreText = null;
    [SerializeField]
    private Text _lastScoreText = null;

    private void Start() {
        SetHighScoreUI();
        SetLastScoreUI();
    }

    private void SetLastScoreUI() {
        _lastScoreText.text = PlayerPrefs.GetInt("LastScore", 0).ToString();
    }

    private void SetHighScoreUI() {
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
