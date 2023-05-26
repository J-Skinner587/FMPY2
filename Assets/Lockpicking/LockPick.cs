using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public Camera cam;
    public Transform innerLock;
    public Transform pickPosition;

    public GameObject player;

    Camera cam1;
    Camera cam2;

    public float maxAngle = 90;
    public float lockSpeed = 10;

    [Range(1, 25)]
    public float lockRange = 10;

    private float eulerAngle;
    private float unlockAngle;
    private Vector2 unlockRange;

    private float keyPressTime = 0;

    private bool movePick = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        cam1 = GameObject.FindWithTag("LockCam").GetComponent<Camera>();
        cam2 = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();

        cam2.enabled = cam2.enabled;

        cam1.enabled = !cam1.enabled;


        NewLock();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pickPosition.position;

        if (movePick)
        {
            Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

            eulerAngle = Vector3.Angle(dir, Vector3.up);

            Vector3 cross = Vector3.Cross(Vector3.up, dir);
            if (cross.z < 0) { eulerAngle = -eulerAngle; }

            eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

            Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
            transform.rotation = rotateTo;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movePick = false;
            keyPressTime = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movePick = true;
            keyPressTime = 0;
        }

        float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
        float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
        float maxRotation = (percentage / 100) * maxAngle;

        float lockLerp = Mathf.LerpAngle(innerLock.eulerAngles.z, lockRotation, Time.deltaTime * lockSpeed);
        innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

        if (lockLerp >= maxRotation - 1)
        {
            if (eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
            {
                Debug.Log("Unlocked!");
                movePick = true;
                keyPressTime = 0;

                player.SetActive(true);

                cam1.enabled = false;

                Cursor.lockState = CursorLockMode.Locked;
                player.SetActive(true);


                NewLock();
            }
            if (keyPressTime == 1)
            {

                float randomRotation = Random.insideUnitCircle.x;
                transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));
            }
        }
    }

    public void NewLock()
    {
        Debug.Log("new lock made!");
        unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
    }
}
