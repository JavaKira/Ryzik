using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class PreservationItem : MonoBehaviour
    {
        private string _preservationName;
        private UnityAction _currentButtonListener;

        private Button _button;
        private TMP_Text _title;

        private void Awake()
        {
            _button = GetComponentInChildren<Button>();
            _title = GetComponentInChildren<TMP_Text>();
        }

        public void Build(string preservationName)
        {
            _preservationName = preservationName;
            _title.text = _preservationName;
            
            if (_currentButtonListener != null)
                _button.onClick.RemoveListener(_currentButtonListener);

            _currentButtonListener = () =>
            {
                Game.Load(_preservationName);
            };

            _button.onClick.AddListener(_currentButtonListener);
        }
    }
}