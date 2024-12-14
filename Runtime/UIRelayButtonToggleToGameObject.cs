using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace Narazaka.VRChat.UIRelay
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [RequireComponent(typeof(Button))]
    public class UIRelayButtonToggleToGameObject : UdonSharpBehaviour
    {
        [SerializeField]
        GameObject[] receivers;

        public void OnClick()
        {
            foreach (var receiver in receivers)
            {
                if (receiver != null)
                {
                    receiver.SetActive(!receiver.activeSelf);
                }
            }
        }
    }
}
