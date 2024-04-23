using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _angle;

    private void Update()
    {
        transform.Rotate(Vector3.forward, _angle * Time.deltaTime);
    }
}
