using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private GameObject _enemyAppleFrefab;

    private float _speed = 10f;
    private readonly float _leftAndRightEdge = 10f;
    private readonly float _chanceToChangeDirections = 0.1f;
    private readonly float _secondsBetweenApplesDrops = 1f;
    private readonly float _chanceToEnemyAppleDrop = 0.02f;

    private void Start()
    {
        Invoke(nameof(DropApple), 2f);
    }

    private void DropApple()
    {
        if(Random.value < _chanceToEnemyAppleDrop)
        {
            GameObject enemyApple = Instantiate<GameObject>(_enemyAppleFrefab);
            enemyApple.transform.position = transform.position;
            Invoke(nameof(DropApple), _secondsBetweenApplesDrops);
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(_applePrefab);
            apple.transform.position = transform.position;
            Invoke(nameof(DropApple), _secondsBetweenApplesDrops);
        }
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += _speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -_leftAndRightEdge)
        {
            _speed = Mathf.Abs(_speed); // Turn right
        }
        else if (pos.x > _leftAndRightEdge) // Turn left
        {
            _speed = -Mathf.Abs(_speed);
        }
    }

     private void FixedUpdate()
    {
        if (Random.value < _chanceToChangeDirections)
        {
            _speed *= -1; // Change direction
        }
    }

}
