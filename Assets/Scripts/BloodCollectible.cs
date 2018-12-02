using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollectible : MonoBehaviour {
    public float bloodLow;
    public float bloodHigh;
    float blood;

    private void OnEnable()
    {
        blood = Random.Range(bloodLow, bloodHigh);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(1) && blood > 0)
        {
            PlayerController.player.blood += 1;
            blood -= 1;
        }
    }
}
