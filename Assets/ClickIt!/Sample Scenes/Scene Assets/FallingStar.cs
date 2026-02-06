using UnityEngine;

namespace ClickIt.Samples {
    public class FallingStar : MonoBehaviour {
        void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.TryGetComponent<Counter>(out Counter counter)) {
                counter.DecrementCounter(1);
                Destroy(gameObject);
            }
        }
    }
}