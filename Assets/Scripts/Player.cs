using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    public float mouseSensitivity;

    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    Vector3 velocity;

    new Rigidbody rigidbody;
    bool disabled; 

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Guard.OnGuardHasSpottedPlayer += Disabled;
        StationaryGuard.OnGuardHasSpottedPlayer += Disabled;
    }
    void Update()
    {
        Vector3 inputDirection = Vector3.zero;
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        rigidbody.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
    }

    void Disabled()
    {
        Debug.LogWarning("You have been caught!");
    }

    private void OnDestroy()
    {
        Guard.OnGuardHasSpottedPlayer -= Disabled;
        StationaryGuard.OnGuardHasSpottedPlayer -= Disabled;
    }
}