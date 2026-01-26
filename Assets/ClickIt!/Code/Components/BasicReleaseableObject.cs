using System;
using UnityEngine;
using UnityEngine.Events;
using ClickIt.Backend;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/BasicReleaseableObject")]
    public class BasicReleaseableObject : Interactable, ILeftRelease, IRightRelease, IMiddleRelease {
        [SerializeField] private UnityEvent onLeftRelease;
        [SerializeField] private UnityEvent onRightRelease;
        [SerializeField] private UnityEvent onMiddleRelease;

        private event Action<MouseButton> OnReleaseCode;
        public void AddReleaseListener(Action<MouseButton> callback) {
            OnReleaseCode += callback;
        }
        public void RemoveReleaseListener(Action<MouseButton> callback) {
            OnReleaseCode -= callback;
        }

        public void DoLeftRelease() {
            onLeftRelease.Invoke();
            OnReleaseCode?.Invoke(MouseButton.left);
        }

        public void DoRightRelease() {
            onRightRelease.Invoke();
            OnReleaseCode?.Invoke(MouseButton.right);
        }

        public void DoMiddleRelease() {
            onMiddleRelease.Invoke();
            OnReleaseCode?.Invoke(MouseButton.middle);
        }
    }
}