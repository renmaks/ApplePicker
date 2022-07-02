using UnityEngine.Events;

public class UIManager
{
    public static UnityEvent<int> OnBasketDestroy = new();
    public static UnityEvent OnApplePick = new();

    public static void SendBasketDestroy(int hp)
    {
        OnBasketDestroy.Invoke(hp);
    }

    public static void SendApplePick()
    {
        OnApplePick.Invoke();
    }
}
