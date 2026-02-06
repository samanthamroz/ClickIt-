using System.Collections;
using UnityEngine;

namespace ClickIt.Samples {
    public class AutoCounter : Counter {
        public void StartIncrementingCounter(int increment = 1) {
            StopAllCoroutines();
            StartCoroutine(AutoIncrement(increment));
        }

        private IEnumerator AutoIncrement(int increment) {
            while (true) {
                count += increment;
                textField.text = count.ToString();
                yield return new WaitForSeconds(.5f);
            }
        }

        public void StartDecrementingCounter(int decrement = 1) {
            StopAllCoroutines();
            StartCoroutine(AutoDecrement(decrement));
        }

        private IEnumerator AutoDecrement(int decrement) {
            while (true) {
                count -= decrement;
                textField.text = count.ToString();
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}