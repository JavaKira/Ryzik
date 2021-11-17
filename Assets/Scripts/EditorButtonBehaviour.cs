using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditorButtonBehaviour : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenEditor);
    }

    private static void OpenEditor()
    {
        SceneManager.LoadScene("EditorScene");
    }
}