﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Gameplay.Threats {
    /// <summary>
    /// Behaviour of the block threat
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Block : Threat {

        private Rigidbody2D _blockRigidbody;

        private void Start() {
            _blockRigidbody = GetComponent<Rigidbody2D>();
            Move();
        }

        /// <summary>
        /// Move after spawn
        /// </summary>
        protected override void Move() {
            float yVelocity = -1 * _speed;
            _blockRigidbody.velocity = new Vector2(0, yVelocity);
        }

        /// <summary>
        /// Behaviour when threat is killed
        /// </summary>
        protected override void Die() {
            AddScore();
            Destroy(gameObject);
        }

        /// <summary>
        /// Die after being hit by the ball
        /// </summary>
        /// <param name="collision">the object, this object collided with</param>
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Ball")
                Die();
        }
    }
}
