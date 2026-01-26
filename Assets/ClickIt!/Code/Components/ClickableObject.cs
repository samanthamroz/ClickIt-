using System.Collections.Generic;
using ClickIt.Backend;
using UnityEngine;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/ClickableObject")]
    public class ClickableObject : Interactable, ILeftClick, IRightClick, IMiddleClick {
        [SerializeField] private List<ClickEventData> clickEvents;
        private readonly InteractionEventHandler<ClickEventData> eventHandler = new();

        public void DoLeftClick() {
            eventHandler.ProcessEventsForButton(clickEvents, MouseButton.left);
        }

        public void DoMiddleClick() {
            eventHandler.ProcessEventsForButton(clickEvents, MouseButton.middle);
        }

        public void DoRightClick() {
            eventHandler.ProcessEventsForButton(clickEvents, MouseButton.right);
        }
    }
}