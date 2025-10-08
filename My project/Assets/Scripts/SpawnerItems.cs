using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItems : MonoBehaviour
{
    [SerializeField] private MetalFinder metalFinder;
    [SerializeField] private GameObject items1, items2, items3, itemSecret1, itemSecret2;
    [SerializeField] private Vector2 radius;
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            Spawn();
        }
        for (int i = 0; i < 9; i++)
        {
            Instantiate(items1, new Vector2(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y)), transform.rotation);
        }
        if(itemSecret1)Instantiate(itemSecret1, new Vector2(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y)), transform.rotation);
    }
    void Spawn()
    {
        var itemNum = Random.Range(1,21);
        if (metalFinder.level == 0)
        {
            itemNum = 1;
        }
        else if (metalFinder.level == 1)
        {
            if (itemNum > 10) itemNum = 2;
            else itemNum = 1;
        }
        else if (metalFinder.level == 2)
        {
            if (itemNum > 4) itemNum = 2;
            else itemNum = 1;
        }
        else if (metalFinder.level == 3)
        {
            if (itemNum > 17) itemNum = 1;
            else if (itemNum > 2) itemNum = 2;
            else itemNum = 3;
        }
        else if (metalFinder.level == 4)
        {
            if (itemNum > 19) itemNum = 1;
            else if (itemNum > 5) itemNum = 2;
            else itemNum = 3;
        }
        if (itemNum == 1) Instantiate(items1, new Vector2(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y)), transform.rotation);
        if (itemNum == 2) Instantiate(items2, new Vector2(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y)), transform.rotation);
        if (itemNum == 3) Instantiate(items3, new Vector2(Random.Range(-radius.x, radius.x), Random.Range(-radius.y, radius.y)), transform.rotation);
        Invoke(nameof(Spawn), Random.Range(10f, 30f));
    }
    void Update()
    {
        
    }
}
