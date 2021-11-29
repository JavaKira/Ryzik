using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MapButton : MonoBehaviour
    {
        private bool _loadFromResources;
        private string _mapName;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OpenMap);
        }

        private void OpenMap()
        {
            if (_mapName != null)
                Game.Open(_mapName, _loadFromResources);
        }

        public void Build(string mapName)
        {
            _mapName = mapName;
            GetComponentInChildren<TMP_Text>().text = mapName;
        }

        public void LoadFromResources()
        {
            _loadFromResources = true;
        }
    }
}