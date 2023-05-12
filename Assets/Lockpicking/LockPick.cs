using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public Camera cam;
    public GameObject lockCam;
    public Transform innerLock;
    public Transform pickPosition;

    opencloseDoor door;

    public GameObject player;

    public float maxAngle = 90;
    public float lockSpeed = 10;

    [Range(1,25)]
    public float lockRange = 10;

    private float eulerAngle;
    private float unlockAngle;
    private Vector2 unlockRange;

    private float keyPressTime = 0;

    private bool movePick = true;

    private void Start()
    {
        newLock();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pickPosition.position;

        if(movePick)
        {
            Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

            eulerAngle = Vector3.Angle(dir, Vector3.up);

            Vector3 cross = Vector3.Cross(Vector3.up, dir);
            if (cross.z < 0) { eulerAngle = -eulerAngle; }

            eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

            Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
            transform.rotation = rotateTo;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            movePick = false;
            keyPressTime = 1;
            
            //if cam is active do this
            player.GetComponent<CharacterController>().enabled = false;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            movePick = true;
            keyPressTime = 0;

        }

        float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
        float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
        float maxRotation = (percentage / 100) * maxAngle;

        float lockLerp = Mathf.LerpAngle(innerLock.eulerAngles.z, lockRotation, Time.deltaTime * lockSpeed);
        innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

        if(lockLerp >= maxRotation -1)
        {
            if (eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
            {
                Debug.Log("Unlocked!");
                lockCam.SetActive(false);
                movePick = true;
                keyPressTime = 0;
                Cursor.lockState = CursorLockMode.Locked;
                player.GetComponent<CharacterController>().enabled = true;
            }
            if(keyPressTime == 1)
            {
                
                float randomRotation = Random.insideUnitCircle.x;
                transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));
            }
        }
    }

    public void newLock()
    {
        Debug.Log("new lock made!");
        unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
    }
}
