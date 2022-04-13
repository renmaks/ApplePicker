using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для создания яблок
    public GameObject applePrefab;
    public GameObject enemyAppleFrefab;

    // Скорость движения яблони
    public float speed = 10f;

    // Расстояние, на котором должно изменяться направление яблони
    public float leftAndRightEdge = 10f;

    // Вероятность случайного изменения направления движения
    public float chanceToChangeDirections = 0.1f;

    // Частота создания экземпляров яблок
    public float secondsBetweenApplesDrops = 1f;
    public float chanceToEnemyAppleDrop = 0.02f;


    private void Start()
    {
        // Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

   
    private void DropApple()
    {
        if(Random.value < chanceToEnemyAppleDrop)
        {
            GameObject enemyApple = Instantiate<GameObject>(enemyAppleFrefab);
            enemyApple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenApplesDrops);
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenApplesDrops);
        }
    }

    private void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Изменение направления
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Начать движение вправо
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Начать движение влево
        }
    }

     private void FixedUpdate()
    {
        // Случайная смена направления привязана ко времени, потому что выполняется в FixedUpdate
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Изменить направление
        }
    }

}
