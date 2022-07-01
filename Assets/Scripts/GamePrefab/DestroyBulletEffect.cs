using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletEffect : MonoBehaviour
{
    public float lifeTime;

    private void Start()
    {
        Invoke("DestroyParticle", lifeTime);
    }

    private void DestroyParticle()
    {
        Destroy(gameObject);
    }
}
