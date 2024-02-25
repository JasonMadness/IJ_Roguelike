using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private Boundaries _boundaries;

    private Vector3 _borders;

    private void Start()
    {
        GetBorders();
    }

    private void GetBorders()
    {
        _borders = _boundaries.Get();
    }
    
    private void Move()
    {
        float horizontalDirection = Input.GetAxis(HORIZONTAL);
        float verticalDirection = Input.GetAxis(VERTICAL);
        Vector3 direction = new Vector3(horizontalDirection, 0.0f, verticalDirection);
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void ClampPosition()
    {
        Vector3 oldPosition = transform.position;
        float positionX = Math.Clamp(oldPosition.x, -_borders.x, _borders.x);
        float positionY = oldPosition.y;
        float positionZ = Math.Clamp(oldPosition.z, -_borders.z, _borders.z);
        Vector3 newPosition = new Vector3(positionX, positionY, positionZ);
        transform.position = newPosition;
    }
    
    private void Update()
    {
        Move();
        ClampPosition();
    }
}
