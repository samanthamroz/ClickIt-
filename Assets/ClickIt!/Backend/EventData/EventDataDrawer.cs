using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace ClickIt.Backend {

#if UNITY_EDITOR
    public abstract class EventDataDrawer : PropertyDrawer {
        private const float Spacing = 2f;
        private const float Padding = 4f;
        private const float FieldWidth = 70f;

        // Track foldout state per property
        private static readonly Dictionary<string, bool> foldouts = new();

        protected void DrawGUI(Rect position, SerializedProperty property, GUIContent label, string interactionType) {
            EditorGUI.BeginProperty(position, label, property);

            float line = EditorGUIUtility.singleLineHeight;
            float y = position.y + Padding;

            // Background box
            Rect box = new Rect(position.x, position.y, position.width, GetPropertyHeight(property, label));
            GUI.Box(box, GUIContent.none, EditorStyles.helpBox);

            Rect content = new Rect(position.x + Padding, position.y + Padding, position.width - Padding * 2, position.height);

            // Optional label override
            SerializedProperty optionalLabel = property.FindPropertyRelative("optionalLabel");
            if (!string.IsNullOrEmpty(optionalLabel.stringValue)) {
                label.text = optionalLabel.stringValue;
            }
            else {
                label.text = $"{interactionType} Event";
            }

            // ───── Foldout Header inside the box ─────
            bool expanded;
            foldouts.TryGetValue(property.propertyPath, out expanded);

            // Use bold foldout
            float arrowOffset = 12f; // adjust for arrow space
            expanded = EditorGUI.Foldout(new Rect(content.x + arrowOffset, y, content.width - arrowOffset, line), expanded, label, true);

            foldouts[property.propertyPath] = expanded;
            y += line + Spacing;

            if (expanded) {
                EditorGUI.indentLevel++;

                DrawOptionaLabelField(ref y, content, optionalLabel);

                DrawMouseButtonBoxes(ref y, content, property);

                DrawEvents(ref y, content, property, interactionType);

                DrawTimingFields(ref y, content, property);

                EditorGUI.indentLevel -= 2;
            }

            EditorGUI.EndProperty();
        }

        private void DrawOptionaLabelField(ref float y, Rect rect, SerializedProperty label) {
            float line = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(
                new Rect(rect.x, y, rect.width, line),
                label,
                new GUIContent("Label (Optional)")
            );
            y += line + Spacing;
        }
        private void DrawMouseButtonBoxes(ref float y, Rect rect, SerializedProperty prop) {
            float line = EditorGUIUtility.singleLineHeight;
            SerializedProperty buttons = prop.FindPropertyRelative("buttons");
            EditorGUI.LabelField(new Rect(rect.x, y, rect.width, line), "Mouse Buttons");
            y += line;
            EditorGUI.indentLevel++;
            int value = buttons.intValue;
            DrawButton(ref y, rect, "Left", MouseButton.left, ref value);
            DrawButton(ref y, rect, "Middle", MouseButton.middle, ref value);
            DrawButton(ref y, rect, "Right", MouseButton.right, ref value);
            buttons.intValue = value;
            EditorGUI.indentLevel--;
            y += Spacing;
        }
        private void DrawEvents(ref float y, Rect rect, SerializedProperty prop, string interactionType) {
            SerializedProperty evt = prop.FindPropertyRelative("evt");
            float evtHeight = EditorGUI.GetPropertyHeight(evt);
            EditorGUI.PropertyField(
                new Rect(rect.x, y, rect.width, evtHeight),
                evt,
                new GUIContent($"On {interactionType} Event")
            );
            y += evtHeight + Spacing;
        }
        private void DrawTimingFields(ref float y, Rect rect, SerializedProperty prop) {
            float line = EditorGUIUtility.singleLineHeight;

            EditorGUI.LabelField(new Rect(rect.x, y, rect.width, line), "Timing Parameters");
            y += line + Spacing;
            EditorGUI.indentLevel++;

            SerializedProperty delay = prop.FindPropertyRelative("delay");
            SerializedProperty cooldown = prop.FindPropertyRelative("cooldown");
            SerializedProperty buffer = prop.FindPropertyRelative("bufferTime");
            SerializedProperty timeout = prop.FindPropertyRelative("timeout");

            DrawRightAlignedPositiveFloat(ref y, rect, delay, "Delay (seconds)");
            DrawRightAlignedPositiveFloat(ref y, rect, cooldown, "Cooldown (seconds)");
            if (cooldown.floatValue > 0f) {
                DrawRightAlignedPositiveFloat(ref y, rect, buffer, "Buffer (seconds)");
                DrawRightAlignedPositiveFloat(ref y, rect, timeout, "Timeout (seconds)");
            }
        }

        private void DrawButton(ref float y, Rect rect, string label, MouseButton button, ref int value) {
            bool has = (value & (int)button) != 0;
            bool next = EditorGUI.ToggleLeft(
                new Rect(rect.x, y, rect.width, EditorGUIUtility.singleLineHeight),
                label,
                has
            );

            if (next != has) {
                if (next) value |= (int)button;
                else value &= ~(int)button;
            }

            y += EditorGUIUtility.singleLineHeight;
        }
        private void DrawRightAlignedPositiveFloat(ref float y, Rect rect, SerializedProperty prop, string label) {
            float line = EditorGUIUtility.singleLineHeight;

            Rect fieldRect = new Rect(rect.xMax - FieldWidth, y, FieldWidth, line);

            // Label sized to text, but clamped so it never overlaps the field
            Vector2 labelSize = GUI.skin.label.CalcSize(new GUIContent(label));
            float maxLabelWidth = fieldRect.xMin - rect.x - Spacing;
            float labelWidth = Mathf.Min(labelSize.x, maxLabelWidth);

            Rect labelRect = new Rect(rect.x, y, labelWidth + ((FieldWidth / 2f) - Spacing), line);

            // Draw label (passive)
            GUI.Label(labelRect, label);

            EditorGUI.BeginChangeCheck();
            float value = EditorGUI.FloatField(fieldRect, prop.floatValue);
            if (EditorGUI.EndChangeCheck()) {
                prop.floatValue = Mathf.Max(0f, value);
            }

            y += line + Spacing;
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            float line = EditorGUIUtility.singleLineHeight;

            bool expanded = false;
            foldouts.TryGetValue(property.propertyPath, out expanded);

            if (!expanded) {
                return line + Padding * 2; // only header
            }

            // Expanded height calculation
            float h = Padding * 2;
            h += line + Spacing;      // header
            h += line + Spacing;      // label
            h += line * 4;            // mouse buttons
            h += Spacing;

            SerializedProperty evt = property.FindPropertyRelative("evt");
            h += EditorGUI.GetPropertyHeight(evt) + Spacing;

            h += line + Spacing;      // timing header
            h += line + Spacing;      // delay
            h += line + Spacing;      // cooldown

            SerializedProperty cooldown = property.FindPropertyRelative("cooldown");
            if (cooldown.floatValue > 0f) {
                h += line + Spacing;  // buffer
                h += line + Spacing;  // timeout
            }

            return h;
        }
    }
#endif

}