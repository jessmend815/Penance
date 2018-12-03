using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCollectible : MonoBehaviour {
    public float bloodLow;
    public float bloodHigh;
    float blood;
    bool isClose = false;

    private void OnEnable()
    {
        blood = Random.Range(bloodLow, bloodHigh);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") isClose = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") isClose = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player") isClose = true;
    }

    private void Update()
    {
        if (isClose && Input.GetMouseButton(1) && blood > 0)
        {
            PlayerController.player.blood += 1;
            blood -= 1;
        }

        if (blood <= 0) Destroy(gameObject);
    }
}
