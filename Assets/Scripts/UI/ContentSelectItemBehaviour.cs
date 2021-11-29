using Content;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ContentSelectItemBehaviour : MonoBehaviour
    {
        [SerializeField] private Image itemImage;

        private IContent _content;

        public IContent Content
        {
            get => _content;
            set
            {
                _content = value;
                Init();
            }
        }

        public void Init()
        {
            itemImage.sprite = _content switch
            {
                Floor floor => floor.Sprite,
                Block block => block.Sprite,
                _ => itemImage.sprite
            };
        }

        public void SetContentToEditorInput()
        {
            if (_content != null)
                EditorInput.Main.SelectedContent = _content;
        }
    }
}