using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{

    public GameObject ballpre;
    public bool isthrown = false;

    public Dog dog;

    public GameObject ball;

    [SerializeField] float ballspeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        ball = Instantiate(ballpre, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

        if (isthrown)
        {
            if (Input.GetKeyDown("space"))
            {
                ball.transform.position = this.transform.position;
                ball.GetComponent<Rigidbody>().velocity = transform.forward * ballspeed;

                isthrown = true;

                dog.ReduceBallAmount();
            }
        }
        else if (isthrown == false)
        {
            if (Input.GetKeyDown("space"))
            {
                

                //ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500f);
                ball.GetComponent<Rigidbody>().velocity = transform.forward * ballspeed;

                isthrown = true;

                dog.ReduceBallAmount();
            }
        }


    }
}
