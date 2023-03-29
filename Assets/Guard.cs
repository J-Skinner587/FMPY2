using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    //hold the transform of way points
    public Transform pathHolder;
    //array of way points
    Vector3[] wayPoints;
    //use to move the guard
    public int moveSpeed;
    //to rotate the guard
    public int rotateSpeed = 5;
    //to wait frame
    public float waitEveryFrame = 0.5f;

    private Animator anim = null; 
    // Use this for initialization
    void Start()
    {
        //initialize the waypoint
        wayPoints = new Vector3[pathHolder.childCount];
        //save the value to the wayPoints
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = pathHolder.GetChild(i).position;
            wayPoints[i] = new Vector3(wayPoints[i].x, transform.position.y, wayPoints[i].z);
        }
        StartCoroutine(flollowPath());
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        if(anim == null)
        {
            Debug.LogError("Animator is Null");
        }

    }
    //follow the path continuously 
    IEnumerator flollowPath()
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
    }
    // Update is called once per frame
    void Update()
    {

    }
}