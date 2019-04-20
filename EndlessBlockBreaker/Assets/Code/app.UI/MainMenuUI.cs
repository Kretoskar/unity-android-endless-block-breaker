using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace app.UI { 
    public class MainMenuUI : MonoBehaviour{
        [SerializeField]
        private Text _highScoreText = null;

        private void Start() {
            SetHighScoreUI();
        }

        private void SetHighScoreUI() {
            _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }
}
