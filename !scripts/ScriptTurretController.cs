using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTurretController : MonoBehaviour {
    public float MaxAngularAcceleration = 0.5f;
    public float MaxAngularSpeed = 0.5f;
    public GameObject player;
    public float DetectionRange = 15.0f;
    public float FiringRange = 10f;
    public float FiringRate = 1.0f;

    float angularVelocity;
    float firingDelay;

	// Use this for initialization
	void Start () {

        angularVelocity = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
        if (IsWithinRange(FiringRange)) Fire();

        firingDelay = firingDelay - Time.deltaTime;

	}

    private void FixedUpdate()
    {
        if(IsWithinRange(DetectionRange)) HandleRotation();

    }

    void HandleRotation()
    {
        //Find direction from me to Player
        Vector3 targetDirection = player.transform.position - transform.position;

        //Find angular acceleration
        float angularAcceleration = Vector3.Angle(transform.forward, targetDirection);
        angularAcceleration = Mathf.Clamp(angularAcceleration, -MaxAngularAcceleration, MaxAngularAcceleration);


        //Find angular velocity: v = u + at
        angularVelocity = angularVelocity + angularAcceleration * Time.fixedDeltaTime;
        angularVelocity = Mathf.Clamp(angularVelocity, -MaxAngularSpeed, MaxAngularSpeed);

        //Find angular displacement: s = ut + 0.5a(t^2)
        float angularDisplacement = angularVelocity * Time.fixedDeltaTime + 0.5f * angularAcceleration * Time.fixedDeltaTime * Time.fixedDeltaTime;

        //Spin the turret
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, angularDisplacement, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    bool IsWithinRange(float range)
    {
        Vector3 vectorDifference = player.transform.position - transform.position;
        float distance = vectorDifference.magnitude;

        return distance <= range;
    }

    void Fire()
    {
        if (firingDelay <= 0.0f)
        {
            Debug.Log("Pew!");
            firingDelay = 1.0f / FiringRate;
        }
        

    }
}
