using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform pathHolder;
    Color originalSpotlightColour;

    public GameObject CaughtUI;
    public GameObject GameUI;
    public GameObject Player;

    Vector3[] wayPoints;

    public int moveSpeed;
    public int rotateSpeed = 5;
    public float waitEveryFrame = 0.5f;
    public float timeToSpotPlayer = .5f;

    public Light spotlight;
    public float viewDistance;
    public LayerMask viewMask;
  
    float viewAngle;
    public float playerVisibleTimer;


    private Animator anim;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(true);
        CaughtUI.gameObject.SetActive(false);
        GameUI.gameObject.SetActive(true);
        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;
        //initialize the waypoint
        wayPoints = new Vector3[pathHolder.childCount];
        //save the value to the wayPoints
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = pathHolder.GetChild(i).position;
            wayPoints[i] = new Vector3(wayPoints[i].x, transform.position.y, wayPoints[i].z);
        }
        StartCoroutine(followPath());
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(CanSeePlayer()) 
        {
            playerVisibleTimer += Time.deltaTime;
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
        }
        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if(playerVisibleTimer >= timeToSpotPlayer)
        {
            OnGuardHasSpottedPlayer();
        }
    }

    bool CanSeePlayer()
    {
        if(Vector3.Distance(transform.position,Player.transform.position) < viewDistance)
        {
            Vector3 dirToPlayer = (Player.transform.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle (transform.forward, dirToPlayer);
            if(angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if(!Physics.Linecast (transform.position,Player.transform.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
    //follow the path continuously 
    IEnumerator followPath()
    {   //set the positiuon to starting pos
        transform.position = wayPoints[0];
        //keep track of the index
        int wayPointIndex = 1;
        //set it to wayPoint[1]
        Vector3 targetWaypoint = wayPoints[wayPointIndex];
        transform.LookAt(targetWaypoint);
        while (true)
        {//move to next pos
            transform.position = Vector3.MoveTowards(transform.position,
                targetWaypoint, moveSpeed * Time.deltaTime);



            //if reaches the next pos
            if (transform.position == targetWaypoint)
            {   //loop will go 1,2,3,4,5,6 and when it reaches 6
                //if length is also 6 then 6%6 = 0
                wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;

                //give the new waypoint value to targetWayPoint
                targetWaypoint = wayPoints[wayPointIndex];
                //wait for sec
                yield return new WaitForSeconds(waitEveryFrame);
                yield return StartCoroutine(rotateThePlayer(targetWaypoint));
                /* //will rotate  the player
                  Vector3 direction = (targetWaypoint - transform.position).normalized;
                   Vector3 rotation = Quaternion.LookRotation(direction).eulerAngles;
                  // rotation = Vector3.Lerp(transform.rotation.eulerAngles, rotation, rotateSpeed * Time.deltaTime);
                   transform.rotation =Quaternion.Euler( rotation);
               */
            }
            //wait for 1 frame
            yield return null;
        }

    }

    IEnumerator rotateThePlayer(Vector3 target)
    {   //direction is target - self position and normalize it
        Vector3 direction = (target - transform.position).normalized;
        //if know direction then angle can be find using atan2
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //if angle is greater than 0.05
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05)
        {   //move toward angle from a to b
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, rotateSpeed * Time.deltaTime);
            //change the angle of the guard
            transform.eulerAngles = transform.up * angle;
            //wai for sec
            yield return null;
        }
    }
    //to draw gizmos and line
    private void OnDrawGizmos()
    {
        Vector3 startPos = pathHolder.GetChild(0).position;
        Vector3 previousPos = startPos;
        foreach (Transform wayPoint in pathHolder)
        {
            Gizmos.DrawSphere(wayPoint.position, .5f);
            Gizmos.DrawLine(previousPos, wayPoint.position);
            previousPos = wayPoint.position;
        }
        Gizmos.DrawLine(previousPos, startPos);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,transform.forward * viewDistance);
    }

    public void OnGuardHasSpottedPlayer()
    {
        Debug.Log("Caught");
        CaughtUI.gameObject.SetActive(true);
        GameUI.gameObject.SetActive(false);
        Player.gameObject.SetActive(false);
    }
}