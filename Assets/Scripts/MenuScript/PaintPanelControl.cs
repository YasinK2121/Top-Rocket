using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintPanelControl : MonoBehaviour
{
    public GameObject whereArrow;
    public GameObject rocketColor;
    public GameObject particleColor;
    public Button rocketColorButton;
    public Button particleButton;

    public List<GameObject> Panels;
    public MainMenuControl MainMenuControl;

    private void Start()
    {
        rocketColorButton.onClick.AddListener(() => MainMenuControl.PanelsInTheMarketAndPainting(rocketColor, Panels,whereArrow));
        particleButton.onClick.AddListener(() => MainMenuControl.PanelsInTheMarketAndPainting(particleColor, Panels, whereArrow));
    }
}
