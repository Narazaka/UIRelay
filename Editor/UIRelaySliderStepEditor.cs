using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    [CustomEditor(typeof(UIRelaySliderStep))]
    public class UIRelaySliderStepEditor : UIRelayEditorBase
    {
        void OnEnable()
        {
            UIRelayEditorUtil.SetupEvent(target, (target as Component).GetComponent<Slider>(), "m_OnValueChanged", nameof(UIRelaySliderStep.OnValueChanged));
        }
    }
}
