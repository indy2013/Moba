
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothspeed = 0.125f;

    private void LateUpdate()
    {
        transform.position = target.position;
    }
}
