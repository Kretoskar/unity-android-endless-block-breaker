using UnityEngine.SceneManagement;
using UnityEngine;

namespace app.Controllers {
    public class GameStateController : MonoBehaviour{

        public void StartGame() {
            SceneManager.LoadScene(1);
        }

        public void EndGame() {
            SceneManager.LoadScene(2);
        }
    }
}
