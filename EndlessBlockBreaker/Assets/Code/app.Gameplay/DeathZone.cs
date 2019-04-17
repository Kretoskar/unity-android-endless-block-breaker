﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;

namespace app.Gameplay {
    public class DeathZone : MonoBehaviour {

        private GameStateController _gameStateControleller;

        private void Start() {
            _gameStateControleller = FindObjectOfType<GameStateController>();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Ball") {
                _gameStateControleller.EndGame();
            }
        }
    }
}