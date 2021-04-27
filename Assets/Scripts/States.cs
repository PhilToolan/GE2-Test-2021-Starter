using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Control behaviours
public class Alive : State
{
    public override void Think()
    {


/*        if (owner.GetComponent<Dog>().ball == 0)
        {
            owner.ChangeState(new FetchState());
            return;
        }

        if (owner.GetComponent<Dog>().ball == 1)
        {
            owner.ChangeState(new GoToPlayer());
            return;
        }*/

    }
}

// Dog moves to the player
public class GoToPlayer : State
{
    public override void Enter()
    {
        owner.GetComponent<Seek>().targetGameObject = owner.GetComponent<Boid>().player;
        owner.GetComponent<Seek>().enabled = true;
    }

    public override void Think()
    {
        //Checking distance between dog and player
        if (Vector3.Distance(owner.GetComponent<Boid>().player.transform.position, owner.transform.position) < 10)
        {
            owner.GetComponent<Boid>().ball.transform.parent = null;
            owner.ChangeState(new LookAtPlayer());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }

}

// Dog faces player
public class LookAtPlayer : State
{
    public override void Enter()
    {
        owner.GetComponent<Seek>().enabled = false;
        owner.GetComponent<Boid>().velocity = Vector3.zero;
        owner.GetComponent<Boid>().acceleration = Vector3.zero;
    }

    public override void Think()
    {
        Vector3 dist = owner.GetComponent<Boid>().player.transform.position - owner.transform.position;
        owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, Quaternion.LookRotation(dist), Time.deltaTime);
        /*        GameObject ball = GameObject.FindGameObjectWithTag("Ball");

                *//*        if (owner.GetComponent<Dog>().ball == 0)
                        {
                            owner.ChangeState(new FetchState());
                            return;
                        }*//*

                if (Vector3.Distance(ball.transform.position, owner.GetComponent<Boid>().player.transform.position) > 15)
                {
                    owner.ChangeState(new FetchState());
                }*/

        if (Vector3.Distance(owner.GetComponent<Boid>().ball.transform.position, owner.GetComponent<Boid>().player.transform.position) > 10)
        {
            owner.ChangeState(new FetchState());
        }
    }

    public override void Exit()
    {

    }

}



// Fetch the ball
public class FetchState : State
{
    //Transform ball;
    public override void Enter()
    {
        /*        GameObject baller = GameObject.FindGameObjectWithTag("Ball");

                ball = baller.transform;*/

        AudioSource audio = owner.GetComponent<AudioSource>();
        audio.Play();

        owner.GetComponent<Seek>().targetGameObject = owner.GetComponent<Boid>().ball;
        owner.GetComponent<Seek>().enabled = true;
    }

    public override void Think()
    {

        /*        if (ball == null)
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
                }*/

        /*        if (Vector3.Distance(owner.transform.position, ball.position) < 1)
                {
                    owner.ChangeState(new GoToPlayer());
                    ball.parent = owner.transform;
                    ball.position = owner.GetComponent<Boid>().ballAttach.position;
                }*/

        if (Vector3.Distance(owner.GetComponent<Boid>().ball.transform.position, owner.transform.position) < 2)
        {
            owner.ChangeState(new GoToPlayer());
        }
    }

    public override void Exit()
    {

        owner.GetComponent<Seek>().enabled = false;
        owner.GetComponent<Boid>().ball.transform.parent = owner.transform;
        owner.GetComponent<Boid>().ball.transform.position = owner.GetComponent<Boid>().ballAttach.position;
    }
}