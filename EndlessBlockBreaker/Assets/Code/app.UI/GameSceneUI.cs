using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using app.Controllers;

namespace app.UI {
    /// <summary>
    /// Handles GameScene UI
    /// </summary>
    public class GameSceneUI : MonoBehaviour {
        [SerializeField]
        private Text _currHealthText = null;
        [SerializeField]
        private Text _maxHealthText = null;

        private LivesController _livesController;

        private void Start() {
            _livesController = FindObjectOfType<LivesController>();
        }

        /// <summary>
        /// Set the curr health text
        /// </summary>
        public void SetupCurrHealthText() {
            _currHealthText.text = _livesController.CurrLives.ToString();
        }

        /// <summary>
        /// Set the max health text
        /// </summary>
        public void SetupMaxHealthText() {
            _maxHealthText.text = _livesController.MaxLives.ToString();
        }
    }
}
