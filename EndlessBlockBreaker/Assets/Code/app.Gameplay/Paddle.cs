using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace app.Gameplay {
    /// <summary>
    /// Paddle movement
    /// </summary>
    public class Paddle : MonoBehaviour {

        [SerializeField]
        private float _playerSpeed = 1.5f;
        [SerializeField]
        private float _clampValue = .3f;

        private Camera _mainCamera;
        private Ball _ball;

        private float _distanceFromFingerToPaddle = 0;
        private float _touchXPosition = 0;

        private void Start() {
            _ball = FindObjectOfType<Ball>();
            _mainCamera = Camera.main;
            int paddleSize = 2;
            _clampValue = _mainCamera.aspect * _mainCamera.orthographicSize - (paddleSize/2); 
        }

        private void Update() {
            if (Input.touchCount > 0)
                PaddlePhases();
        }

        /// <summary>
        /// Moves paddle with user's touch,
        /// Launches the ball when user ends touching
        /// </summary>
        private void PaddlePhases() {
            Touch userTouch = Input.GetTouch(0);
            _touchXPosition = _mainCamera.ScreenToWorldPoint(userTouch.position).x;
            if (userTouch.phase == TouchPhase.Began) {
                CalculateDistanceFromFingerToPaddle();
            }
            else if (userTouch.phase == TouchPhase.Moved) {
                Move();
            }
            else if (userTouch.phase == TouchPhase.Ended) {
                _ball.LaunchTheBall();
            }
        }

        /// <summary>
        /// Calculates distance from user's touch to the paddle
        /// </summary>
        private void CalculateDistanceFromFingerToPaddle() {
            _distanceFromFingerToPaddle = _touchXPosition - transform.position.x;
        }

        /// <summary>
        /// Move the paddle
        /// </summary>
        private void Move() {
            float xPos = Mathf.Clamp(((_touchXPosition - _distanceFromFingerToPaddle) * _playerSpeed),
                (-1 * _clampValue),
                _clampValue);
            float yPos = transform.position.y;

            transform.position = new Vector2(xPos, yPos);
        }
    }
}
