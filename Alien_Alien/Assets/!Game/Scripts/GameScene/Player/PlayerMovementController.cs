using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController: MonoBehaviour
{
    [SerializeField]
    private FixedJoystick m_moveJoystick;
    [SerializeField]
    private Rigidbody m_rb;
    [SerializeField]
    private Transform m_body;

    private PlayerAttributes m_playerAttributes;

    private float m_startMoveSpeed = 10f;
    private float m_moveSpeed = 10f;
    private float m_maxMoveSpeed = 20f;
    private float m_rotateSpeed = 4;
    private float m_maxXAngle = 10;
    private float m_lowSpeedBreak = 0.95f;
    private float m_speedBreak = 0.99f;


    private void Awake()
    {
        m_playerAttributes = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerAttributes>();
        m_moveSpeed = m_playerAttributes.Acceleration;
        m_maxMoveSpeed = m_playerAttributes.MaxSpeed;
        m_rotateSpeed = m_playerAttributes.RotateSpeed;
        m_maxXAngle = m_playerAttributes.MaxXAngle;
        InvokeRepeating("UpdateSpeed", 0, 0.5f);
    }

    void FixedUpdate()
    {
        UpdateMoveJoystick();
        UpdateLookJoystick();
        MaxSpeedControl();
        AnimateBody();
    }

    void UpdateMoveJoystick()
    {
        float horizontalMove =  m_moveJoystick.Horizontal;
        float verticalMove = -m_moveJoystick.Vertical;
        Vector2 convertedXY =  ConvertMoveViewToCamera(Camera.main.transform.position,horizontalMove,verticalMove);
        Vector3 direction = new Vector3(convertedXY.x, 0, convertedXY.y).normalized;
        m_rb.AddForce(direction * m_moveSpeed);   //transform.Translate(direction * moveSpeed, Space.World);
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

    private void MaxSpeedControl()
    {
        m_rb.velocity = m_rb.velocity * m_speedBreak;
        if (m_rb.velocity.magnitude > m_maxMoveSpeed)
        {
            m_rb.velocity = m_rb.velocity * m_lowSpeedBreak;
        }
        else if (m_rb.velocity.magnitude<1 && m_moveJoystick.Direction == Vector2.zero)
        {
            m_rb.velocity *= 0;
        }
    }

    private void AnimateBody()
    {
        float rotationX = 0;
        if (m_moveJoystick.Direction != Vector2.zero)
        {
            if (m_body.eulerAngles.x <= m_maxXAngle)
            {
                m_body.transform.Rotate(new Vector3(m_rotateSpeed, 0, 0) * Time.deltaTime);
                rotationX = Mathf.Clamp(m_body.eulerAngles.x, 0, m_maxXAngle);
                m_body.rotation = Quaternion.Euler(rotationX, m_body.eulerAngles.y, m_body.eulerAngles.z);
            }
        }
        else
        {
            if (m_body.eulerAngles.x <= m_maxXAngle+1 && m_body.eulerAngles.x != 0.0f)
            {
                if (m_body.eulerAngles.x > m_maxXAngle+1 || m_body.eulerAngles.x < 1)
                {
                    rotationX = 0;
                    m_body.rotation = Quaternion.Euler(rotationX, m_body.eulerAngles.y, m_body.eulerAngles.z);
                    return;
                }
                m_body.transform.Rotate(new Vector3(-m_rotateSpeed, 0, 0) * Time.deltaTime);
                rotationX = Mathf.Clamp(m_body.eulerAngles.x, 0, m_maxXAngle);
                m_body.rotation = Quaternion.Euler(rotationX, m_body.eulerAngles.y, m_body.eulerAngles.z);
            }
        }
    }

    private void UpdateSpeed()
    {
        if (m_startMoveSpeed+m_playerAttributes.MoveSpeedUp>m_moveSpeed)
        {
            m_moveSpeed += m_playerAttributes.MoveSpeedUp;
            m_maxMoveSpeed += m_playerAttributes.MoveSpeedUp;
        }
    }
}
