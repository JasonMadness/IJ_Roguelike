using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField] private float _vertical;
    [SerializeField] private float _horizontal;

    public Vector3 Get()
    {
        return new Vector3(_horizontal, 0.0f, _vertical);
    }
}
