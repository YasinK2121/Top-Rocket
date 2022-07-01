using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    public GameObject effect;

    void Update()
    {
        if (GameApp.Rocket_Data.CanControllable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(effect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
    }
}
