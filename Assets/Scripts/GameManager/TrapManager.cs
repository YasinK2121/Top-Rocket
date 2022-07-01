using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public void Initialize()
    {
        GameApp.Trap_Data.SpawnPoint = GameObject.Find("/TrapTower/SpawnPoint");
        GameApp.Trap_Data.WinTrap = GameObject.Find("WinTrap");
        GameApp.Trap_Data.spawnTime = 3.5f;
        GameApp.Trap_Data.winMoveSpeed = -2f;
        GameApp.Trap_Data.planetNextSpawnTime = 0.5f;
        GameApp.Trap_Data.trapCount = 0;
    }

    public void TrapSpawn()
    {
        if (GameApp.Trap_Data.trapSpawnCount < GameApp.MenuUI_Data.RocketPath.maxValue)
        {
            GameApp.Trap_Data.trapSpawnCount++;
            GameApp.Trap_Data.nextSpawnTime = Time.time + GameApp.Trap_Data.spawnTime;
            TrapSpawn trapSpawn = TrapPooller.Instance.Get();
            trapSpawn.gameObject.SetActive(true);
            trapSpawn.transform.rotation = GameApp.Trap_Data.SpawnPoint.transform.rotation;
            trapSpawn.transform.position = GameApp.Trap_Data.SpawnPoint.transform.position;
        }

        if (GameApp.Trap_Data.trapCount == GameApp.MenuUI_Data.RocketPath.maxValue)
        {
            GameApp.Trap_Data.WinTrap.transform.Translate(0, GameApp.Trap_Data.winMoveSpeed * Time.deltaTime, 0);
        }
    }

    public bool TrapShouldSpawn()
    {
        return Time.time > GameApp.Trap_Data.nextSpawnTime;
    }

    public void planetSpawn()
    {
        GameApp.Trap_Data.planetSpawnTime += Time.deltaTime;
        if (GameApp.Trap_Data.planetNextSpawnTime < GameApp.Trap_Data.planetSpawnTime)
        {
            PlanetMotion planetMotion = PlanetPooller.Instance.Get();
            planetMotion.gameObject.SetActive(true);
            GameApp.Trap_Data.planetSpawnTime = 0;
        }
    }
}
