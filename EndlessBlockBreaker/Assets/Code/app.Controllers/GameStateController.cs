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

        /// <summary>
        /// What to do on the start of the game
        /// </summary>
        public void StartGame() {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// What to do at the end of the game
        /// </summary>
        public void EndGame() {
            SceneManager.LoadScene(2);
        }
    }
}
