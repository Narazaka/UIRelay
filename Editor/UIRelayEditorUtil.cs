using UnityEngine;
using UnityEditor;
using UdonSharp;
using UnityEngine.EventSystems;
using VRC.Udon;
using UnityEngine.Events;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    public static class UIRelayEditorUtil
    {
        public static void SetupEvent(Object target, UIBehaviour ui, string eventPropertyName, string callbackName)
        {
            var udon = UdonSharpEditorUtility.GetBackingUdonBehaviour(target as UdonSharpBehaviour);
            var exists = false;

            var so = new SerializedObject(ui);
            so.Update();
            var calls = so.FindProperty(eventPropertyName).FindPropertyRelative("m_PersistentCalls.m_Calls");
            var len = calls.arraySize;
            for (var i = 0; i < len; i++)
            {
                var call = calls.GetArrayElementAtIndex(i);
                if (call.FindPropertyRelative("m_Target").objectReferenceValue == udon)
                {
                    exists = true;
                    SetEventCall(call, callbackName);
                }
            }
            if (!exists)
            {
                calls.InsertArrayElementAtIndex(len);
                var call = calls.GetArrayElementAtIndex(len);
                call.FindPropertyRelative("m_Target").objectReferenceValue = udon;
                SetEventCall(call, callbackName);
            }
            if (so.hasModifiedProperties)
            {
                so.ApplyModifiedProperties();
            }
        }

        static void SetEventCall(SerializedProperty call, string callbackName)
        {
            call.FindPropertyRelative("m_Mode").intValue = (int)PersistentListenerMode.String;
            call.FindPropertyRelative("m_TargetAssemblyTypeName").stringValue = typeof(UdonSharpBehaviour).AssemblyQualifiedName;
            call.FindPropertyRelative("m_CallState").intValue = (int)UnityEventCallState.RuntimeOnly;
            call.FindPropertyRelative("m_MethodName").stringValue = nameof(UdonSharpBehaviour.SendCustomEvent);
            call.FindPropertyRelative("m_Arguments.m_StringArgument").stringValue = callbackName;
        }
    }
}
