using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Star : MonoBehaviour
    {
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Sprite emptySprite;

        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                UpdateSprite();
            }
        }

        private Image _image;
        private bool _active;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            Active = false;
        }

        private void UpdateSprite()
        {
            _image.sprite = _active ? activeSprite : emptySprite;
        }
    }
}