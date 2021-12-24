using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpriteVariants : MonoBehaviour
{
    [SerializeField] private Sprite[] variants;

    private void Start()
    {
        if (variants.Length == 0) 
            throw new ArgumentException("variants array could not be empty");
        
        GetComponent<SpriteRenderer>().sprite = variants[Random.Range(0, variants.Length)];
    }
}