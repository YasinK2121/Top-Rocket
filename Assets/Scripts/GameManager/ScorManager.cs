using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameApp.MenuUI_Data.Scor++;
            GameApp.MenuUI_Data.Scor2++;

            if (GameApp.MenuUI_Data.Scor == GameApp.MenuUI_Data.FixedScor)
            {
                GameApp.MenuUI_Data.FixedScor += 5;
            }
        }
    }
}
