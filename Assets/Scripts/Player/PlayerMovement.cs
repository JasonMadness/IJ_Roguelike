using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float _speed;

    private void Move()
    {
        float horizontalDirection = Input.GetAxis(HORIZONTAL);
        float verticalDirection = Input.GetAxis(VERTICAL);
        Vector3 direction = new Vector3(horizontalDirection, 0.0f, verticalDirection);
        transform.position += direction * _speed * Time.deltaTime;
    }
    
    private void Update()
    {
        Move();
    }
}
