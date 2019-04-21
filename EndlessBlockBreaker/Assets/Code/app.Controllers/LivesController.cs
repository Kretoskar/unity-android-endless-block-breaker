using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers.UI;

namespace app.Controllers {
    /// <summary>
    /// Controls maximum and current lives of the player
    /// Has methods for both adding and substracting player's live
    /// </summary>
    public class LivesController : MonoBehaviour {
        [SerializeField]
        private int _maxLives = 3;
        [SerializeField]
        private GameStateController _gameStateController = null;
        [SerializeField]
        private GameSceneUI _gameSceneUI = null;

        public int CurrLives { get; set; }

        public int MaxLives { get { return _maxLives; } }

        private void Start() {
            CurrLives = _maxLives;
        }

        /// <summary>
        /// Add lives to current player's lives
        /// </summary>
        /// <param name="livesToAdd">How much lives to add</param>
        public void AddLives(int livesToAdd) {
            CurrLives += livesToAdd;
            _gameSceneUI.SetupCurrHealthText();
            if (CurrLives >= _maxLives)
                CurrLives = _maxLives;
        }

        /// <summary>
        /// Subtract lives from player's current lives
        /// </summary>
        /// <param name="livesToSubstract">How much lives to subtract</param>
        public void SubtractLives(int livesToSubstract) {
            CurrLives -= livesToSubstract;
            _gameSceneUI.SetupCurrHealthText();
            if (CurrLives <= 0) {
                CurrLives = 0;
                _gameStateController.EndGame();
            }
        }
    }
}
