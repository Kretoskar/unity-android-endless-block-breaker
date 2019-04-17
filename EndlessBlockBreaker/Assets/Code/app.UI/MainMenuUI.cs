using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app.UI {
    public class MainMenuUI : MonoBehaviour {
        public void PlayButtonClicked() {
            SceneManager.LoadScene(1);
        }
    }
}
