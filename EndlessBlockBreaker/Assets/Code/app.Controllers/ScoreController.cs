using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace app.Controllers {
    /// <summary>
    /// Controlls player's score
    /// </summary>
    public class ScoreController : MonoBehaviour {

        [Header("GameObjects")]
        [SerializeField]
        private Text _scoreText = null;
        private GameStateController _gameStateController = null;

        public int Score { get; set; }

        private void Start() {
            _gameStateController = FindObjectOfType<GameStateController>();
            SetupScoreUI();
        }

        /// <summary>
        /// Update score UI with score to add
        /// </summary>
        /// <param name="scoreToAdd">Score to add to player's score</param>
        public void UpdateScore(int scoreToAdd) {
            if (_gameStateController.IsGameOn) {
                Score += scoreToAdd;
                _scoreText.text = Score.ToString();
            }
        }

        /// <summary>
        /// Save player's highscore in playerprefs
        /// </summary>
        public void SaveHighScoreAndLastScore() {
            PlayerPrefs.SetInt("LastScore", Score);
            if(Score > PlayerPrefs.GetInt("HighScore", 0)) {
                PlayerPrefs.SetInt("HighScore", Score);
            }
        }

        /// <summary>
        /// Setup score UI to be equal to 0
        /// </summary>
        private void SetupScoreUI() {
            Score = 0;
            _scoreText.text = Score.ToString();
        }
    }
}
