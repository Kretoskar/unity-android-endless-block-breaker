using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;
using System;

namespace app.Gameplay {
    /// <summary>
    /// Movement of the ball,
    /// Launching the ball,
    /// Behaviour on collision
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour {

        [Header("Push on click force")]
        [SerializeField]
        private float _XPush = 0f;
        [SerializeField]
        private float _YPush = 2f;

        [Header("Randomizing movement")]
        [SerializeField]
        private float _randomFactorY = .2f;
        [SerializeField]
        private float _randomFactorX = .2f;
        [SerializeField]
        private float _randomFactorAfterHittingPaddle = 3f;
        [SerializeField]
        private float _tweakMaxTime = 4f;
        [SerializeField]
        private float _tweakForce = 2f;

        [Header("Other settings")]
        [SerializeField]
        private float _ballSpeed = 3f;

        private Paddle _paddle;
        private GameStateController _gameStateController;
        private Rigidbody2D _ballRigidbody = null;

        private bool _wasJustBoosted = false;
        private Vector2 _paddleToBallVector;
        private float _timer;

        private void Awake() {
            _ballRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            _wasJustBoosted = false;
            _paddle = FindObjectOfType<Paddle>();
            _gameStateController = FindObjectOfType<GameStateController>();

            _paddleToBallVector = transform.position - _paddle.transform.position;
        }

        private void Update() {
            _timer -= Time.deltaTime;
            if (!_gameStateController.IsGameOn)
                StickBallToPaddle();
            else
                KeepConstantSpeed();
            if (_timer <= 0)
                TweakBoost();
        }

        /// <summary>
        /// After long boring loop when the ball hits opposing walls, 
        /// GIVE IT A BOOOOOOOOST
        /// </summary>
        private void TweakBoost() {
            Vector2 velocityTweak = new Vector2(0, _tweakForce);
            if (_gameStateController.IsGameOn) {
                _ballRigidbody.velocity += velocityTweak;
                _wasJustBoosted = true;
            }
        }

        /// <summary>
        /// Launches the ball,
        /// Called by Paddle class
        /// </summary>
        public void LaunchTheBall() {
            if (!_gameStateController.IsGameOn) {
                _ballRigidbody.velocity = new Vector2(_XPush, _YPush);
                _gameStateController.IsGameOn = true;
                _timer = _tweakMaxTime;
            }
        }

        /// <summary>
        /// Set the ball position to be close to the paddle
        /// </summary>
        private void StickBallToPaddle() {
            Vector2 paddlePos = _paddle.transform.position;
            transform.position = paddlePos + _paddleToBallVector;
        }

        /// <summary>
        /// Make sure the ball doesn't go wild 
        /// </summary>
        private void KeepConstantSpeed() {
            _ballRigidbody.velocity = _ballSpeed * (_ballRigidbody.velocity.normalized);
        }

        /// <summary>
        /// Tweak, or randomize movement after collision
        /// </summary>
        /// <param name="collision">the object, this object collided with</param>
        private void OnCollisionEnter2D(Collision2D collision) {
            GetComponent<AudioSource>().Play();
            if(_wasJustBoosted) {
                _timer = _tweakMaxTime;
            }
            if (collision.gameObject.tag == "Paddle") {
                TweakMovementAfterCollisionWithPaddle();
                _timer = _tweakMaxTime;
            } else {
                RandomizeMovementAfterCollision();
            }
        }

        /// <summary>
        /// After collision with paddle hit the ball to the direction 
        /// that depends on where the ball hit
        /// </summary>
        private void TweakMovementAfterCollisionWithPaddle() {
            float xTweak = -_randomFactorAfterHittingPaddle*(_paddle.transform.position.x - transform.position.x);

            Vector2 velocityTweak = new Vector2(xTweak, 0f);

            if (_gameStateController.IsGameOn) {
                _ballRigidbody.velocity += velocityTweak;
            }
        }

        /// <summary>
        /// Prevents the ball from making boring loops
        /// </summary>
        private void RandomizeMovementAfterCollision() {
            Vector2 velocityTweak = new Vector2
                (UnityEngine.Random.Range(-_randomFactorX, _randomFactorX),
                (UnityEngine.Random.Range(-_randomFactorY, _randomFactorY)));
            if (_gameStateController.IsGameOn) {
                _ballRigidbody.velocity += velocityTweak;
            }
        }
    }
}
