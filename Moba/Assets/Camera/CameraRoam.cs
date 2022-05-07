using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    public float CamSpeed = 20;
    public float ScreenSizeThickness = 10;

    public static bool roam = true;

    void Update()
    {
        if (roam == true)
            move();
    }

    public void move()
    {
        Vector3 pos = transform.position;

        //up
        if (Input.mousePosition.y >= Screen.height - ScreenSizeThickness)
        {
            pos.z += CamSpeed * Time.deltaTime;
        }

        //down
        if (Input.mousePosition.y <= ScreenSizeThickness)
        {
            pos.z -= CamSpeed * Time.deltaTime;
        }

        //right
        if (Input.mousePosition.x >= Screen.width - ScreenSizeThickness)
        {
            pos.x += CamSpeed * Time.deltaTime;
        }

        //left
        if (Input.mousePosition.x <= ScreenSizeThickness)
        {
            pos.x -= CamSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
