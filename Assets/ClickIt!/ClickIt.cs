using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using ClickIt.Backend;

namespace ClickIt {
    [RequireComponent(typeof(PlayerInput))]
    public class ClickIt : MonoBehaviour {
        public static ClickIt self;
        private MouseController mouseController;
        private IValidater validater;
        private IMouse mouse;
        private IMouseButtonRouter router;

        void Awake() { //This is called automatically by Unity at the very beginning of every run of the game
            if (self == null) {
                self = this;

                validater = new ClickItValidater();
                mouse = new Backend.Mouse();
                router = new MouseButtonRouter();

                InputActionAsset inputActions = Resources.Load<InputActionAsset>("ClickItInputActions");
                mouseController = new MouseController(router, mouse, inputActions);

                DoSceneValidation();
                SceneManager.sceneLoaded += SceneStart; //subscribe to this function for every load of the scene

                DontDestroyOnLoad(gameObject);
            }
            else {
                Destroy(gameObject);
            }
        }
        private void SceneStart(Scene scene, LoadSceneMode mode) { //Required Unity Function Signature
            DoSceneValidation();
        }
        private void DoSceneValidation() {
            if (!validater.AllInteractablesValid()) {
                Debug.LogError("ClickCore >> Some Interactables are not configured properly");
            }
        }

        //Access to mouse status
        public Vector2 GetMousePosition() {
            return mouse.ScreenPosition;
        }
        public bool IsMouseButtonDown(MouseButton button) {
            return mouse.IsButtonDown(button);
        }

        //Delay
        public void DoDelayedAction(Action delayedAction, float timeToDelaySeconds) {
            StartCoroutine(DelayedAction(delayedAction, timeToDelaySeconds));
        }
        private IEnumerator DelayedAction(Action delayedAction, float timeToDelaySeconds) {
            yield return new WaitForSeconds(timeToDelaySeconds);
            delayedAction();
        }
    }
}