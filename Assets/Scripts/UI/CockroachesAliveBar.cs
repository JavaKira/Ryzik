using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class CockroachesAliveBar : MonoBehaviour
    {
        private Image _progressBar;
        private TMP_Text _count;

        private void Start()
        {
            _progressBar = GetComponentInChildren<Image>();
            _count = GetComponentInChildren<TMP_Text>();

            var cockroachesTotal = Map.Instance.Mobs.GetByName("mob.Cockroach").Count;

            var listener = new UnityAction(() =>
            {
                var cockroaches = Map.Instance.Mobs.GetByName("mob.Cockroach");

                _count.text = FormatCount(cockroaches.Count, cockroachesTotal);
                _progressBar.fillAmount = cockroaches.Count / (float) cockroachesTotal;
            });
            
            //init
            listener.Invoke();
            
            Map.Instance.Mobs.Changed.AddListener(listener);
        }

        private static string FormatCount(int alive, int total)
        {
            return alive + "/" + total;
        }
    }
}