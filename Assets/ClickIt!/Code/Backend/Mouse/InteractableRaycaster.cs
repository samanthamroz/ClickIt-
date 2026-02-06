using UnityEngine;

namespace ClickIt.Backend {
    public class InteractableRaycaster {

        public IInteractable[] GetInteractablesAtPosition(Vector2 mouseScreenPosition) {
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

            //If any collider was hit
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                //If the object that collider is attached to has a component that is a type of Interactable
                if (hit.collider.gameObject.TryGetComponent(out IInteractable _)) {
                    return hit.collider.gameObject.GetComponents<IInteractable>();
                }
            }

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            RaycastHit2D hit2D = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit2D) {
                //If the object that collider is attached to has a component that is a type of Interactable
                if (hit2D.collider.gameObject.TryGetComponent(out IInteractable _)) {
                    return hit2D.collider.gameObject.GetComponents<IInteractable>();
                }
            }

            //No interactable found at that point
            return null;
        }
    }
}