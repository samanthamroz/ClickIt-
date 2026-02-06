using System;
using System.Collections.Generic;
using ClickIt.Backend;
using UnityEngine;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/ClickAwayObject")]
    public class ClickAwayObject : Interactable, ILeftClickAway, IRightClickAway, IMiddleClickAway {
        [SerializeField] private List<ClickAwayEventData> clickAwayEvents;
        private List<ClickAwayEventData> codeClickAwayEvents;
        private readonly InteractionEventHandler<ClickAwayEventData> eventHandler = new();

        private event Action<MouseButton> OnClickAwayCode;
        public void AddClickAwayListener(Action<MouseButton> callback) {
            OnClickAwayCode += callback;
        }
        public void RemoveClickAwayListener(Action<MouseButton> callback) {
            OnClickAwayCode -= callback;
        }
        
        public void DoLeftClickAway() {
            eventHandler.ProcessEventsForButton(clickAwayEvents, MouseButton.left);
            OnClickAwayCode?.Invoke(MouseButton.left);
        }

        public void DoMiddleClickAway() {
            eventHandler.ProcessEventsForButton(clickAwayEvents, MouseButton.middle);
            OnClickAwayCode?.Invoke(MouseButton.middle);
        }

        public void DoRightClickAway() {
            eventHandler.ProcessEventsForButton(clickAwayEvents, MouseButton.right);
            OnClickAwayCode?.Invoke(MouseButton.right);
        }

        
    }
}