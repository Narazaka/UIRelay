using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    [CustomEditor(typeof(UIRelayButtonToggleToGameObject))]
    public class UIRelayButtonToggleToGameObjectEditor : UIRelayToGameObjectEditorBase
    {
        void OnEnable()
        {
            UIRelayEditorUtil.SetupEvent(target, (target as Component).GetComponent<Button>(), "m_OnClick", nameof(UIRelayButtonToggleToGameObject.OnClick));
        }
    }
}
