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

        [Header("Other settings")]
        [SerializeField]
        private float _randomFactor = .2f;
        [SerializeField]
        private float _randomFactorAfterHittingPaddle = 3f;

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

        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Paddle") {
                TweakMovementAfterCollisionWithPaddle();
            } else {
                RandomizeMovementAfterCollision();
            }

        }

        private void TweakMovementAfterCollisionWithPaddle() {
            float xTweak = -_randomFactorAfterHittingPaddle*(_paddle.transform.position.x - transform.position.x);

            Vector2 velocityTweak = new Vector2(xTweak, 0f);

            if (_gameStateController.IsGameOn) {
                _ballRigidbody.velocity += velocityTweak;
            }
        }

        private void RandomizeMovementAfterCollision() {
            Vector2 velocityTweak = new Vector2
                (Random.Range(-_randomFactor, _randomFactor),
                (Random.Range(-_randomFactor, _randomFactor)));
            if (_gameStateController.IsGameOn) {
                _ballRigidbody.velocity += velocityTweak;
            }
        }
    }
}
