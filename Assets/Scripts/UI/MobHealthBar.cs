using Content;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class MobHealthBar : MonoBehaviour
    {
        [SerializeField] private Mob mob;

        private Image _progressBar;

        private void Start()
        {
            _progressBar = GetComponentInChildren<Image>();

            var listener = new UnityAction(() =>
            {
                _progressBar.fillAmount = mob.Health / (float) mob.MaxHealth;
            });

            //init
            listener.Invoke();

            mob.healthChanged.AddListener(listener);
        }
    }
}