using UnityEngine;
using UnityEngine.UI;

namespace ClickIt.Samples {
    public class ControlReactionTimeGame : Counter {
        ClickableObject clickableObject;
        InteractionEventData reactionGameEvent, startGameEvent, resetGameEvent;
        [SerializeField] Color clear, yellow, green, red;
        [SerializeField] Image stoplight;
        [SerializeField] float reactionForgivenessSeconds = .25f;
        int combo = 1;

        void Start() {
            clickableObject = GetComponent<ClickableObject>();
            startGameEvent = GetComponent<ClickableObject>().FindEventByLabel("Start Game");
            resetGameEvent = GetComponent<ClickableObject>().FindEventByLabel("Reset Game");
        }

        void Update() {
            if (startGameEvent.Enabled) return;

            if (reactionGameEvent.IsInTimeout) {
                stoplight.color = red;
                resetGameEvent.SetEnabled(true);
            }
            else if (reactionGameEvent.IsInCooldown) {
                stoplight.color = yellow;
            }
            else {
                stoplight.color = green;
            }
        }

        public void StartGame() {
            float cooldown = UnityEngine.Random.Range(3, 6);
            reactionGameEvent = clickableObject.AddEvent(ExponentialCounterAndChangeCooldown)
                .AddButton(MouseButton.left)
                .AddButton(MouseButton.middle)
                .AddButton(MouseButton.right)
                .Cooldown(cooldown)
                .Timeout(cooldown + reactionForgivenessSeconds);

            startGameEvent.SetEnabled(false);
        }

        public void ResetGame() {
            clickableObject.RemoveEvent(reactionGameEvent);
            reactionGameEvent = null;
            stoplight.color = clear;
            startGameEvent.SetEnabled(true);
            resetGameEvent.SetEnabled(false);
        }

        private void ExponentialCounterAndChangeCooldown() {
            IncrementCounter(combo);
            combo++;

            float newCooldown = UnityEngine.Random.Range(3, 6);
            reactionGameEvent.SetCooldown(newCooldown);
            reactionGameEvent.SetTimeout(newCooldown + reactionForgivenessSeconds);
        }
    }
}