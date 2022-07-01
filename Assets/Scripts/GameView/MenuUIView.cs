using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIView : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GameApp.MenuUI_Manager.Initialize();
        GameApp.MenuUI_Data.Again.onClick.AddListener(() => GameApp.MenuUI_Manager.AgainGame());
        GameApp.MenuUI_Data.Exit.onClick.AddListener(() => GameApp.MenuUI_Manager.ExitGame());
        GameApp.MenuUI_Data.WingExit.onClick.AddListener(() => GameApp.MenuUI_Manager.ExitGame());
        GameApp.MenuUI_Data.WingNextStage.onClick.AddListener(() => GameApp.MenuUI_Manager.NextStage());
        GameApp.MenuUI_Manager.TwoBulletPowerStart();
        GameApp.MenuUI_Data.powerTwoX.onClick.AddListener(() => GameApp.MenuUI_Manager.TwoXBullet());
    }

    private void Update()
    {
        GameApp.MenuUI_Manager.TwoBulletPowerUpdate();
        GameApp.MenuUI_Manager.Score_Increase();
    }
}
