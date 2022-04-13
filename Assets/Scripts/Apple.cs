using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;

    void Update()
    {
        if(transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();
        }
    }

}
