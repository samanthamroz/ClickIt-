using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ClickIt.Backend {
    public class InteractionEventHandler<TEventData> where TEventData : InteractionEventData {
        public void ProcessEventsForButton(List<TEventData> events, MouseButton button) {
            foreach (var eventData in events) {
                if (!eventData.HasButton(button)) continue;

                //event has no cooldown
                if (eventData.cooldown == 0) {
                    ExecuteEventWithDelayCheck(eventData);
                    continue;
                }

                //event has cooldown
                float timeSinceLastTrigger = Time.time - eventData.lastTriggerTime;
                if (timeSinceLastTrigger < eventData.cooldown) {
                    //cooldown not up
                    if (timeSinceLastTrigger >= (eventData.cooldown - eventData.bufferTime)) {
                        QueueCooldownTrigger(eventData, timeSinceLastTrigger);
                    }
                    continue;
                }

                ExecuteEventWithDelayCheck(eventData);
            }
        }

        private void ExecuteEventWithDelayCheck(TEventData eventData) {
            if (eventData.delay > 0) {
                ClickIt.self.DoDelayedAction(eventData.TriggerEvent, eventData.delay);
            }
            else {
                eventData.TriggerEvent();
            }
        }

        private void QueueCooldownTrigger(TEventData eventData, float timeSinceLastTrigger) {
            float timeInCooldownRemaining = eventData.cooldown - timeSinceLastTrigger;

            ClickIt.self.DoDelayedAction(() => {
                float newTimeSinceLastTrigger = Time.time - eventData.lastTriggerTime;
                if (newTimeSinceLastTrigger >= eventData.cooldown) {
                    ExecuteEventWithDelayCheck(eventData);
                }
            }, timeInCooldownRemaining);
        }
    }
}