using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;

namespace app.Gameplay {
    /// <summary>
    /// Game over when ball falls down,
    /// Crush threats
    /// </summary>
    public class DeathZone : MonoBehaviour {

        private GameStateController _gameStateControleller;

        private void Start() {
            _gameStateControleller = FindObjectOfType<GameStateController>();
        }

        /// <summary>
        /// End the game is tha ball falls down
        /// </summary>
        /// <param name="collision">the object, this object collided with</param>
        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Ball") {
                _gameStateControleller.EndGame();
            }
        }
    }
}
