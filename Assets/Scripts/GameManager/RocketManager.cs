using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public void Initialize()
    {
        GameApp.Rocket_Data.Rocket = GameObject.Find("/TrapTower/Rocket/Rocket");
        GameApp.Rocket_Data.RocketMotion = GameObject.Find("/TrapTower/Rocket");
        GameApp.Rocket_Data.BulletSpawn = GameObject.Find("/TrapTower/Rocket/Rocket/RocketBody/BulletSpawn");
        GameApp.Rocket_Data.speed = 100;
        GameApp.Rocket_Data.tower = GameObject.Find("RocketMotion").transform;
        GameApp.Rocket_Data.CanControllable = true;
    }

    private float savedPosition;

    public void RocketMotion()
    {
        if (GameApp.Rocket_Data.CanControllable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                savedPosition = Input.mousePosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                float calculatedValue = (Mathf.Abs(savedPosition) - Mathf.Abs(Input.mousePosition.x)) / 30;
                GameApp.Rocket_Data.RocketMotion.transform.RotateAround(GameApp.Rocket_Data.tower.transform.position, Vector3.up, calculatedValue * -20 * Time.deltaTime);
            }
        }
        GameApp.Rocket_Data.Rocket.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 3 * GameApp.Rocket_Data.speed, Space.World);
    }

    public void BulletShot()
    {
        if (Input.GetMouseButtonDown(0) && GameApp.Rocket_Data.CanControllable == true)
        {
            BulletShot bulletShot = BulletPooller.Instance.Get();
            bulletShot.gameObject.SetActive(true);  
            bulletShot.transform.rotation = GameApp.Rocket_Data.BulletSpawn.transform.rotation;
            bulletShot.transform.position = GameApp.Rocket_Data.BulletSpawn.transform.position;
        }
    }
}
