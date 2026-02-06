using System;
using ClickIt.Backend;
using ClickIt.Components;
using UnityEngine;

public class SlowingCappedCounter : Counter
{
    ClickableObject clickableObject;
    InteractionEventData trackedEvent;

    void Start() {
        clickableObject = GetComponent<ClickableObject>();
        trackedEvent = clickableObject.AddEvent(() => IncrementToCap(20, 1));
    }

    private void IncrementToCap(int cap, int increment) {
        count += increment;
        count = Math.Min(count, cap);
        textField.text = count.ToString();

        trackedEvent.SetCooldown(trackedEvent.Cooldown + .1f);
    }
}
