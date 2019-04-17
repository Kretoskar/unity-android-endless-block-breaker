using UnityEngine.SceneManagement;

namespace app.Controllers {
    public static class GameStateController {
        public static void EndGame() {
            SceneManager.LoadScene(2);
        }
    }
}
