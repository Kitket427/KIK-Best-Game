using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public int id, size;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
        if (id != 17)
        {
            if (size == 1)
            {
                id = Random.Range(0, 17);
            }
            if (size == 3)
            {

            }
            if (size == 6)
            {

            }
        }
        spriteRenderer.sprite = sprites[id];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
