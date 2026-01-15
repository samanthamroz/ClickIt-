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

        public void DoLeftClickAway() {
            onLeftClickAway.Invoke();
        }

        public void DoRightClickAway() {
            onRightClickAway.Invoke();
        }

        public void DoMiddleClickAway() {
            onMiddleClickAway.Invoke();
        }
    }
}