using UnityEngine;

public class FallingSphere : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.TryGetComponent<Counter>(out Counter counter)) {
            counter.DecrementCounter(1);
            Destroy(gameObject);
        }
    }
}
