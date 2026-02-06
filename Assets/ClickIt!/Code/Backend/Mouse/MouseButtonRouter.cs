using UnityEngine;
using System;

namespace ClickIt.Backend {
    public class MouseButtonRouter : IMouseButtonRouter {
        private InteractableRaycaster raycaster;
        private IValidatedObject[] currentInteractablesBeingClicked;
        private IValidatedObject[] lastInteractablesClicked;

        public MouseButtonRouter(InteractableRaycaster raycaster) {
            this.raycaster = raycaster;
        }

        private bool TryUpdateCurrentInteractable(Vector2 mouseScreenPosition) {
            var findInteractables = raycaster.GetInteractablesAtPosition(mouseScreenPosition);
            if (findInteractables == null) {
                return false;
            }
            
            currentInteractablesBeingClicked = findInteractables;
            return true;
        }

        private void HandleClick<TClick, TClickAway>(Vector2 screenPosition, Action<TClick> clickAction, Action<TClickAway> clickAwayAction) {
            // Handle click-away on last interactable
            if (lastInteractablesClicked != null) {
                foreach (IValidatedObject interactable in lastInteractablesClicked) {
                    if (interactable is TClickAway clickAwayObj) {
                        clickAwayAction(clickAwayObj);
                    }
                }
            }


            // Try to find new interactable
            if (!TryUpdateCurrentInteractable(screenPosition)) return;

            // Handle click on current interactable
            if (currentInteractablesBeingClicked != null) {
                foreach (IValidatedObject interactable in currentInteractablesBeingClicked) {
                    if (interactable is TClick clickObj) {
                        clickAction(clickObj);
                    }
                }
            }
        }

        private void HandleRelease<TRelease>(Action<TRelease> releaseAction) {
            if (currentInteractablesBeingClicked != null) {
                foreach (IValidatedObject interactable in currentInteractablesBeingClicked) {
                    if (interactable is TRelease releaseObj) {
                        releaseAction(releaseObj);
                    }
                }
            }

            lastInteractablesClicked = currentInteractablesBeingClicked;
            currentInteractablesBeingClicked = null;
        }


        public void DoLeftClick(Vector2 screenPositionClicked) {
            HandleClick<ILeftClick, ILeftClickAway>(screenPositionClicked, obj => obj.DoLeftClick(), obj => obj.DoLeftClickAway());
        }

        public void DoRightClick(Vector2 screenPositionClicked) {
            HandleClick<IRightClick, IRightClickAway>(screenPositionClicked, obj => obj.DoRightClick(), obj => obj.DoRightClickAway());
        }

        public void DoMiddleClick(Vector2 screenPositionClicked) {
            HandleClick<IMiddleClick, IMiddleClickAway>(screenPositionClicked, obj => obj.DoMiddleClick(), obj => obj.DoMiddleClickAway());
        }


        public void DoLeftRelease() {
            HandleRelease<ILeftRelease>(obj => obj.DoLeftRelease());
        }

        public void DoRightRelease() {
            HandleRelease<IRightRelease>(obj => obj.DoRightRelease());
        }

        public void DoMiddleRelease() {
            HandleRelease<IMiddleRelease>(obj => obj.DoMiddleRelease());
        }
    }
}