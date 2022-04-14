using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Floater : MonoBehaviour
{
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Rigidbody rigidbody;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public float floaterCount = 1;
    public float waterDrag = .99f;
    public float waterAngularDrag = 0.5f;

    private void FixedUpdate()
    {
        rigidbody.AddForceAtPosition(Physics.gravity/floaterCount,transform.position,ForceMode.Acceleration);

        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        //if floaters y position is less then 0 it means it is underwater and needs to have boyaunt force applied
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount; // clamped at  0 to 1 since if an object is submereged its boyaunt force is constant/
            rigidbody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier,0f),transform.position , ForceMode.Acceleration);//acceleration used since boyancecy shopuld not be affected by mass 
            // calculations for force of drag on floater
            rigidbody.AddForce(displacementMultiplier * -rigidbody.velocity * waterDrag * Time.fixedDeltaTime,ForceMode.VelocityChange);
            rigidbody.AddTorque(displacementMultiplier * -rigidbody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
