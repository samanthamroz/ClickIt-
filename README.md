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
- **Beginner-Friendly Documentation** - Example scenes, video walkthroughs, and comprehensive documentation
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
- `Label (Optional)` - An optional label for organization
- `Mouse Button(s)` - Which button triggers the event
- `OnReleaseEvent()` - UnityEvent with methods to be triggered
- `Delay (Seconds)` - Amount of time after a successful click to wait before triggering the UnityEvent
- `Timeout (Seconds)` - Amount of time after a succesful click after which subsequent clicks will no longer trigger the UnityEvent.
- `Cooldown (Seconds)` - Amount of time after a successful click that another click will not trigger the UnityEvent
- `Buffer (Seconds)` - Amount of time before the cooldown is completed that inputs will be "buffered". For example, if Cooldown = 1 second and Buffer = 0.1 second, then if the button is clicked in the last 0.1 second before the cooldown time is completed, the UnityEvent will still trigger when the cooldown is fully up.

---

## 💡 Example Scenes

**Location:** `Assets/ClickIt/Sample Scenes/3D Example Scene/`

---

## 🛠️ Advanced Usage

### Accessing Components via Code

While ClickIt! is designed for no-code use, you can access components programmatically:
```csharp
using ClickIt;

public class MyScript : MonoBehaviour
{
    private Clickable clickable;
    
    void Start()
    {
        clickable = GetComponent();
        
        // Subscribe to click events in code
        clickable.OnClick.AddListener(HandleClick);
    }
    
    void HandleClick()
    {
        Debug.Log("Object was clicked!");
    }
}
```

### Custom Click Conditions
```csharp
// You can add custom logic by subscribing to events
clickable.OnClick.AddListener(() => {
    if (InventoryHasKey())
    {
        OpenDoor();
    }
    else
    {
        ShowMessage("You need a key!");
    }
});
```

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

Full documentation available at: [Your Documentation Link]

- [API Reference](link)
- [Video Tutorials](link)
- [Best Practices Guide](link)

---

## 🤝 Support

Need help? Got feedback?

- **Email:** [hello@latticegameworks.com]
- **Discord:** [Discord](https://discord.gg/cECsC42taf)
- **Bug Reports:** [hello@latticegameworks.com]

---

## 🎓 Learning Resources

### For Beginners
- [Getting Started Video (5 min)](link)
- [Building Your First Interactive Scene (10 min)](link)

### For Intermediate Users
- [Advanced Patterns & Best Practices](link)
- [Integrating with Existing Systems](link)

### For Game Jam Participants
- [Quick Setup Checklist](link)
- [Common Game Jam Patterns](link)

---

## 📜 License

_ClickIt!_ is licensed under the Unity Asset Store Standard End User License Agreement (EULA).

By downloading, installing, or using this asset, you agree to be bound by the terms of the Unity Asset Store Standard EULA.

The full license text is available [here](https://unity.com/legal/as-terms).

EULA Summary (for convenience only):
- ✅ You may use and modify this asset in personal, educational, and commercial projects.
- ❌ You may not redistribute, resell, sublicense, or make this asset available as a standalone product or package.
- ❌ You may not claim this asset as your own work.

Copyright © 2026 Lattice Gameworks
All rights reserved

---

## ⭐ If You Like ClickIt!

- Leave a review on the Asset Store
- Share it with fellow developers
- Join our community on [Discord](https://discord.gg/cECsC42taf)
