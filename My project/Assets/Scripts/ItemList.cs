using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ItemInfo
{
    public int id;
    public int size;
}
public class ItemList : MonoBehaviour
{
    public int size;

    [SerializeField] public List<ItemInfo> items;
    [SerializeField] private int sizeCurrent, sizeMax;
    [SerializeField] private GameObject itemGetText;
    [SerializeField] private Text text;
    [SerializeField] private Money money;

    private void Start()
    {
        UI();
    }
    private void Update()
    {
        if (FindObjectOfType<ItemObj>())
        {
            var items = FindObjectsOfType<ItemObj>();
            var distance = 9999f;
            var itemFind = FindObjectOfType<ItemObj>();
            foreach (ItemObj item in items)
            {
                if (Vector2.Distance(transform.position, item.transform.position) < distance)
                {
                    itemFind = item;
                    distance = Vector2.Distance(transform.position, item.transform.position);
                }
            }
            if (distance < 16)
            {
                itemGetText.SetActive(true);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    ItemAdd(itemFind.id, itemFind.size, itemFind.gameObject);
                }
            }
            else
            {
                itemGetText.SetActive(false);
            }
        }
        else itemGetText.SetActive(false);
    }
    public void ItemAdd(int id, int size, GameObject itemDelete)
    {
        if (sizeMax > sizeCurrent)
        {
            ItemInfo item = new ItemInfo();
            item.id = id;
            item.size = size;
            items.Add(item);
            sizeCurrent += size;
            itemDelete.gameObject.SetActive(false);
            money.Collect(id);
        }
        UI();
    }
    private void UI()
    {
        text.text = sizeCurrent + "/" + sizeMax;
    }
    public void Sell()
    {
        while (items.Count > 0)
        {
            if(items[items.Count - 1].size == 1)
            {
                money.MoneyAdd(1);
            }
            if (items[items.Count - 1].size == 3)
            {
                money.MoneyAdd(4);
            }
            if (items[items.Count - 1].size == 6)
            {
                money.MoneyAdd(10);
            }
            items.RemoveAt(items.Count - 1);
        }
    }
}
