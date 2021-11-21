using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditorInput : MonoBehaviour
{
    public static EditorInput Main;

    [SerializeField] private TileMap tileMap;
    [SerializeField] private GameObject cameraPoint;
    [SerializeField] private float moveSpeed;

    public IContent SelectedContent { get; set; }

    private void Start()
    {
        Main = this;
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tileMap.GetTile(
                (int) ((mousePosition.x + 4) / 8), 
                (int) ((mousePosition.y + 4) / 8)
            ).SetIContent(SelectedContent);
        }
        
        if (Input.GetKey(KeyCode.W)) Move(Vector2.up);
        
        if (Input.GetKey(KeyCode.S)) Move(Vector2.down);
        
        if (Input.GetKey(KeyCode.A)) Move(Vector2.left);
        
        if (Input.GetKey(KeyCode.D)) Move(Vector2.right);
    }

    public static bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void Move(Vector3 direction)
    {
        cameraPoint.transform.position += direction * (moveSpeed * Time.deltaTime);
    }
}