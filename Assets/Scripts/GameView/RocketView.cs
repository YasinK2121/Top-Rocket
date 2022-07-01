using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketView : MonoBehaviour
{
    private void Start()
    {
        GameApp.Rocket_Manager.Initialize();
    }

    private void Update()
    {
        if (GameApp.Rocket_Data.Rocket != null)
        {
            GameApp.Rocket_Manager.RocketMotion();
            GameApp.Rocket_Manager.BulletShot();
        }
    }
}
