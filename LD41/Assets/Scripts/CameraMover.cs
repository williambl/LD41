using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () {
        if (PlayerController.playerController.isDead)
            return;
        transform.position += new Vector3(0, 0.002f, 0);
    }
}
