using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBallController : MonoBehaviour {

    public GameObject blueBall;
    public float velocityBall = 10f;
    public float accelerationBall = 10f;
    public float MaxRange = 1.1f;

	// Use this for initialization
	void Start () {
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if(FindDistance() == 0.1f)
        {
            velocityBall = 0f;
            accelerationBall = 0f;
        }
        */

        if (IsWithinRange(MaxRange))
        {
            velocityBall = 0f;
            accelerationBall = 0f;
        }
	}

    private void FixedUpdate()
    {
        HandleSUVAT(velocityBall, accelerationBall, FindDirection());
    }

    public Vector3 FindDirection()
    {
        var heading = blueBall.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        return direction;
    }
    
    public void HandleSUVAT(float velocity, float acceleration, Vector3 direction)
    {
        // Find velocity
        velocity = velocity + acceleration * Time.fixedDeltaTime;

        //Find displacement
        float displacement = velocity * Time.fixedDeltaTime + 0.5f * acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        //transform
        transform.position = transform.position + direction * displacement;

    }

    bool IsWithinRange(float range)
    {
        Vector3 vectorDifference = blueBall.transform.position - transform.position;
        float distance = vectorDifference.magnitude;

        return distance <= range;
    }
}
