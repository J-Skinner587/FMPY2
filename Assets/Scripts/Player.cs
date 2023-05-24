using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    public float mouseSensitivity;

    public new static Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }
    void Update()
    { 
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        rigidbody.MovePosition(transform.position + (Input.GetAxis("Vertical") * moveSpeed * transform.forward) + (Input.GetAxis("Horizontal") * moveSpeed * transform.right));
    }

    void Disabled()
    {
        Debug.LogWarning("You have been caught!");
    }

    private void OnDestroy()
    {
        StationaryGuard.OnGuardHasSpottedPlayer -= Disabled;
    }
}
