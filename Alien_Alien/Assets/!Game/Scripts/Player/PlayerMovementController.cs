using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController: MonoBehaviour
{
    [SerializeField]
    private FixedJoystick m_moveJoystick;

    private float moveSpeed = 0.6f;


    void FixedUpdate()
    {
        UpdateMoveJoystick();
        UpdateLookJoystick();
    }

    void UpdateMoveJoystick()
    {
        float horizontalMove =  m_moveJoystick.Horizontal;
        float verticalMove = -m_moveJoystick.Vertical;
        Vector2 convertedXY =  ConvertMoveViewToCamera(Camera.main.transform.position,horizontalMove,verticalMove);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        transform.Translate(direction * moveSpeed, Space.World);
    }

    void UpdateLookJoystick()
    {
        float horizontalMove =  m_moveJoystick.Horizontal;
        float verticalMove = m_moveJoystick.Vertical;
        Vector2 convertedXY =  ConvertMoveViewToCamera(Camera.main.transform.position,horizontalMove,verticalMove);
        Vector3 direction = new Vector3(convertedXY.x, 0, -convertedXY.y).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }

    private Vector2 ConvertMoveViewToCamera(Vector3 cameraPosition, float horizontal, float vertical)
    {
        Vector2 joystickDirection = new Vector2(horizontal, vertical).normalized;
        Vector2 camera2DPosition = new Vector2(cameraPosition.x, cameraPosition.z);
        Vector2 cameraToPlayer = (Vector2.zero - camera2DPosition).normalized;
        float angle = Vector2.SignedAngle(cameraToPlayer, new Vector2(0,1));
        Vector2 finalDirection = RotateVector(joystickDirection, -angle);
        return finalDirection;
    }

    private Vector2 RotateVector(Vector2 vector, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = vector.x * Mathf.Cos(radian) - vector.y * Mathf.Sin(radian);
        float _y = vector.x * Mathf.Sin(radian) - vector.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }
}
