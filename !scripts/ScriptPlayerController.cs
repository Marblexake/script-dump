using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerController : MonoBehaviour {

    public float Acceleration = 100.0f;
    public float Friction = 0.8f;
    public float MaxSpeed = 200.0f;

    float velocityX;
    float accelerationX;
    float velocityZ;
    float accelerationZ;

    // Use this for initialization
    void Start ()
    {

        velocityX = 0.0f;
        accelerationX = 0.0f;
        velocityZ = 0.0f;
        accelerationZ = 0.0f;

    }
	
	// Update is called once per frame
	void Update ()
    {
        HandleInput();
	}

    void HandleInput()
    {
        accelerationX = Input.GetAxis("Horizontal") * Acceleration;
        accelerationZ = Input.GetAxis("Vertical") * Acceleration;

    }

    private void FixedUpdate()
    {
        HandlePhysics();
    }
    /*
    void HandlePhysics()
    {
        //Calculate velocity v = u + at
        velocityX = velocityX + accelerationX * Time.fixedDeltaTime;

        //Cap the velocity
        velocityX = Mathf.Clamp(velocityX, -MaxSpeed, MaxSpeed);

        //Faked Resistance
        velocityX = velocityX * Friction;

        //Calculate Displacement: s = ut + 0.5a(t^2)
        float displacementX = velocityX * Time.fixedDeltaTime + 0.5f * accelerationX * Time.fixedDeltaTime * Time.fixedDeltaTime;

        //Update position
        transform.position = transform.position + new Vector3(displacementX, 0.0f, 0.0f);
    }
    */

    void HandlePhysics()
    {
        HandleSUVAT(velocityX, accelerationX, Vector3.right);
        HandleSUVAT(velocityZ, accelerationZ, Vector3.forward);
    }

    void HandleSUVAT(float velocity, float acceleration, Vector3 direction)
    {
        
        //Calculate velocity v = u + at
        velocity = velocity + acceleration * Time.fixedDeltaTime;

        //Cap the velocity
        velocity = Mathf.Clamp(velocity, -MaxSpeed, MaxSpeed);

        //Faked Resistance
        velocity = velocity * Friction;
 
        //Calculate Displacement: s = ut + 0.5a(t^2)
        float displacement = velocity * Time.fixedDeltaTime + 0.5f * acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        //Update position
        transform.position = transform.position + direction * displacement;
        
    }
}
