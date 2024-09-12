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

            var startPosition = GetRandomStartPosition();
            var randomDirection = GetRandomDirection();
            var rotation = Quaternion.identity;
            var color = Color.yellow;
            Vector3 rigidbody = Vector3.zero;

            enemy.Init(startPosition, rotation, color, rigidbody, randomDirection);

            WaitForSeconds wait = new WaitForSeconds(_delayCreating);

            yield return wait;
        }
    }

    private Vector3 GetRandomDirection()
    {
        int minRandomValueNegativeOutside = -150;
        int maxRandomValueNegativeOutside = -125;
        
        int minRandomValuePositiveOutside = 125;
        int maxRandomValuePositiveOutside = 150;

        int positiveOutside = Random.Range(minRandomValuePositiveOutside, maxRandomValuePositiveOutside);
        int negativeOutside = Random.Range(minRandomValueNegativeOutside, maxRandomValueNegativeOutside);

        int directionX;
        int directionZ;

        int randomVaribleForMove = Random.Range(1, 5);

        switch (randomVaribleForMove)
        {
            case 1:
                directionX = positiveOutside;
                directionZ = Random.Range(maxRandomValueNegativeOutside, minRandomValuePositiveOutside);

                return new Vector3(directionX, transform.position.y, directionZ);

            case 2:
                directionX = negativeOutside;
                directionZ = Random.Range(maxRandomValueNegativeOutside, minRandomValuePositiveOutside);

                return new Vector3(directionX, transform.position.y, directionZ);

            case 3:
                directionX = Random.Range(maxRandomValueNegativeOutside, minRandomValuePositiveOutside);
                directionZ = positiveOutside;

                return new Vector3(directionX, transform.position.y, directionZ);

            case 4:
                directionX = Random.Range(maxRandomValueNegativeOutside, minRandomValuePositiveOutside);
                directionZ = negativeOutside;

                return new Vector3(directionX, transform.position.y, directionZ);
        }

        return new Vector3();
    }

    private Vector3 GetRandomStartPosition()
    {
        int minRandomValue = -15;
        int maxRandomValue = 15;

        return new Vector3(
            transform.position.x + Random.Range(minRandomValue, maxRandomValue),
            transform.position.y,
            transform.position.z + Random.Range(minRandomValue, maxRandomValue));
    }
}
