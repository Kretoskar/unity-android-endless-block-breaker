using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace app.Gameplay {
    public class Paddle : MonoBehaviour {

        [SerializeField]
        private float _playerSpeed = 1.5f;
        [SerializeField]
        private float _clampValue = .3f;

        private Camera _mainCamera;

        private float _distanceFromFingerToPaddle = 0;
        private float _touchXPosition = 0;

        private void Start() {
            _mainCamera = Camera.main;
        }

        private void Update() {
            if (Input.touchCount > 0)
                MovePaddleWithTouch();
        }

        private void MovePaddleWithTouch() {
            Touch userTouch = Input.GetTouch(0);
            _touchXPosition = _mainCamera.ScreenToWorldPoint(userTouch.position).x;
            if (userTouch.phase == TouchPhase.Began) {
                CalculateDistanceFromFingerToPaddle();
            }
            else if (userTouch.phase == TouchPhase.Moved) {
                Move();
            }
        }

        private void CalculateDistanceFromFingerToPaddle() {
            _distanceFromFingerToPaddle = _touchXPosition - transform.position.x;
        }

        private void Move() {
            float xPos = Mathf.Clamp(((_touchXPosition - _distanceFromFingerToPaddle) * _playerSpeed),
                (-1 * _clampValue),
                _clampValue);
            float yPos = transform.position.y;

            transform.position = new Vector2(xPos, yPos);
        }
    }
}
