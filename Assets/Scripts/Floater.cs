using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    private void FixedUpdate()
    {
        //if floaters y position is less then 0 it means it is underwater and needs to have boyaunt force applied
        if (transform.position.y < 0f )
        {
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged)*displacementAmount;
            rigidbody.AddForce(new Vector3());
        }
    }
}
