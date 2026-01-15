using UnityEngine;
namespace ClickIt.Backend {
    public class ClickItValidater : IValidater {
        public bool AllInteractablesValid() {
            foreach (MonoBehaviour mb in GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)) {
                if (mb is IInteractable interactable) {
                    if (!interactable.ValidInteractableConfiguration()) {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}