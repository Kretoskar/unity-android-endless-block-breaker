using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Gameplay {
    public class Storm : MonoBehaviour {
        [SerializeField]
        private GameObject _storm;
        [SerializeField]
        private GameObject _lightning;
        [SerializeField]
        private float _stormTimeInSeconds = 1;

        private bool _isStorm = false;

        public void StartStorm(Transform ballTransform) {
            if (!_isStorm) {
                _isStorm = true;
                StartCoroutine(StormCoroutine(ballTransform));
            }
        }

        private IEnumerator StormCoroutine(Transform ballTransform) {
            GameObject storm = Instantiate(_storm);
            GameObject lightning = Instantiate(_lightning, ballTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(_stormTimeInSeconds);
            Destroy(storm);
            Destroy(lightning);
            _isStorm = false;
        }

    }
}
