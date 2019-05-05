﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Gameplay.Player {
    public class PlayerHand : MonoBehaviour {

        [SerializeField]
        private GameObject _ball;
        [SerializeField]
        private GameObject _arm;
        [SerializeField]
        private GameObject _hand;

        private float _armRotationModifier = 45 / 3;

        private void Update() {
            RotateArm();
        }

        private void RotateArm() {
            float lookAtBallPos = transform.position.x - _ball.transform.position.x;
            float zRot = lookAtBallPos * _armRotationModifier;
            Quaternion armRotation = Quaternion.Euler(0, 0, zRot);
            Quaternion handRotation = Quaternion.Euler(0, 0, 0);
            _arm.transform.rotation = armRotation;
            _hand.transform.rotation = handRotation;
        }
    }
}
