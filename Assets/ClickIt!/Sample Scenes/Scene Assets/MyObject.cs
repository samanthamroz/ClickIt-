using UnityEngine;

namespace ClickIt.Samples {
    public class MyObject : MonoBehaviour {
        [SerializeField] Material blue;
        [SerializeField] Material red;
        [SerializeField] Material yellow;
        public void Spin(int direction = 1) {
            GetComponent<Rigidbody>().AddTorque(5f * direction * Vector3.up, ForceMode.Impulse);
        }
        public void BecomeBlue() {
            GetComponent<Renderer>().material = blue;
        }

        public void BecomeRed() {
            GetComponent<Renderer>().material = red;
        }

        public void BecomeYellow() {
            GetComponent<Renderer>().material = yellow;
        }
    }
}