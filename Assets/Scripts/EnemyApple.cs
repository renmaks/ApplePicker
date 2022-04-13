using UnityEngine;

public class EnemyApple : MonoBehaviour
{
    private float _bottomY = -20f;


    void Update()
    {
        if (transform.position.y < _bottomY)
        {
            Destroy(this.gameObject);
        }
    }

}
