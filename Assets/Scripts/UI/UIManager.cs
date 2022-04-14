using UnityEngine.Events;

public class UIManager
{
    public static UnityEvent<int> OnBasketDestroy = new UnityEvent<int>();
    public static UnityEvent OnApplePick = new UnityEvent();

    public static void SendBasketDestroy(int hp)
    {
        OnBasketDestroy.Invoke(hp);
    }

    public static void SendApplePick()
    {
        OnApplePick.Invoke();
    }
}
