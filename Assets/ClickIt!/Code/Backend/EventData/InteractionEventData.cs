using UnityEngine;
using UnityEngine.Events;
using System;
namespace ClickIt.Backend {
    [Serializable]
    public class InteractionEventData {
        public string optionalLabel;
        public UnityEvent evt;
        public MouseButton buttons;
        public float cooldown;
        public float timeout;
        public float bufferTime;
        public float delay;
        [HideInInspector] public float lastTriggerTime;

        public bool HasButton(MouseButton button) {
            return (buttons & button) != 0;
        }

        public void TriggerEvent() {
            lastTriggerTime = Time.time;
            evt.Invoke();
        }
    }
}