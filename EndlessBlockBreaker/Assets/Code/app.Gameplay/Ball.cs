using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;

namespace app.Gameplay {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour {

        [Header("Push on click force")]
        [SerializeField]
        private float _XPush = 0f;
        [SerializeField]
        private float _YPush = 2f;

        private Paddle _paddle;
        private GameStateController _gameStateController;
        private Rigidbody2D _ballRigidbody = null;

        private Vector2 _paddleToBallVector;

        private void Start() {
            _paddle = FindObjectOfType<Paddle>();
            _gameStateController = FindObjectOfType<GameStateController>();

            _ballRigidbody = GetComponent<Rigidbody2D>();

            _paddleToBallVector = transform.position - _paddle.transform.position;
        }

        private void Update() {
            if (!_gameStateController.IsGameOn)
                StickBallToPaddle();
        }

        private void StickBallToPaddle() {
            Vector2 paddlePos = _paddle.transform.position;
            transform.position = paddlePos + _paddleToBallVector;
        }

        // called by Paddle class
        public void LaunchTheBall() {
            if (!_gameStateController.IsGameOn) {
                _ballRigidbody.velocity = new Vector2(_XPush, _YPush);
                _gameStateController.IsGameOn = true;
            }
        }
    }
}
