using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.Gameplay.Threats {
    public class ThreatSpawner : MonoBehaviour {
        private float _xMin = -3;
        private float _xMax = 3;

        [Header("GameObjects")]
        [SerializeField]
        private List<Threat> _threats = null;

        [Header("Variables")]
        [SerializeField]
        private float _minTimeBetweenSpawns = 0.5f;
        [SerializeField]
        private float _maxTimeBetweenSpawns = 2;

        private void Start() {
            StartCoroutine("SpawnCoroutine");
        }

        /// <summary>
        /// Spawn threats continously
        /// </summary>
        /// <returns>time to spawn next wave</returns>
        private IEnumerator SpawnCoroutine() {
            float timeToSpawn = Random.Range(_minTimeBetweenSpawns, _maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeToSpawn);
            SpawnThreat();
            StartCoroutine("SpawnCoroutine");
        }

        /// <summary>
        /// Calculate spawn position and spawn one of the threats
        /// </summary>
        private void SpawnThreat() {
            Vector2 spawnPosition = new Vector2(Random.Range(_xMin, _xMax), transform.position.y);
            int spawnIndex = Random.Range(0, _threats.Count);
            Instantiate(_threats[spawnIndex], spawnPosition, Quaternion.identity);
        }
    }
}
