using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    [CustomEditor(typeof(UIRelaySliderToUdonBehaviour))]
    public class UIRelaySliderToUdonBehaviourEditor : UIRelayToUdonBehaviourEditorBase
    {
        void OnEnable()
        {
            UIRelayEditorUtil.SetupEvent(target, (target as Component).GetComponent<Slider>(), "m_OnValueChanged", nameof(UIRelaySliderToUdonBehaviour.OnValueChanged));
        }

        protected override string typeName => "float";
    }
}
