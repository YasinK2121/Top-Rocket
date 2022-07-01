using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject paintPanel;
    public GameObject mainMenuPanel;
    public GameObject audioOn;
    public GameObject audioOff;
    public Button audioControl;
    public Button shopButton;
    public Button paintButton;
    public Button paintPanelExitButton;
    public Button playButton;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        playButton.onClick.AddListener(() => PlayGame());
        shopButton.onClick.AddListener(() => ShopPanelShow());
        audioControl.onClick.AddListener(() => AudioOnOff());
        paintButton.onClick.AddListener(() => PaintPanelShow());
        paintPanelExitButton.onClick.AddListener(() => PaintPanelExit());
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void ShopPanelShow()
    {
        if (shopPanel.activeInHierarchy)
        {
            shopPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(true);
        }
    }

    private void PaintPanelShow()
    {
        mainMenuPanel.SetActive(false);
        paintPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    private void PaintPanelExit()
    {
        paintPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void PanelsInTheMarketAndPainting(GameObject panel, List<GameObject> panels, GameObject whereArrow)
    {
        for (int a = 0; a < panels.Count; a++)
        {
            panels[a].SetActive(false);

            if (panel == panels[a])
            {
                whereArrow.transform.localScale = a == 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
            }
        }
        panel.SetActive(true);
    }

    public void PanelsShow(GameObject panel, List<GameObject> panels)
    {
        for (int a = 0; a < panels.Count; a++)
        {
            panels[a].SetActive(false);
        }
        panel.SetActive(true);
    }

    private void AudioOnOff()
    {
        if (audioOn.activeInHierarchy)
        {
            audioOn.SetActive(false);
            audioOff.SetActive(true);
        }
        else
        {
            audioOn.SetActive(true);
            audioOff.SetActive(false);
        }
    }
}
