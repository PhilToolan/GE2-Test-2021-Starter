using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{

    public GameObject ballpre;
    public bool isthrown = false;

    [SerializeField] float ballspeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isthrown)
        {
            return;
        }

        if (Input.GetKeyDown("space"))
        {
            var ball = Instantiate(ballpre, transform.position, transform.rotation);

            //ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500f);
            ball.GetComponent<Rigidbody>().velocity = transform.forward * ballspeed;

            isthrown = true;
        }
    }
}
