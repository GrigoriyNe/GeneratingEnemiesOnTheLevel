using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private int _delayCreating = 2;
    private Coroutine _coroutine;

    private void Update()
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
            var finishPosition = GetRandomFinishPosition();
            var rotation = Quaternion.identity;
            var color = Color.yellow;
            var rigidbody = Vector3.zero;

            enemy.Init(startPosition, rotation, color, rigidbody, finishPosition);

            yield return new WaitForSeconds(_delayCreating);
        }
    }

    private Vector3 GetRandomStartPosition()
    {
        int minRandomValue = -10;
        int maxRandomValue = 10;
        System.Random random = new System.Random();
        int valueRandom = random.Next(minRandomValue, maxRandomValue);

        return new Vector3(
            this.transform.position.x + valueRandom,
            this.transform.position.y,
            this.transform.position.z + valueRandom);
    }

    private Vector3 GetRandomFinishPosition()
    {
        int minRandomValue = -50;
        int maxRandomValue = 50;

        int valueRandomX = GetRandomValue(minRandomValue, maxRandomValue);
        int valueRandomY = GetRandomValue(minRandomValue, maxRandomValue);

        return new Vector3(
            this.transform.position.x + valueRandomX,
            this.transform.position.y,
            this.transform.position.z + valueRandomY);
    }

    private int GetRandomValue(int minRandomValue, int maxRandomValue)
    {
        System.Random randomFinishX = new System.Random();
        return randomFinishX.Next(minRandomValue, maxRandomValue +1 );
    }
}
