using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] public float _speed;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private Vector3 _randomDirection;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Init(Vector3 startPosition, Quaternion rotation, Color color, Vector3 rigidbody, Vector3 randomDirection)
    {
        transform.position = startPosition;
        transform.rotation = rotation;
        _renderer.material.color = color;
        _rigidbody.velocity = rigidbody;
        _randomDirection = randomDirection;
    }

    private void Move()
    {
        transform.Translate(_randomDirection * _speed * Time.fixedDeltaTime);
    }
}
