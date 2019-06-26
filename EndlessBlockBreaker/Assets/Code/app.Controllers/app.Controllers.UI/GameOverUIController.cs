using CloudOnce;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace app.Controllers.UI {
    /// <summary>
    /// Handles GameOver Scene UI
    /// </summary>
    public class GameOverUIController : MonoBehaviour {
        [Header("GameObjects")]
        [SerializeField]
        private Text _highScoreText = null;
        [SerializeField]
        private Text _lastScoreText = null;

        private void Start() {
            SetHighScoreUI();
            SetLastScoreUI();

            //Cloud.OnInitializeComplete += CloudOnceInitializedComplete;
            //Cloud.Initialize(false, true);
            SaveLeaderboardScore();
        }

        //public void CloudOnceInitializedComplete() {
          //  Cloud.OnInitializeComplete -= CloudOnceInitializedComplete;
          //  print("Initialized");
        //}

        public void SaveLeaderboardScore() {
            Leaderboards.PongstacheHighScore.SubmitScore(PlayerPrefs.GetInt("HighScore", 0));
        }

        /// <summary>
        /// Set last score Text to be equal to playerpref's LastScore
        /// </summary>
        private void SetLastScoreUI() {
            _lastScoreText.text = PlayerPrefs.GetInt("LastScore", 0).ToString();
        }

        /// <summary>
        /// Set high score Text to be equal to playerpref's HighScore
        /// </summary>
        private void SetHighScoreUI() {
            _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }
}
