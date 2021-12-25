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
        private UnityAction _listener;

        private void Start() 
        {
            UnityEngine.Debug.Log("bar");
            _progressBar = GetComponentInChildren<Image>();
            _count = GetComponentInChildren<TMP_Text>();
            
            _listener = new UnityAction(() =>
            {
                var cockroachesTotal = Map.Instance.MobsAtLoaded.GetByName("Cockroach").Count;
                var cockroaches = Map.Instance.Mobs.GetByName("Cockroach");

                _count.text = FormatCount(cockroaches.Count, cockroachesTotal);
                _progressBar.fillAmount = cockroaches.Count / (float) cockroachesTotal;
            });
            
            //init
            _listener.Invoke();
            
            Map.Instance.Mobs.Changed.AddListener(_listener);
        }

        private void FixedUpdate()
        {
            _listener.Invoke(); //shit
        }

        private static string FormatCount(int alive, int total)
        {
            return alive + "/" + total;
        }
    }
}