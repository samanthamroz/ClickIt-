using System;
using System.Collections.Generic;
using System.Linq;
using ClickIt.Backend;
using UnityEngine;

namespace ClickIt.Components {
    [AddComponentMenu("ClickIt/ClickableObject")]
    public class ClickableObject : Interactable, ILeftClick, IRightClick, IMiddleClick {
        [SerializeField] private List<ClickEventData> clickEvents;
        private List<ClickEventData> unserializedClickEvents;
        private readonly InteractionEventHandler<ClickEventData> eventHandler;

        public ClickableObject() {
            unserializedClickEvents = new();
            eventHandler = new();
        }

        public void DoLeftClick() {
            eventHandler.ProcessEventsForButton(clickEvents, MouseButton.left);
            eventHandler.ProcessEventsForButton(unserializedClickEvents, MouseButton.left);
        }
        public void DoMiddleClick() {
            eventHandler.ProcessEventsForButton(clickEvents, MouseButton.middle);
            eventHandler.ProcessEventsForButton(unserializedClickEvents, MouseButton.middle);
        }
        public void DoRightClick() {
            eventHandler.ProcessEventsForButton(clickEvents, MouseButton.right);
            eventHandler.ProcessEventsForButton(unserializedClickEvents, MouseButton.right);
        }

        public InteractionEventBuilder AddEvent(Action callback) {
            ClickEventData newEvent = new ClickEventData();
            newEvent.AddCallback(callback);

            return new InteractionEventBuilder(newEvent, () => {
                newEvent.ResetTriggerTime();
                unserializedClickEvents.Add(newEvent);
            });
        }
        public void AddEvent(InteractionEventData eventData) {
            unserializedClickEvents.Add((ClickEventData)eventData);
        }
        public void RemoveEvent(InteractionEventData eventData) {
            if (unserializedClickEvents.Contains(eventData)) {
                unserializedClickEvents.Remove(eventData as ClickEventData);
                return;
            }

            if (clickEvents.Contains(eventData)) {
                clickEvents.Remove(eventData as ClickEventData);
            }
        }
        public bool TryRemoveEvent(InteractionEventData eventData) {
            if (unserializedClickEvents.Contains(eventData)) {
                unserializedClickEvents.Remove(eventData as ClickEventData);
                return true;
            }

            if (clickEvents.Contains(eventData)) {
                clickEvents.Remove(eventData as ClickEventData);
                return true;
            }

            return false;
        }
        public void ClearEvents() {
            clickEvents.Clear();
            unserializedClickEvents.Clear();
        }
        public List<InteractionEventData> GetAllEvents() {
            List<InteractionEventData> allEvents = new();
            allEvents.AddRange(clickEvents);
            allEvents.AddRange(unserializedClickEvents);
            return allEvents;
        }
        public InteractionEventData FindEventByLabel(string label) {
            foreach (var evt in clickEvents) {
                if (evt.Label == label) return evt;
            }

            foreach (var evt in unserializedClickEvents) {
                if (evt.Label == label) return evt;
            }

            return null;
        }
        public List<InteractionEventData> FindEventsByLabel(string label) {
            List<InteractionEventData> eventsFound = new();

            foreach (var evt in clickEvents) {
                if (evt.Label == label) eventsFound.Add(evt);
            }
            
            foreach (var evt in unserializedClickEvents) {
                if (evt.Label == label) eventsFound.Add(evt);
            }

            return eventsFound;
        }
        public List<InteractionEventData> FindEventsByButton(MouseButton button) {
            List<InteractionEventData> eventsFound = new();

            foreach (var evt in clickEvents) {
                if (evt.HasButton(button)) eventsFound.Add(evt);
            }
            
            foreach (var evt in unserializedClickEvents) {
                if (evt.HasButton(button)) eventsFound.Add(evt);
            }

            return eventsFound;
        }
    }
}