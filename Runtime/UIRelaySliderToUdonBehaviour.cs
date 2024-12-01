using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.Udon;

namespace Narazaka.VRChat.UIRelay
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Slider))]
    public class UIRelaySliderToUdonBehaviour : UdonSharpBehaviour
    {
        [SerializeField]
        UdonBehaviour[] receivers;
        [SerializeField]
        string variableName;
        [SerializeField]
        string callbackEventName;

        Slider _ui;

        Slider ui {
            get
            {
                if (_ui == null)
                {
                    _ui = GetComponent<Slider>();
                }
                return _ui;
            }
        }

        public void OnValueChanged()
        {
            var setVariable = !string.IsNullOrEmpty(variableName);
            var call = !string.IsNullOrEmpty(callbackEventName);
            var value = ui.value;
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
