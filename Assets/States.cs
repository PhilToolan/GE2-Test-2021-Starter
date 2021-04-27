using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Alive : State
{
    public override void Think()
    {


        if (owner.GetComponent<Dog>().ball == 0)
        {
            owner.ChangeState(new FetchState());
            return;
        }

    }
}


public class FetchState : State
{
    Transform ball;
    public override void Enter()
    {
        GameObject baller = GameObject.FindGameObjectWithTag("Ball");

        ball = baller.transform;
        owner.GetComponent<Seek>().targetGameObject = ball.gameObject;
        owner.GetComponent<Seek>().enabled = true;
    }

    public override void Think()
    {
        // If the other guy already took tghe ammo
        if (ball == null)
        {
            owner.ChangeState(new FetchState());
            return;
        }
        if (Vector3.Distance(owner.transform.position, ball.position) < 1)
        {
            owner.GetComponent<Dog>().ball += 1;
            Debug.Log("Picked up ball");
            owner.RevertToPreviousState();
            GameObject.Destroy(ball.gameObject);
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}