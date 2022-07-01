using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    public static TrapData Trap_Data { get; private set; } = new TrapData();
    public static TrapManager Trap_Manager { get; private set; } = new TrapManager();
    public static TrapView Trap_View { get; private set; } = new TrapView();

    public static RocketData Rocket_Data { get; private set; } = new RocketData();
    public static RocketManager Rocket_Manager { get; private set; } = new RocketManager();
    public static RocketView Rocket_View { get; private set; } = new RocketView();

    //public static BulletData Bullet_Data { get; private set; } = new BulletData();
   // public static BulletManager Bullet_Manager { get; private set; } = new BulletManager();
    //public static BulletView Bullet_View { get; private set; } = new BulletView();

    public static MenuUIData MenuUI_Data { get; private set; } = new MenuUIData();
    public static MenuUIManager MenuUI_Manager { get; private set; } = new MenuUIManager();
    public static MenuUIView MenuUI_View { get; private set; } = new MenuUIView();

    public static RocketCollisionControl Rocket_Collision_Control { get; private set; } = new RocketCollisionControl();
    public static TrapHealtControl TrapHealt_Control { get; private set; } = new TrapHealtControl();

    public static ScorManager Scor_Manager { get; private set; } = new ScorManager();
    public static BulletShot Bullet_Shot { get; private set; } = new BulletShot();
    public static TrapSpawn Trap_Spawn { get; private set; } = new TrapSpawn();
}