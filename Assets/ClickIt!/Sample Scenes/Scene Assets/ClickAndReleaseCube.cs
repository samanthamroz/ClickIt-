using System.Collections;
using ClickIt.Components;
using UnityEngine;
using UnityEngine.UI;

namespace ClickIt.Samples {
    public class ClickAndReleaseCube : MonoBehaviour {
        [SerializeField] Material blue;
        [SerializeField] Material red;
        [SerializeField] Material yellow;

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