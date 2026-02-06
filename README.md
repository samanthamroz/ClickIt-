# ClickIt! - Plug-and-Play Mouse Interactions

**Zero-setup mouse interaction system for Unity. Just attach components and start clicking — no coding required.**

![Unity Version Support](https://img.shields.io/badge/Unity-2021.1+-blue.svg)
![License](https://img.shields.io/badge/License-Unity_Asset_Store_EULA-green)

---

## 🎯 What is _ClickIt!_?

_ClickIt!_ is a Unity package that eliminates the tedious setup time for mouse interactions, perfect for game jams, rapid prototyping, and indie development. It was designed for developers to be able to get straight to building point-and-click gameplay instead of wasting time writing boilerplate code.

### ✨ Key Features

- **Zero Setup** - No scene configuration, no managers, no prefabs to drag in
- **Component-Based** - Just attach components to GameObjects in the Inspector
- **No Coding Required** - Use the familiar interface of Unity Events to connect functions to clicks
- **Beginner-Friendly Documentation** - 2 full example scenes and comprehensive online documentation
- **Game Jam Ready** - Start prototyping in minutes, not hours

---

## 📦 Installation

### Via Unity Package Manager
1. Download from the [Unity Asset Store](your-asset-store-link)
2. Open Unity and go to Window > Package Manager
3. Find _ClickIt!_ in "My Assets" and click Import

---

## 🚀 Quick Start

### Basic Left Click Detection

1. Select any GameObject with a Collider
2. Add the `BasicClickableObject` component in the Inspector
3. Configure the `OnLeftClick()` UnityEvent to call your methods
4. Done! Your object is now clickable.

---

## 📖 Components

### Basic Clickable Object
The easiest way to detect mouse clicks on GameObjects.

**Inspector Options (UnityEvents):**
- `OnLeftClick()` - UnityEvent triggered when left clicked
- `OnRightClick()` - Triggered when right clicked
- `OnMiddleClick()` - Triggered when middle clicked

### Basic Releaseable Object
The easiest way to detect mouse releases for GameObjects. For these events to trigger, the object must be clicked on with the corresponding button, and when that button is released, the event will trigger.

**Inspector Options (UnityEvents):**
- `OnLeftRelease()`
- `OnRightClick()`
- `OnMiddleClick()`

### Basic Click Away Object
The easiest way to detect a "click off" of a GameObject. For these events to trigger, the object must be clicked on with the corresponding button, then after the button is released, if the mouse clicks anywhere except on the GameObject, the event will trigger.

**Inspector Options (UnityEvents):**
- `OnLeftClick()`
- `OnRightClick()`
- `OnMiddleClick()`

### Clickable Object
A more customizable way to detect mouse clicks on GameObjects.
**Inspector Options:**
- `Enabled` - If the event should trigger
- `Label (Optional)` - An optional label for organization
- `Mouse Button(s)` - Which button triggers the event
- `OnClickEvent()` - UnityEvent with methods to be triggered
- `Delay (Seconds)` - Amount of time after a successful click to wait before triggering the UnityEvent
- `Timeout (Seconds)` - Amount of time after a succesful click after which subsequent clicks will no longer be registered.
- `Cooldown (Seconds)` - Amount of time after a successful click that another click will not trigger another instance of the UnityEvent
- `Buffer (Seconds)` - Amount of time before the cooldown is completed that inputs will be "buffered". For example, if Cooldown = 1 second and Buffer = 0.1 second, then if the button is clicked in the last 0.1 second before the cooldown time is completed, a click will still trigger when the cooldown is fully up.

### Releasable Object
A more customizable way to detect mouse releases for GameObjects.
**Inspector Options:**
- `Enabled` - If the event should trigger
- `Label (Optional)` - An optional label for organization
- `Mouse Button(s)` - Which button releasing triggers the event
- `OnReleaseEvent()` - UnityEvent with methods to be triggered
- `Delay (Seconds)` - Amount of time after a successful release to wait before triggering the UnityEvent
- `Timeout (Seconds)` - Amount of time after a succesful release after which subsequent releases will no longer trigger the UnityEvent.
- `Cooldown (Seconds)` - Amount of time after a successful release that another release will not trigger the UnityEvent
- `Buffer (Seconds)` - Amount of time before the cooldown is completed that inputs will be "buffered". For example, if Cooldown = 1 second and Buffer = 0.1 second, then if the button is released in the last 0.1 second before the cooldown time is completed, the UnityEvent will still trigger when the cooldown is fully up.

### Click Away Object
A more customizable way to detect a "click off" of a GameObject. For these events to trigger, the object must be clicked on with the corresponding button, then after the button is released, if the mouse clicks anywhere except on the GameObject, the event will trigger.
**Inspector Options:**
- `Enabled` - If the event should trigger
- `Label (Optional)` - An optional label for organization
- `Mouse Button(s)` - Which button triggers the event
- `OnReleaseEvent()` - UnityEvent with methods to be triggered
- `Delay (Seconds)` - Amount of time after a successful click to wait before triggering the UnityEvent
- `Timeout (Seconds)` - Amount of time after a succesful click after which subsequent clicks will no longer trigger the UnityEvent.
- `Cooldown (Seconds)` - Amount of time after a successful click that another click will not trigger the UnityEvent
- `Buffer (Seconds)` - Amount of time before the cooldown is completed that inputs will be "buffered". For example, if Cooldown = 1 second and Buffer = 0.1 second, then if the button is clicked in the last 0.1 second before the cooldown time is completed, the UnityEvent will still trigger when the cooldown is fully up.

---

## 💡 Example Scenes
Each sample scene has 8 buttons showcasing common setups/use cases.

**Examples available:**
### Button 1: Basic click interactions

Using the `BasicClickableObject` component, increments a counter on left click and decrements it on right click.

### Button 2: Combining basic click, release, and click away functionality

Using the `BasicClickableObject`, `BasicReleaseableObject`, and `BasicClickAwayObject` components:
    - begins an automatically-incrementing counter on left click
    - begins an automatically-decrementing counter on left release
    - stops the counter from moving up or down on left click away

### Button 3: Using mouse information in scripts

Using the `BasicClickableObject` and `BasicReleaseableObject`, moves the object with the mouse on click and snaps back to position on release.

### Button 4: Subscribing to basic components in code

Using the `BasicClickableObject` component, increments a counter until hitting the cap of 20 on left click and decrements it on right click. The left click functionality is added in the `Start()` method of `CappedCounter.cs`.

### Button 5: Using timing parameters on advanced components
Using the `ClickableObject` component, increments a counter on left click and spawns an object after a 1 second delay, creating a game where you must click as much as possible before the objects start falling down and decrementing the counter.

### Button 6: Using the cooldown, timeout, and buffer timing parameters

Using the `ClickableObject` component, creates a rhythm game where the player must click when the cooldown is up but the timeout has been reached yet, incrementing a counter each time they are succesfully in the "green" zone. The star on the slider shows the different timing parameters:
- Blue: In cooldown
- Yellow: In "buffer zone" (inputs registered but event not triggered until cooldown is up)
- Green: Cooldown is up
- Red: Timeout occurred

### Button 7: Subscribing to advanced components in code

Using the `ClickableObject` component, increments a counter on left click with an increasingly long delay. The left click functionality is added in the `Start()` method of `SlowingCappedCounter.cs`.

### Button 8: Adding and adjusting timing parameters in code

Using the `ClickableObject` component, creates a reaction-time game where the player must wait for the cooldown to be up and click before timeout occurs. The cooldown is set randomly each time in `ExponentialCounterAndChangeCooldown()` within `ControlReactionTimeGame.cs`.

---

## 🛠️ Advanced Usage

### Accessing Components via Code

While ClickIt! is designed for no-code use, you can access and manipulate components programmatically. Comprehensive documentation is available [here](https://www.latticegameworks.com/clickit/docs).

---

## 🐛 Troubleshooting

### Clicks Not Detected
- ✅ Ensure your GameObject has a Collider component
- ✅ Check that the object's layer isn't being ignored by raycasts
- ✅ Verify the Camera tagged as "MainCamera" exists
- ✅ Make sure the ClickIt! component is enabled

❓ Still having trouble? Reach out with any support questions to hello@latticegameworks.com

---

## 📚 Documentation

Full documentation available at: [https://www.latticegameworks.com/clickit/docs]

---

## 🤝 Support

Need help? Got feedback?

- **Email:** [hello@latticegameworks.com]
- **Discord:** [https://discord.gg/cECsC42taf]
- **Bug Reports:** [hello@latticegameworks.com]

**Response Time:** Usually within 24 hours

---

## 📜 License

ClickIt! is licensed under the Unity Asset Store EULA. In short:

You may use this package in:
- ✅ Commercial projects
- ✅ Free projects
- ✅ Game jams
- ✅ Educational projects

You may NOT:
- ❌ Resell or redistribute the source code
- ❌ Claim it as your own work

---

## ⭐ If You Like ClickIt!

- Leave a review on the Asset Store
- Share it with fellow developers
- Join our Discord community at [https://discord.gg/cECsC42taf]
