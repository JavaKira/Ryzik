using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite sprite;

    private Vector2 _inTilemapPosition = new Vector2();
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public static Tile GetByName(string name)
    {
        return Resources.Load<Tile>(name);
    }
}
