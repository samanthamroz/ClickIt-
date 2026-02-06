using UnityEngine;
using UnityEngine.UI;

namespace ClickIt.Samples {
    public class ControlRhythmGame : MonoBehaviour {
        ClickableObject clickableObject;
        InteractionEventData rhythmGameEvent, startGameEvent, resetGameEvent;
        [SerializeField] Color yellow, green, blue, red;
        [SerializeField] Image handle;
        [SerializeField] Slider slider;

        void Start() {
            clickableObject = GetComponent<ClickableObject>();
            rhythmGameEvent = clickableObject.FindEventByLabel("Rhythm Game");
            startGameEvent = GetComponent<ClickableObject>().FindEventByLabel("Start Game");
            resetGameEvent = GetComponent<ClickableObject>().FindEventByLabel("Reset Game");
        }

        void Update() {
            if (rhythmGameEvent.IsInTimeout) {
                resetGameEvent.SetEnabled(true);
            }

            if (!rhythmGameEvent.Enabled) {
                slider.value = 1;
                handle.color = green;
                return;
            }

            slider.value = rhythmGameEvent.TimeLeftInTimeout / rhythmGameEvent.Timeout;

            if (rhythmGameEvent.IsInTimeout) {
                handle.color = red;
            }
            else if (rhythmGameEvent.IsInBuffer) {
                handle.color = yellow;
            }
            else if (rhythmGameEvent.IsInCooldown) {
                handle.color = blue;
            }
            else {
                handle.color = green;
            }
        }

        public void StartGame() {
            rhythmGameEvent.SetEnabled(true);
            rhythmGameEvent.TriggerEvent();
            startGameEvent.SetEnabled(false);
        }

        public void ResetGame() {
            rhythmGameEvent.SetEnabled(false);
            startGameEvent.SetEnabled(true);
            resetGameEvent.SetEnabled(false);
        }
    }
}