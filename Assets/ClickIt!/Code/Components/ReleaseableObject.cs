using System;
using System.Collections.Generic;
using ClickIt.Backend;
using UnityEngine;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/ReleaseableObject")]
    public class ReleaseableObject : Interactable, ILeftRelease, IRightRelease, IMiddleRelease {
        [SerializeField] private List<ReleaseEventData> releaseEvents;
        private readonly InteractionEventHandler<ReleaseEventData> eventHandler = new();

        private event Action<MouseButton> OnReleaseCode;
        public void AddReleaseListener(Action<MouseButton> callback) {
            OnReleaseCode += callback;
        }
        public void RemoveReleaseListener(Action<MouseButton> callback) {
            OnReleaseCode -= callback;
        }
        
        public void DoLeftRelease() {
            eventHandler.ProcessEventsForButton(releaseEvents, MouseButton.left);
            OnReleaseCode?.Invoke(MouseButton.left);
        }

        public void DoMiddleRelease() {
            eventHandler.ProcessEventsForButton(releaseEvents, MouseButton.middle);
            OnReleaseCode?.Invoke(MouseButton.middle);
        }

        public void DoRightRelease() {
            eventHandler.ProcessEventsForButton(releaseEvents, MouseButton.right);
            OnReleaseCode?.Invoke(MouseButton.right);
        }
    }
}