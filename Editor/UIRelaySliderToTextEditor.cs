using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    [CustomEditor(typeof(UIRelaySliderToText))]
    public class UIRelaySliderToTextEditor : UIRelayEditorBase
    {
        void OnEnable()
        {
            UIRelayEditorUtil.SetupEvent(target, (target as Component).GetComponent<Slider>(), "m_OnValueChanged", nameof(UIRelaySliderToText.OnValueChanged));
        }
    }
}
