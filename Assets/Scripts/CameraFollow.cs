using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float spd;
    // Update is called once per frame
    void LateUpdate () {
        Vector3 playTrans = PlayerController.player.transform.position;
        transform.position = Vector3.Lerp(transform.position, new Vector3(playTrans.x, playTrans.y, transform.position.z), Time.deltaTime * spd);
	}
}
