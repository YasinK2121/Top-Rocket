using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameApp.MenuUI_Data.WinGameCanvas.gameObject.SetActive(true);
            GameApp.Rocket_Data.CanControllable = false;
        }
    }
}
