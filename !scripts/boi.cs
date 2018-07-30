using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallController : MonoBehaviour
{

    public float Acceleration = -9.81f;
    public float Friction = 1.0f;
    public float MaxSpeed = -10.0f;


    float acceleration = -9.81f;
    float velocity;



    // Use this for initialization
    void Start()
    {

        velocity = 0.0f;

    }

    private void Update()
    {
        if (transform.position.y <= -10.0f)
        {
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        HandlePhysics();

    }

    void HandlePhysics()
    {
        HandleSUVAT(ref velocity, ref acceleration, Vector3.down);
    }

    void HandleSUVAT(ref float velocity, ref float acceleration, Vector3 direction)
    {
        velocity = velocity + acceleration * Time.fixedDeltaTime;

        velocity = Mathf.Clamp(velocity, -MaxSpeed, MaxSpeed);

        float displacement = velocity * Time.fixedDeltaTime + 0.5f * acceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        velocity = velocity * Friction;

        transform.position = transform.position + direction * displacement;

    }
}