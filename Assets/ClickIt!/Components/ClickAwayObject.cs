using System.Collections.Generic;
using ClickIt.Backend;
using UnityEngine;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/ClickAwayObject")]
    public class ClickAwayObject : Interactable, ILeftClickAway, IRightClickAway, IMiddleClickAway {
        [SerializeField] private List<ClickAwayEventData> clickAwayEvents;
        private readonly InteractionEventHandler<ClickAwayEventData> eventHandler = new();

        public void DoLeftClickAway() {
            eventHandler.ProcessEventsForButton(clickAwayEvents, MouseButton.left);
        }

        public void DoMiddleClickAway() {
            eventHandler.ProcessEventsForButton(clickAwayEvents, MouseButton.middle);
        }

        public void DoRightClickAway() {
            eventHandler.ProcessEventsForButton(clickAwayEvents, MouseButton.right);
        }
    }
}