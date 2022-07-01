using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelControl : MonoBehaviour
{
    public GameObject WhereArrow;
    public GameObject rocketModelShop;
    public GameObject powerShop;
    public Button rocketShopButton;
    public Button powerShopButton;

    public List<GameObject> Panels;
    public MainMenuControl MainMenuControl;

    private void Start()
    {
        rocketShopButton.onClick.AddListener(() => MainMenuControl.PanelsInTheMarketAndPainting(rocketModelShop, Panels, WhereArrow));
        powerShopButton.onClick.AddListener(() => MainMenuControl.PanelsInTheMarketAndPainting(powerShop, Panels, WhereArrow));
    }   
}
