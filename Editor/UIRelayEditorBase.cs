using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    public abstract class UIRelayEditorBase : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target, drawScript: false)) return;

            base.OnInspectorGUI();
        }
    }
}
