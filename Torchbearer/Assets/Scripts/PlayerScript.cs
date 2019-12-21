using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private State currentState;
    public LevelManagerScript LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(0.3f, 0);
    }

    public void onHighJump()
    {
        StartCoroutine("onJumpHigh");
    }

    public void onWideJump()
    {
        StartCoroutine("onJumpWide");
    }

   public void onThrowInput()
    {
        StartCoroutine("onThrow");
    }

    IEnumerator onJumpHigh()
    {
        this.swapState(State.JumpHigh);
        yield return new WaitForSeconds(1);
        this.swapState(State.Running);

    }

    IEnumerator onJumpWide()
    {
        this.swapState(State.JumpWide);
        yield return new WaitForSeconds(1);
        this.swapState(State.Running);
    }

    IEnumerator onThrow()
    {
        this.swapState(State.Throwing);
        yield return new WaitForSeconds(1);
        this.swapState(State.Running);
    }

    IEnumerator onFallen()
    {
        this.swapState(State.Fallen); 
        yield return new WaitForSeconds(1);
        this.swapState(State.Running);
    }

    public void onRun()
    {
        this.swapState(State.Running);
    }

    public void onSkate()
    {
        this.swapState(State.Skating);
    }

    public void onRowing()
    {
        this.swapState(State.Rowing);
    }
    
    void CrashSetBack()
    {
        this.transform.position -= new Vector3(10, 0);
    }

    enum State
    {
        Running, Skating, JumpHigh, JumpWide, Rowing, Throwing, Fallen
    };

    void swapState(State newState)
    {
        this.currentState = newState;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ObstacleHigh"))
        {
            if (!this.currentState.Equals(State.JumpHigh))
            {
                this.CrashSetBack();
                StartCoroutine("onFallen");
            }
        }

        if (collision.gameObject.tag.Equals("ObstacleWide"))
        {
            if (!this.currentState.Equals(State.JumpWide))
            {
                this.CrashSetBack();
                StartCoroutine("onFallen");
            }
        }

        if (collision.gameObject.tag.Equals("ThrowingRange"))
        {
            if (this.currentState.Equals(State.Throwing))
            {
                collision.gameObject.GetComponent<ThrowingTarget>().onHitByPlayer();
            }
        }

        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            this.CrashSetBack();
            StartCoroutine("onFallen");
        }

        if (collision.gameObject.tag.Equals("Ice"))
        {
            if (!this.currentState.Equals(State.Skating))
            {
                this.LevelManager.OnPlayerReset();
                StartCoroutine("onFallen");
            }
        }

        if (collision.gameObject.tag.Equals("Water"))
        {
            if (!this.currentState.Equals(State.Rowing))
            {
                this.LevelManager.OnPlayerReset();
                StartCoroutine("onFallen");
            }
        }

        if (collision.gameObject.tag.Equals("Checkpoint"))
        {
            this.LevelManager.OnCheckPointPassed(collision.gameObject.GetComponent<CheckPointScript>());
        }
    }

   

   
}
