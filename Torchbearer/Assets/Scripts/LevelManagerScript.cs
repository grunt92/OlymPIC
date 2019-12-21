using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public CheckPointScript currentCheckpoint;
    public PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerReset()
    {
        this.player.gameObject.transform.position = currentCheckpoint.gameObject.transform.position;
    }

    public void OnCheckPointPassed(CheckPointScript cp)
    {
        this.currentCheckpoint = cp;
    }
}
