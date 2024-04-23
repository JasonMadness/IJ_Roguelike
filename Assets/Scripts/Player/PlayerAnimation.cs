using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string SPEED = "Speed";
    
    [SerializeField] private Animator _animator;
    
    private float _idleSpeed = 0.0f;
    private float _runSpeed = 1.0f;

    public void Animate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Run();
        }
        else
        {
            Stop();
        }
    }
    
    private void Run()
    {
        _animator.SetFloat(SPEED, _runSpeed);
    }

    private void Stop()
    {
        _animator.SetFloat(SPEED, _idleSpeed);
    }
}
