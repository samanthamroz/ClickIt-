using UnityEngine;
using System;
using UnityEditor;
using ClickIt.Editor;

namespace ClickIt.Backend {
    [Serializable]
    public class ClickEventData : InteractionEventData {

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ClickEventData))]
    public class ClickEventDataDrawer : EventDataDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            DrawGUI(position, property, label, "Click");
        }
    }
#endif
}