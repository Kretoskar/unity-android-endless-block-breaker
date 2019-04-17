using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.Controllers;

namespace app.Gameplay {
    public class DeathZone : MonoBehaviour {

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.tag == "Ball") {
                GameStateController.EndGame();
            }
        }
    }
}
