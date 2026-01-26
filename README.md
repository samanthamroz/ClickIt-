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
3. Configure the OnLeftClick() UnityEvent to call your methods
4. Done! Your object is now clickable.

---

## 📖 Components

### Basic Clickable Object
Detects mouse clicks on GameObjects.

**Inspector Options:**
- `OnLeftClick()` - UnityEvent triggered when left clicked
- `OnRightClick()` - Triggered when right clicked
- `OnMiddleClick()` - Triggered when middle clicked


---

## 💡 Example Scenes

ClickIt! includes example scenes demonstrating common use cases:

### 1. Basic Interactions (`BasicInteractions.scene`)
- Simple button clicks
- Hover effects
- Object selection

### 2. Point-and-Click Game (`PointAndClick.scene`)
- Interactive environment
- Inventory system integration
- Combining multiple components

### 3. UI Integration (`UIIntegration.scene`)
- World-space UI clicks
- 3D buttons
- Interactive menus

**Location:** `Assets/ClickIt/Examples/Scenes/`

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
- **Discord:** [Your Discord Server]
- **Forum:** [Asset Store Forum Thread]
- **Bug Reports:** [hello@latticegameworks.com]

**Response Time:** Usually within 24 hours

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

ClickIt! is licensed under the Unity Asset Store EULA.

You may use this package in:
- ✅ Commercial projects
- ✅ Free projects
- ✅ Game jams
- ✅ Educational projects

You may NOT:
- ❌ Resell or redistribute the source code
- ❌ Claim it as your own work

See [LICENSE](LICENSE) for full details.

---

## ⭐ If You Like ClickIt!

- Leave a review on the Asset Store
- Share it with fellow developers
- Join our community on [Discord/Forum]
- Check out our other tools: [DragIt!](link) | [SaveIt!](link)

---

**Made with ❤️ for game developers who just want to make games.**
