using UnityEngine.SceneManagement;
using UnityEngine;

namespace app.Controllers {
    /// <summary>
    /// Takes care of controlling whether the game is on
    /// </summary>
    public class GameStateController : MonoBehaviour{

        private ScoreController _scoreController;

        private bool _isGameON;

        /// <summary>
        /// True if the ball is moving
        /// </summary>
        public bool IsGameOn {
            get { return _isGameON; }
            set { _isGameON = value; }
        }

        private void Start() {
            _scoreController = FindObjectOfType<ScoreController>();
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
            _scoreController.SaveHighScoreAndLastScore();
            SceneManager.LoadScene(2);
        }
    }
}
