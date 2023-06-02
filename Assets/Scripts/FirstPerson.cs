using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float xSens;
    public float ySens;

    public Transform orientation;

    float xRot;
    float yRot;

    // Start is called before the first frame update
    private void Start()
    {
        //cursor locked in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * ySens;

        yRot += mouseX;

        xRot -= mouseY;
        //clamp rotation so that looking up and down stops at ceiling and floor
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
