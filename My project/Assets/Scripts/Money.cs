using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
    [SerializeField] private int money, items;
    [SerializeField] private Transform posShop, playerPos;
    [SerializeField] private GameObject canBuy, shop;
    [SerializeField] private TextMeshProUGUI moneyText, collectiblesText;
    [SerializeField] private Image[] itemsCollect;
    [SerializeField] private GameObject[] metalPepe, backPepe, lopataPepe;
    [SerializeField] private MetalFinder metalFinder;
    public void MoneyAdd(int money)
    {
        this.money = money;
    }
    public void Collect(int id)
    {
        if (itemsCollect[id].color != Color.white)
        {
            items++;
            itemsCollect[id].color = Color.white;
        }
        collectiblesText.text = "Collected items " + items + "/" + itemsCollect.Length;
    }
    private void Update()
    {
        moneyText.text = money + " $";
        if(Vector2.Distance(posShop.position, playerPos.position) < 30)
        {
            canBuy.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                shop.SetActive(true);
            }
        }
        else
        {
            canBuy.SetActive(false);
        }
    }
    public void BuyM(int id)
    {
        bool buying = false;
        if(id == 1 && money >= 10)
        {
            buying = true;
            money -= 10;
        }
        if (id == 2 && money >= 25)
        {
            buying = true;
            money -= 25;
        }
        if (id == 3 && money >= 50)
        {
            buying = true;
            money -= 50;
        }
        if (id == 4 && money >= 100)
        {
            buying = true;
            money -= 100;
        }
        if (buying)
        {
            metalFinder.level = id;
            for (int i = 0; i < id; i++)
            {
                metalPepe[i].SetActive(false);
            }
        }
    }
}
