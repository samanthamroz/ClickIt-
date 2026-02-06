using System;
using UnityEngine;
using UnityEngine.Events;
using ClickIt.Backend;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/BasicClickableObject")]
    public class BasicClickableObject : Interactable, ILeftClick, IRightClick, IMiddleClick {
        [SerializeField] private UnityEvent onLeftClick;
        [SerializeField] private UnityEvent onRightClick;
        [SerializeField] private UnityEvent onMiddleClick;

        private event Action<MouseButton> OnClickCode;
        
        public void AddCallback(Action<MouseButton> callback) {
            OnClickCode += callback;
        }
        public void AddCallback(MouseButton button, Action callback) {
            OnClickCode += (mouseButton) => {
                if (mouseButton == button) {
                    callback?.Invoke();
                }
            };
        }
        public void RemoveCallback(Action<MouseButton> callback) {
            OnClickCode -= callback;
        }

        public void DoLeftClick() {
            onLeftClick.Invoke();
            OnClickCode?.Invoke(MouseButton.left);
        }

        public void DoRightClick() {
            onRightClick.Invoke();
            OnClickCode?.Invoke(MouseButton.right);
        }

        public void DoMiddleClick() {
            onMiddleClick.Invoke();
            OnClickCode?.Invoke(MouseButton.middle);
        }
    }
}