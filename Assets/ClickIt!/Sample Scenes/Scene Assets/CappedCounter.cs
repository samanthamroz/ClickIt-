using System;

namespace ClickIt.Samples {
    public class CappedCounter : Counter {
        BasicClickableObject clickableObject;
        void Start() {
            clickableObject = GetComponent<BasicClickableObject>();
            clickableObject.AddCallback(MouseButton.left, () => IncrementToCap(20, 1));
        }

        private void IncrementToCap(int cap, int increment) {
            count += increment;
            count = Math.Min(count, cap);
            textField.text = count.ToString();
        }
    }
}