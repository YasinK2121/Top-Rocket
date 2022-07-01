using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapView : MonoBehaviour
{
    private void Start()
    {
        GameApp.Trap_Manager.Initialize();
    }

    private void Update()
    {
        //Debug.Log(GameApp.Trap_Data.trapCount);

        if (GameApp.Trap_Manager.TrapShouldSpawn())
        {
            GameApp.Trap_Manager.TrapSpawn();
        }
        GameApp.Trap_Manager.planetSpawn();
    }
}
