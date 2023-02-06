using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Placuszki.VR
{
    public class DebugShortcuts : MonoBehaviour
    {
        private List<MonkeDamageReceiver> _monkeDamageReceivers;
        private int _monkeDamageReceiversIndex;

        private void Awake()
        {
            OnGameReset();
        }

        private void OnGameReset()
        {
            _monkeDamageReceivers = FindObjectsOfType<MonkeDamageReceiver>().ToList();
            _monkeDamageReceiversIndex = 0;
        }
        void OnGUI()
        {
            if (BuildType.Instance.Release)
                return;

            int width = 150;
            int height = 30;
            int startY = 70;
            int space = 10;
            int x = 10;
            if (GUI.Button(new Rect(x, startY, width, height), "Kill one monke"))
            {
                if (_monkeDamageReceiversIndex < _monkeDamageReceivers.Count)
                {
                    _monkeDamageReceivers[_monkeDamageReceiversIndex++].ReceiveDamageDebug();
                }
                else
                {
                    Debug.LogWarning("All monkes are already dead.");
                }
            }
            
            if (GUI.Button(new Rect(x, startY + space + height * 1, width, height), "Collect one banana"))
            {
                GameManager.Instance.MonkeButton();
            }
        }
    }
}