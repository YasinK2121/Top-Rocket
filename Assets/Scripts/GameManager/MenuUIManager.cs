using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public void Initialize()
    {
        /*GameApp.MenuUI_Data.ScorText = GameObject.Find("/Canvas/Text").GetComponent<Text>();
         GameApp.MenuUI_Data.GameCanvas = GameObject.Find("/GameCanvas").GetComponent<Canvas>();
         GameApp.MenuUI_Data.WinGameCanvas = GameObject.Find("/WinGameCanvas").GetComponent<Canvas>();
         GameApp.MenuUI_Data.Again = GameObject.Find("/GameCanvas/Again").GetComponent<Button>();
         GameApp.MenuUI_Data.Exit = GameObject.Find("/GameCanvas/Exit").GetComponent<Button>();
         GameApp.MenuUI_Data.WingExit = GameObject.Find("/WinGameCanvas/Exit").GetComponent<Button>();
         GameApp.MenuUI_Data.WingNextStage = GameObject.Find("/WinGameCanvas/NextStage").GetComponent<Button>();
         GameApp.MenuUI_Data.RocketPath = GameObject.Find("/Canvas/Slider").GetComponent<Slider>();*/


        GameApp.MenuUI_Data.GameCanvas = GameObject.Find("/GamePanelCanvas/LostStagePanel");
        GameApp.MenuUI_Data.WinGameCanvas = GameObject.Find("/GamePanelCanvas/NextStagePanel");
        GameApp.MenuUI_Data.ScorText = GameObject.Find("/GamePanelCanvas/PlayerScorPanel/ScorText").GetComponent<Text>();
        GameApp.MenuUI_Data.RocketPath = GameObject.Find("/GamePanelCanvas/PlayerScorPanel/ScorSlider").GetComponent<Slider>();
        GameApp.MenuUI_Data.Again = GameObject.Find("/GamePanelCanvas/LostStagePanel/AgainButton").GetComponent<Button>();
        GameApp.MenuUI_Data.Exit = GameObject.Find("/GamePanelCanvas/LostStagePanel/ExitButton").GetComponent<Button>();
        GameApp.MenuUI_Data.WingExit = GameObject.Find("/GamePanelCanvas/NextStagePanel/ExitButton").GetComponent<Button>();
        GameApp.MenuUI_Data.WingNextStage = GameObject.Find("/GamePanelCanvas/NextStagePanel/NextButton").GetComponent<Button>();
        GameApp.MenuUI_Data.powerTwoX = GameObject.Find("/GamePanelCanvas/RocketPowerPanel/BulletX").GetComponent<Button>();
        GameApp.MenuUI_Data.GameCanvas.gameObject.SetActive(false);
        GameApp.MenuUI_Data.WinGameCanvas.gameObject.SetActive(false);

        if (GameApp.MenuUI_Data.FixedScor == 0)
        {
            Time.timeScale = 1;
            GameApp.MenuUI_Data.timeData = Time.timeScale;
            GameApp.MenuUI_Data.FixedScor = 5;
        }
        else
        {
            Time.timeScale = GameApp.MenuUI_Data.timeData;
            GameApp.MenuUI_Data.RocketPath.maxValue = GameApp.MenuUI_Data.FixedScor;
        }
    }

    public void Score_Increase()
    {
        GameApp.MenuUI_Data.ScorText.text = GameApp.MenuUI_Data.Scor2.ToString();
        if (GameApp.MenuUI_Data.RocketPath.value < GameApp.MenuUI_Data.Scor)
        {
            GameApp.MenuUI_Data.RocketPath.value += Time.deltaTime;
            if (GameApp.Trap_Data.trapCount < GameApp.MenuUI_Data.Scor)
            {
                GameApp.Trap_Data.trapCount++;
            }
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        GameApp.MenuUI_Data.Scor = 0;
        GameApp.MenuUI_Data.Scor2 = 0;
        GameApp.MenuUI_Data.FixedScor = 0;
        GameApp.Trap_Data.trapSpawnCount = 0;
        SceneManager.LoadScene("MenuScene");
    }

    public void AgainGame()
    {
        SceneManager.LoadScene("GameScene");
        if (GameApp.MenuUI_Data.Scor2 > 0)
        {
            GameApp.MenuUI_Data.Scor2 -= GameApp.MenuUI_Data.Scor;
        }
        GameApp.MenuUI_Data.Scor = 0;
        GameApp.Trap_Data.trapSpawnCount = 0;
        GameApp.MenuUI_Data.RocketPath.value = 1;
        GameApp.Trap_Data.trapCount = 0;
        GameApp.Rocket_Data.CanControllable = true;
        Time.timeScale = GameApp.MenuUI_Data.timeData;
    }

    public void NextStage()
    {
        GameApp.MenuUI_Data.WinGameCanvas.gameObject.SetActive(false);
        GameApp.Trap_Data.spawnTime += 0.3f;
        Time.timeScale += 0.2f;
        GameApp.MenuUI_Data.timeData = Time.timeScale;
        GameApp.MenuUI_Data.Scor = 0;
        GameApp.Trap_Data.trapCount = 0;
        GameApp.MenuUI_Data.RocketPath.value = 0;
        GameApp.Trap_Data.trapSpawnCount = 0;
        GameApp.MenuUI_Data.RocketPath.maxValue = GameApp.MenuUI_Data.FixedScor;
        GameApp.Trap_Data.WinTrap.transform.rotation = GameApp.Trap_Data.SpawnPoint.transform.rotation;
        GameApp.Trap_Data.WinTrap.transform.position = GameApp.Trap_Data.SpawnPoint.transform.position;
        GameApp.Rocket_Data.CanControllable = true;
    }

    public void TwoBulletPowerStart()
    {
        GameApp.MenuUI_Data.powerTwoXTime = true;
        GameApp.MenuUI_Data.powerTwoXEnabled = false;
    }

    public void TwoBulletPowerUpdate()
    {
        if (GameApp.MenuUI_Data.powerTwoXEnabled == false)
        {
            GameApp.MenuUI_Data.powerTwoX.image.fillAmount += Time.deltaTime / 5;
            if (GameApp.MenuUI_Data.powerTwoX.image.fillAmount == 1)
            {
                GameApp.MenuUI_Data.powerTwoXEnabled = true;
            }
        }
        if (GameApp.MenuUI_Data.powerTwoXTime == false)
        {
            GameApp.MenuUI_Data.powerTwoX.image.fillAmount -= Time.deltaTime / 5;
            if (Input.GetMouseButtonDown(0))
            {
                BulletShot bulletShot = BulletPooller.Instance.Get();
                bulletShot.gameObject.SetActive(true);
                bulletShot.transform.rotation = GameApp.Rocket_Data.BulletSpawn.transform.rotation;
                bulletShot.transform.position = GameApp.Rocket_Data.BulletSpawn.transform.position;
            }
            if (GameApp.MenuUI_Data.powerTwoX.image.fillAmount == 0)
            {
                GameApp.MenuUI_Data.powerTwoXEnabled = false;
                GameApp.MenuUI_Data.powerTwoXTime = true;
            }
        }
    }

    public void TwoXBullet()
    {
        if(GameApp.MenuUI_Data.powerTwoXEnabled == true)
        {
            GameApp.MenuUI_Data.powerTwoXTime = false;          
        } 
    }
}
