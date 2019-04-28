using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Controllers {
    /// <summary>
    /// Make boundaries position according to the camera size
    /// </summary>
    public class BoundariesController : MonoBehaviour {
        [Header("GameObjects")]
        [SerializeField]
        private GameObject _leftWall = null;
        [SerializeField]
        private GameObject _rightWall = null;

        private Camera _mainCamera;

        private void Start() {
            _mainCamera = Camera.main;

            SetupLeftWallPosition();
            SetupRightWallPosition();
        }

        /// <summary>
        /// Set the right wall's position
        /// </summary>
        private void SetupRightWallPosition() {
            float wallWidth = 1;
            float xPos =  (_mainCamera.aspect * _mainCamera.orthographicSize + (wallWidth / 2));
            _rightWall.transform.position = new Vector2(xPos, _rightWall.transform.position.y);
        }

        /// <summary>
        /// Setup the left wall's position
        /// </summary>
        private void SetupLeftWallPosition() {
            float wallWidth = 1;
            float xPos =  (-1) * (_mainCamera.aspect * _mainCamera.orthographicSize + (wallWidth / 2));
            _leftWall.transform.position = new Vector2(xPos, _leftWall.transform.position.y);
        }
    }
}
