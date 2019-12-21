using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingTarget : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obstacle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHitByPlayer()
    {
        this.obstacle.GetComponent<Collider>().enabled = false;
    }
}
