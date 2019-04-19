using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Gameplay.Threats {
    /// <summary>
    /// Base class for all the threats
    /// </summary>
    public abstract class Threat : MonoBehaviour {
        [SerializeField]
        protected int _score;
        [SerializeField]
        protected int _speed;

        /// <summary>
        /// Add player score after death
        /// </summary>
        protected void AddScore() {
            print(_score);
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
