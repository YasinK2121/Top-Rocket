using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMotion : MonoBehaviour
{
    private int rX;
    private int rZ;
    private int rY;

    private void OnEnable()
    {
        rX = Random.Range(-20, 20);
        rZ = Random.Range(-27, 40);
        rY = Random.Range(90, 100);
        transform.position = new Vector3(rX, rY, rZ);
    }

    private void Update()
    {
        motionPlanet();
        destroyPlanet();
    }

    private void motionPlanet()
    {
        transform.Translate(0, 0, Time.deltaTime * -10);
    }

    private void destroyPlanet()
    {
        if (transform.position.y <= 40)
        {
           PlanetPooller.Instance.ReturnToPool(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TowerDefans"))
        {
            PlanetPooller.Instance.ReturnToPool(this);
        }
    }
}
