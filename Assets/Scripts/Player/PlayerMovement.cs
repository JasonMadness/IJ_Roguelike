using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    [SerializeField] private float _speed;
    [SerializeField] private Boundaries _boundaries;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private Vector3 _borders;
    private Vector3 _direction;

    public Vector3 Direction => _direction;

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
        float horizontalDirection = UnityEngine.Input.GetAxisRaw(HORIZONTAL);
        float verticalDirection = UnityEngine.Input.GetAxisRaw(VERTICAL);
        _direction = new Vector3(horizontalDirection, 0.0f, verticalDirection);
        transform.position += _direction * _speed * Time.deltaTime;

        /*if (_direction != Vector3.zero)
        {
            _playerAnimation.Run();
        }
        else
        {
            _playerAnimation.Stop();
        }*/
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
