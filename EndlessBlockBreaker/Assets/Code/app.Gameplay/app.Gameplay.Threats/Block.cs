using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;

namespace app.Gameplay.Threats {
    /// <summary>
    /// Behaviour of the block threat
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Block : Threat {
        [SerializeField]
        private GameObject _explosionParticle = null;
        [SerializeField]
        private AudioClip _deathSound = null;
        [SerializeField]
        private int _damage = 1;

        private LivesController _livesController;

        private Rigidbody2D _blockRigidbody;

        private void Start() {
            _livesController = FindObjectOfType<LivesController>();
            _scoreController = FindObjectOfType<ScoreController>();
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
            AudioSource.PlayClipAtPoint(_deathSound, Camera.main.transform.position);
            Instantiate(_explosionParticle, transform.position, Quaternion.identity);
            AddScore();
            Destroy(gameObject);
        }

        /// <summary>
        /// Behaviour after being collision
        /// </summary>
        /// <param name="collision">the object, this object collided with</param>
        private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Ball") {
                Die();
            }
            if (collision.gameObject.tag == "Paddle") {
                _livesController.SubtractLives(_damage);
                Die();
           }
        }
    }
}
