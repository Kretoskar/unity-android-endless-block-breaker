using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace app.Controllers {
    public class ScoreController : MonoBehaviour {

        [SerializeField]
        private Text _scoreText = null;

        public int Score { get; set; }

        private void Start() {
            Score = 0;
            UpdateScore(Score);
        }

        /// <summary>
        /// Update score UI with score to add
        /// </summary>
        /// <param name="scoreToAdd">Score to add to player's score</param>
        public void UpdateScore(int scoreToAdd) {
            Score += scoreToAdd;
            _scoreText.text = Score.ToString();
        }
    }
}
