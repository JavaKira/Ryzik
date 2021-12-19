using System;
using UnityEngine;

namespace UI
{
    public class Panel : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                gameObject.SetActive(false);
        }
    }
}