using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Controllers {
    public class BoundariesController : MonoBehaviour {
        [SerializeField]
        private GameObject _leftWall;
        [SerializeField]
        private GameObject _rightWall;

        private Camera _mainCamera;

        private void Start() {

            _mainCamera = Camera.main;

            SetupLeftWallPosition();
            SetupRightWallPosition();
        }

        private void SetupRightWallPosition() {
            float wallWidth = 1;
            float xPos =  (_mainCamera.aspect * _mainCamera.orthographicSize + (wallWidth / 2));
            _rightWall.transform.position = new Vector2(xPos, _rightWall.transform.position.y);
        }

        private void SetupLeftWallPosition() {
            float wallWidth = 1;
            float xPos =  (-1) * (_mainCamera.aspect * _mainCamera.orthographicSize + (wallWidth / 2));
            _leftWall.transform.position = new Vector2(xPos, _leftWall.transform.position.y);
        }
    }
}
