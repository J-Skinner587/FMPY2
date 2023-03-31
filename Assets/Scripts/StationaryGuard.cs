using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryGuard : MonoBehaviour
{
    public static event System.Action OnGuardHasSpottedPlayer;

    Transform player;
    Color originalSpotlightColour;

    public float timeToSpotPlayer = .5f;

    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;

    float viewAngle;
    float playerVisibleTimer;

    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            playerVisibleTimer += Time.deltaTime;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
        }
        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if (playerVisibleTimer >= timeToSpotPlayer)
        {
            if (OnGuardHasSpottedPlayer != null)
            {
                OnGuardHasSpottedPlayer();
            }
        }
    }

    bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
    //to draw gizmos and line
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}