using System.Collections;
using System.Collections.Generic;
using CloudOnce;
using UnityEngine;
using UnityEngine.UI;

namespace app.Controllers.UI { 
    /// <summary>
    /// Handles MainMenu scene UI
    /// </summary>
    public class MainMenuUIController : MonoBehaviour{
        [Header("GameObjects")]
        [SerializeField]
        private Text _highScoreText = null;

        private void Start() {
            SetHighScoreUI();

            Cloud.OnInitializeComplete += CloudOnceInitializedComplete;
            Cloud.Initialize(false, true);
        }

        public void CloudOnceInitializedComplete() {
            Cloud.OnInitializeComplete -= CloudOnceInitializedComplete;
            print("Initialized");
        }

        /// <summary>
        /// Set the highscore text to be equal to  playerpref's HighScore
        /// </summary>
        private void SetHighScoreUI() {
            _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }
}
