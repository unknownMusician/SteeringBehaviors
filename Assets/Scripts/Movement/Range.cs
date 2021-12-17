using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace SteeringBehaviors.Movement
{
    // todo: make attribute for Mutable{struct} that will be serialized in Unity instead.
    [Serializable]
    public struct Range<T>
    {
        public T Min;
        public T Max;

        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }
    }
    
    // todo
    // [CustomPropertyDrawer(typeof(Range<>))]
    // public class RangeDrawer : PropertyDrawer
    // {
    //     public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    //     {
    //         SerializedProperty min = property.FindPropertyRelative("Min");
    //         SerializedProperty max = property.FindPropertyRelative("Max");
    //
    //         Vector2 position = rect.position;
    //         Vector2 size = new Vector2(rect.size.x / 7.0f * 3.0f, rect.size.y);
    //         
    //         Rect labelPosition = new Rect(position, size);
    //         //EditorGUI.LabelField(labelPosition, label);
    //
    //         position.x += size.x;
    //         size.x = (rect.size.x - size.x) / 2.0f;
    //         
    //         Rect minPosition = new Rect(position, size);
    //         //EditorGUI.PropertyField(minPosition, min);
    //
    //         position.x += size.x;
    //
    //         Rect maxPosition = new Rect(position, size);
    //         EditorGUI.PropertyField(maxPosition, max);
    //     }
    // }
}
