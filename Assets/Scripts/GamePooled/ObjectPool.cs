using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;

    private Queue<T> Objects = new Queue<T>();

    public static ObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public T Get()
    {
        if (Objects.Count == 0)
        {
            AddObject(1);
        }
        return Objects.Dequeue();
    }

    private void AddObject(int count)
    {
        var newPrefab = Instantiate(prefab);
        newPrefab.gameObject.SetActive(false);
        Objects.Enqueue(newPrefab);
    }

    public void ReturnToPool(T prefab)
    {
        prefab.gameObject.SetActive(false);
        Objects.Enqueue(prefab);
    }
}
