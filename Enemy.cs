using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float _speed;

    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private Vector3 _finishPosition;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 startPosition, Quaternion rotation, Color color, Vector3 rigidbody, Vector3 finishPosition)
    {
        transform.position = startPosition;
        transform.rotation = rotation;
        _renderer.material.color = color;
        _rigidbody.velocity = rigidbody;
        _finishPosition = finishPosition;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _finishPosition, _speed * Time.deltaTime);
    }
}

