using UnityEngine;

namespace ClickIt.Samples {
    public class PrefabSpawner : MonoBehaviour {
        [SerializeField] GameObject prefab;
        [SerializeField] Vector3 spawnPosition;
        public void Spawn() {
            var spawn = Instantiate(prefab);
            spawn.transform.position = spawnPosition;
        }
    }
}