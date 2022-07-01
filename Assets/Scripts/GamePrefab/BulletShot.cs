using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public float moveSpeed;
    public float lifeTime;
    public float maxLifeTime;
    public GameObject destroyparticle;

    private void OnEnable()
    {
        lifeTime = 0.0f;
    }

    private void Update()
    {
        if (lifeTime > maxLifeTime)
        {
            BulletPooller.Instance.ReturnToPool(this);
        }
        else
        {
            lifeTime += Time.deltaTime;
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            Instantiate(destroyparticle, new Vector3(transform.position.x, transform.position.y -0.3f, transform.position.z), Quaternion.identity);
            BulletPooller.Instance.ReturnToPool(this);
        }
    }
}
