using UnityEngine;
using System;
using UnityEditor;
using ClickIt.Editor;

namespace ClickIt.Backend {
    [Serializable]
    public class ReleaseEventData : InteractionEventData {

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReleaseEventData))]
    public class ReleaseEventDataDrawer : EventDataDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            DrawGUI(position, property, label, "Release");
        }
    }
#endif
}