using UnityEngine.SceneManagement;
using UnityEngine;

namespace app.Controllers {
    /// <summary>
    /// Takes care of controlling whether the game is on
    /// IsGameOn means, wheter the ball is moving
    /// </summary>
    public class GameStateController : MonoBehaviour{

        private bool _isGameON;

        public bool IsGameOn {
            get { return _isGameON; }
            set { _isGameON = value; }
        }

        private void Start() {
            _isGameON = false;
        }

        public void StartGame() {
            SceneManager.LoadScene(1);
        }

        public void EndGame() {
            SceneManager.LoadScene(2);
        }
    }
}
