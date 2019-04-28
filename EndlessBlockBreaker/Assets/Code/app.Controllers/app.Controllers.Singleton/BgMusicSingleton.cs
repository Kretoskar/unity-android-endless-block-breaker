using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Controllers.Singleton {
    /// <summary>
    /// Singleton for playing background music
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class BgMusicSingleton : MonoBehaviour {

        public static BgMusicSingleton Instance { get; private set; }

        private void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else {
                Destroy(gameObject);
            }
        }

        private void Start() {
            GetComponent<AudioSource>().Play();
        }
    }
}
