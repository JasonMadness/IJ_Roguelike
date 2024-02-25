using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private float _floorOffset = 1.0f;

    public void Fire(Vector3 target)
    {
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        } 
        
        if (other.gameObject.TryGetComponent(typeof(Wall), out _))
        {
            Destroy(gameObject);
        }  
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, _floorOffset, transform.position.z);
    }
}