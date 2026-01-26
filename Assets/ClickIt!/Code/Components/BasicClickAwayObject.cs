using System;
using UnityEngine;
using UnityEngine.Events;
using ClickIt.Backend;

namespace ClickIt.Components {

    [AddComponentMenu("ClickIt/BasicClickAwayObject")]
    public class BasicClickAwayObject : Interactable, ILeftClickAway, IRightClickAway, IMiddleClickAway {
        [SerializeField] private UnityEvent onLeftClickAway;
        [SerializeField] private UnityEvent onRightClickAway;
        [SerializeField] private UnityEvent onMiddleClickAway;

        private event Action<MouseButton> OnClickAwayCode;
        public void AddClickAwayListener(Action<MouseButton> callback) {
            OnClickAwayCode += callback;
        }
        public void RemoveClickAwayListener(Action<MouseButton> callback) {
            OnClickAwayCode -= callback;
        }

        public void DoLeftClickAway() {
            onLeftClickAway.Invoke();
            OnClickAwayCode?.Invoke(MouseButton.left);
        }

        public void DoRightClickAway() {
            onRightClickAway.Invoke();
            OnClickAwayCode?.Invoke(MouseButton.right);
        }

        public void DoMiddleClickAway() {
            onMiddleClickAway.Invoke();
            OnClickAwayCode?.Invoke(MouseButton.middle);
        }
    }
}