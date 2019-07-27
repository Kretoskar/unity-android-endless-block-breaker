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

            SpriteRenderer stormSpriteRenderer = storm.GetComponent<SpriteRenderer>();
            SpriteRenderer lightningSpriteRenderer = lightning.GetComponent<SpriteRenderer>();

            StartCoroutine(FadeOut(stormSpriteRenderer));
            StartCoroutine(FadeOut(lightningSpriteRenderer));
            yield return new WaitForSeconds(_stormTimeInSeconds);

            Destroy(storm);
            Destroy(lightning);
            _isStorm = false;
        }

        private IEnumerator FadeOut(SpriteRenderer spriteRenderer) {
            Color spriteColor = spriteRenderer.color;

            while(spriteColor.a > 0f) {
                spriteColor.a -= Time.deltaTime / _stormTimeInSeconds;
                spriteRenderer.color = spriteColor;

                if (spriteColor.a <= 0f)
                    spriteColor.a = 0.0f;

                yield return null;
            }
            spriteRenderer.color = spriteColor;
        }

    }
}
