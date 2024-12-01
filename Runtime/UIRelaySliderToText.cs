using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace Narazaka.VRChat.UIRelay
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Slider))]
    public class UIRelaySliderToText : UdonSharpBehaviour
    {
        [SerializeField]
        Text[] texts;
        [SerializeField]
        TextMeshProUGUI[] textMeshProTexts;

        Slider _ui;

        Slider ui
        {
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
            foreach (var text in texts)
            {
                if (text != null)
                {
                    text.text = ui.value.ToString();
                }
            }
            foreach (var textMeshProUGUI in textMeshProTexts)
            {
                if (textMeshProUGUI != null)
                {
                    textMeshProUGUI.text = ui.value.ToString();
                }
            }
        }
    }
}
