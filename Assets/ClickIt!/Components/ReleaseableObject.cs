using System.Collections.Generic;
using ClickIt.Backend;
using UnityEngine;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/ReleaseableObject")]
    public class ReleaseableObject : Interactable, ILeftRelease, IRightRelease, IMiddleRelease {
        [SerializeField] private List<ReleaseEventData> releaseEvents;
        private readonly InteractionEventHandler<ReleaseEventData> eventHandler = new();

        public void DoLeftRelease() {
            eventHandler.ProcessEventsForButton(releaseEvents, MouseButton.left);
        }

        public void DoMiddleRelease() {
            eventHandler.ProcessEventsForButton(releaseEvents, MouseButton.middle);
        }

        public void DoRightRelease() {
            eventHandler.ProcessEventsForButton(releaseEvents, MouseButton.right);
        }
    }
}