using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollisionControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
        {
            GameObject.Find("/TrapTower/Rocket/Rocket").SetActive(false);
            GameApp.Rocket_Data.CanControllable = false;
            Time.timeScale = 0;
            GameApp.MenuUI_Data.GameCanvas.gameObject.SetActive(true);
        }
    }
}
