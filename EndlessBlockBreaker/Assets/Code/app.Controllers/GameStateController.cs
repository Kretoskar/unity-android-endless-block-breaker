using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

namespace app.Controllers {
    /// <summary>
    /// Takes care of controlling whether the game is on
    /// </summary>
    public class GameStateController : MonoBehaviour{

        private ScoreController _scoreController;

        private bool _isGameON;
        private float _secondsToWait = 0.2f;

        /// <summary>
        /// True if the ball is moving
        /// </summary>
        public bool IsGameOn {
            get { return _isGameON; }
            set { _isGameON = value; }
        }

        private void Awake() {
            _isGameON = false;
        }

        private void Start() {
            _scoreController = FindObjectOfType<ScoreController>();
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
            StartCoroutine("EndGameCoroutine");
        }

        /// <summary>
        /// Wait and end game
        /// </summary>
        /// <returns>Seconds to wait</returns>
        private IEnumerator EndGameCoroutine() {
            yield return new WaitForSeconds(_secondsToWait);
            _scoreController.SaveHighScoreAndLastScore();
            SceneManager.LoadScene(2);
        }
    }
}
