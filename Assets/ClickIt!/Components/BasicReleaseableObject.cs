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

        public void DoLeftRelease() {
            onLeftRelease.Invoke();
        }

        public void DoRightRelease() {
            onRightRelease.Invoke();
        }

        public void DoMiddleRelease() {
            onMiddleRelease.Invoke();
        }
    }
}