using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHealtControl : MonoBehaviour
{
    int Healt = 5;
    public bool isBreak = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && isBreak == true)
        {
            Healt--;
            if (Healt == 0)
            {
                this.gameObject.SetActive(false);
                Healt = 5;
            }
        }
    }
}
