using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.Udon;

namespace Narazaka.VRChat.UIRelay
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Toggle))]
    public class UIRelayToggleToUdonBehaviour : UdonSharpBehaviour
    {
        [SerializeField]
        UdonBehaviour[] receivers;
        [SerializeField]
        string variableName;
        [SerializeField]
        string callbackEventName;
        [SerializeField]
        bool invert;

        Toggle _ui;

        Toggle ui
        {
            get
            {
                if (_ui == null)
                {
                    _ui = GetComponent<Toggle>();
                }
                return _ui;
            }
        }

        public void OnValueChanged()
        {
            var setVariable = !string.IsNullOrEmpty(variableName);
            var call = !string.IsNullOrEmpty(callbackEventName);
            var value = invert ? !ui.isOn : ui.isOn;
            foreach (var receiver in receivers)
            {
                if (receiver != null)
                {
                    if (setVariable) receiver.SetProgramVariable(variableName, value);
                    if (call) receiver.SendCustomEvent(callbackEventName);
                }
            }
        }
    }
}
