using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalFinder : MonoBehaviour
{
    public int level;
    [SerializeField] private GameObject[] metals;
    private int levelCurrent;

    private AudioSource sfx;
    [SerializeField] private Image barFind, barItemGetting, backBar;
    [SerializeField] private float barFindCurrend, barGettingCurrent;
    [SerializeField] private bool active, qe, reload;
    [SerializeField] private GameObject[] qeText;
    private ItemUnderground currentItem, itemGet;
    [SerializeField] private ItemObj itemObj;
    private void Start()
    {
        sfx = GetComponent<AudioSource>();
        Finder();
    }
    void Finder()
    {
        if (FindObjectOfType<ItemUnderground>())
        {
            var items = FindObjectsOfType<ItemUnderground>();
            var distance = 9999f;
            var itemFind = FindObjectOfType<ItemUnderground>();
            foreach (ItemUnderground item in items)
            {
                if (Vector2.Distance(transform.position, item.transform.position) < distance)
                {
                    itemFind = item;
                    distance = Vector2.Distance(transform.position, item.transform.position);
                }
            }
            currentItem = itemFind;
            float findTrigger = distance / 80f;
            if (distance > 160)
            {
                Invoke(nameof(Finder), 2);
                sfx.pitch = 1;
                barFindCurrend = 0;
                active = false;
            }
            else if (distance > 16)
            {
                Invoke(nameof(Finder), findTrigger);
                sfx.pitch = 2f - distance / 160f;
                barFindCurrend = 1f - distance / 160f;
                active = false;
            }
            else
            {
                Invoke(nameof(Finder), 0.1f);
                sfx.pitch = 2;
                barFindCurrend = 1f;
                active = true;
            }
        }
        else
        {
            Invoke(nameof(Finder), 2);
            sfx.pitch = 1;
            barFindCurrend = 0;
        }
        sfx.Play();
    }
    private void Update()
    {
        if(reload == false) barFind.fillAmount = Mathf.MoveTowardsAngle(barFind.fillAmount, barFindCurrend, Time.deltaTime);
        else
        {
            barFind.fillAmount = Mathf.MoveTowardsAngle(barFind.fillAmount, 0, Time.deltaTime);
            if (barFind.fillAmount <= 0) reload = false;
        }
        if(active)
        {
            if(qe == false)
            {
                qeText[0].SetActive(true);
                qeText[1].SetActive(false);
            }
            else
            {
                qeText[1].SetActive(true);
                qeText[0].SetActive(false);
            }
            if (qe == false && Input.GetKeyDown(KeyCode.Q) || qe && Input.GetKeyDown(KeyCode.E))
            {
                if(itemGet == null || itemGet != currentItem)
                {
                    barGettingCurrent = 0;
                    itemGet = currentItem;
                }
                barGettingCurrent += 0.07f;
                qe = !qe;
            }
            if(barGettingCurrent >= 1)
            {
                itemObj.id = currentItem.id;
                itemObj.size = currentItem.size;
                Instantiate(itemObj.gameObject, transform.position, transform.rotation);
                currentItem.gameObject.SetActive(false);
                reload = true;
                active = false;
                barGettingCurrent = 0;
            }
        }
        else
        {
            qe = false;
            qeText[0].SetActive(false);
            qeText[1].SetActive(false);
        }
        if(barGettingCurrent > 0)
        {

            barGettingCurrent -= Time.deltaTime / 7f;
            barItemGetting.gameObject.SetActive(true);
            barItemGetting.fillAmount = barGettingCurrent;
            backBar.gameObject.SetActive(true);
        }
        else
        {
            barGettingCurrent =0;
            barItemGetting.gameObject.SetActive(false);
            barItemGetting.fillAmount = 0;
            backBar.gameObject.SetActive(false);
        }
        if (level != levelCurrent)
        {
            for (int i = 0; i < 4; i++)
            {
                metals[i + 4 * levelCurrent].gameObject.SetActive(false);
                metals[i + 4 * level].gameObject.SetActive(true);
            }
            levelCurrent = level;
        }
    }
}
