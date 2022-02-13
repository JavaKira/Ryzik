using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private string postfix;
        
        private void Awake()
        {
            var action = new UnityAction(() =>
            {
                GetComponent<TMP_Text>().text = Campaign.GetData().Money + postfix;
            });
            
            action.Invoke();

            Campaign.GetData().Changed.AddListener(action);
        }
    }
}