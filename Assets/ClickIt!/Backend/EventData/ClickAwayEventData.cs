using UnityEngine;
using System;
using UnityEditor;

namespace ClickIt.Backend {
    [Serializable]
    public class ClickAwayEventData : InteractionEventData {

    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ClickAwayEventData))]
    public class ClickAwayEventDataDrawer : EventDataDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            DrawGUI(position, property, label, "ClickAway");
        }
    }
#endif
}