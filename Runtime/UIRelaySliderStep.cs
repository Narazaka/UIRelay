using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace Narazaka.VRChat.UIRelay
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Slider))]
    public class UIRelaySliderStep : UdonSharpBehaviour
    {
        [SerializeField]
        float step = 1f;

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
            var value = Mathf.Round(ui.value / step) * step;
            if (value != ui.value)
            {
                ui.SetValueWithoutNotify(value);
            }
        }
    }
}
