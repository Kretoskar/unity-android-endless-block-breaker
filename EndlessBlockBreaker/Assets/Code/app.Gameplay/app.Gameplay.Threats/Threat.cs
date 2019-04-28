using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;

namespace app.Gameplay.Threats {
    /// <summary>
    /// Base class for all the threats
    /// </summary>
    public abstract class Threat : MonoBehaviour {
        [Header("Variables")]
        [SerializeField]
        protected int _score;
        [SerializeField]
        protected int _speed;

        protected ScoreController _scoreController = null;

        /// <summary>
        /// Add player score after death
        /// </summary>
        protected void AddScore() {
            _scoreController.UpdateScore(_score);
        }

        /// <summary>
        /// Move after spawn
        /// </summary>
        protected abstract void Move();

        /// <summary>
        /// Behaviour when threat is killed
        /// </summary>
        protected abstract void Die();
    }
}
