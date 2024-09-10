using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private int _delayCreating = 2;
    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(CreateWhithDelay());
    }

    private IEnumerator CreateWhithDelay()
    {
        while (enabled)
        {
            Enemy enemy = Instantiate(_enemy);

            var startPosition = GetRandomVector();
            var randomDirection = GetRandomVector();
            var rotation = Quaternion.identity;
            var color = Color.yellow;
            var rigidbody = Vector3.zero;

            enemy.Init(startPosition, rotation, color, rigidbody, randomDirection);

            yield return new WaitForSeconds(_delayCreating);
        }
    }

    private Vector3 GetRandomVector()
    {
        int minRandomValue = -5;
        int maxRandomValue = 5;

        return new Vector3(
            transform.position.x + GetRandomValue(minRandomValue, maxRandomValue),
            transform.position.y,
            transform.position.z + GetRandomValue(minRandomValue, maxRandomValue));
    }

    private int GetRandomValue(int minRandomValue, int maxRandomValue)
    {
        return Random.Range(minRandomValue, maxRandomValue + 1);
    }
}
