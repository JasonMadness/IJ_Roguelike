using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    public Vector3 GetDirection()
    {
        float horizontalInput = UnityEngine.Input.GetAxisRaw(HORIZONTAL);
        float verticalInput = UnityEngine.Input.GetAxisRaw(VERTICAL);
        Vector3 direction = new Vector3(horizontalInput, 0.0f, verticalInput);
        return direction;
    }
}
