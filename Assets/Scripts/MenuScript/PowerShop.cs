using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerShop : MonoBehaviour
{
    public Button RightButton;
    public Button LeftButton;
    public Button SelectButton;
    public List<GameObject> Items;
    public List<GameObject> Text;
    public int SelectedItem = 0;

    void Start()
    {
        RightButton.onClick.AddListener(() => RightButtonOnClick());
        LeftButton.onClick.AddListener(() => LeftButtonOnClick());
        SelectButton.onClick.AddListener(() => SelectButtonOnClick());
        FindSelectId();
    }

    public void RightButtonOnClick()
    {
        int Id = SelectedFind();
        Items[Id].SetActive(false);

        if (Id + 1 < Items.Count)
        {
            Items[Id + 1].SetActive(true);          
        }       
        else
        {
            Items[0].SetActive(true);
        }
        FindSelectId();
    }

    public void LeftButtonOnClick()
    {
        int Id = SelectedFind();
        Items[Id].SetActive(false);

        if (Id - 1 >= 0)
        {
            Items[Id - 1].SetActive(true);
        }
        else
        {
            Items[Items.Count - 1].SetActive(true);
        }
        FindSelectId();
    }

    public void SelectButtonOnClick()
    {
        int SelectId = SelectedFind();
        SelectedItem = SelectId;

        if (SelectId == SelectedItem)
        {
            Text[0].SetActive(false);
            Text[1].SetActive(true);
        }
        else
        {
            Text[0].SetActive(true);
            Text[1].SetActive(false);
        }
    }

    public void FindSelectId()
    {
        if (SelectedFind() == SelectedItem)
        {
            Text[0].SetActive(false);
            Text[1].SetActive(true);
        }
        else
        {
            Text[0].SetActive(true);
            Text[1].SetActive(false);
        }
    }

    public int SelectedFind()
    {
        int ItemId = 0;

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].activeInHierarchy)
            {
                ItemId = i;
            }
        }
        return ItemId;
    }
}
