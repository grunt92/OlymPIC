using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.player.gameObject.transform.position;
        this.transform.Translate(new Vector3(0, 0, -10));
    }
}
