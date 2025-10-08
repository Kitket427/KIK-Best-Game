using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellZone : MonoBehaviour
{
    [SerializeField] private ItemList list;
    private AudioSource sfx;
    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null && player.GetComponent<ItemList>().items.Count > 0)
        {
            list.Sell();
            sfx.Play();
        }
    }
}
