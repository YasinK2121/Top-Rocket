using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawn : MonoBehaviour
{
    public float moveSpeed;
    public float lifeTime;
    public float maxLifeTime;
    public List<GameObject> Traps;
    public List<GameObject> WingTopColor;
    public List<GameObject> WingBottomColor;
    public List<GameObject> WingMidColor;
    public Material RedTopAndBottomMaterial;
    public Material RedMidMaterial;
    public Material GreenTopAndBottomMaterial;
    public Material GreenMidMaterial;

    private void OnEnable()
    {
        lifeTime = 0.0f;

        foreach (GameObject trap in Traps)
        {
            trap.SetActive(true);
        }


        for (int i = 0; i < WingTopColor.Count; i++)
        {
            WingMidColor[i].GetComponent<MeshRenderer>().material = GreenMidMaterial;
            WingTopColor[i].GetComponent<MeshRenderer>().material = GreenTopAndBottomMaterial;
            WingBottomColor[i].GetComponent<MeshRenderer>().material = GreenTopAndBottomMaterial;
            Traps[i].GetComponent<TrapHealtControl>().isBreak = true;
        }

        TrapArrange();
    }

    public void TrapArrange()
    {
        List<int> trapsID = new List<int> { };
        int randomValue = Random.Range(2, Traps.Count);

        for (int id = 0; id < Traps.Count; id++)
        {
            trapsID.Add(id);
        }

        for (int i = 0; i < randomValue; i++)
        {
            int randomTrap = Random.Range(0, trapsID.Count);
            WingMidColor[trapsID[randomTrap]].GetComponent<MeshRenderer>().material = RedMidMaterial;
            WingTopColor[trapsID[randomTrap]].GetComponent<MeshRenderer>().material = RedTopAndBottomMaterial;
            WingBottomColor[trapsID[randomTrap]].GetComponent<MeshRenderer>().material = RedTopAndBottomMaterial;
            Traps[trapsID[randomTrap]].GetComponent<TrapHealtControl>().isBreak = false;
            trapsID.Remove(trapsID[randomTrap]);
        }
    }

    private void Update()
    {

        if (lifeTime > maxLifeTime)
        {
            TrapPooller.Instance.ReturnToPool(this);
        }
        else
        {
            lifeTime += Time.deltaTime;
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
