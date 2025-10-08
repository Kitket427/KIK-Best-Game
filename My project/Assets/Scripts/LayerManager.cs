using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    private SpriteRenderer spr;
    [SerializeField] private int layer, layerDifference;
    private void OnEnable()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (transform.position.y < player.transform.position.y) spr.sortingOrder = layer + layerDifference;
        else spr.sortingOrder = layer - layerDifference;
    }
}
