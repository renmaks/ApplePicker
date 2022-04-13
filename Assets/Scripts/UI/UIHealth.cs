using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private Text _hp;

    private void Awake()
    {
        _hp = GetComponent<Text>();
        _hp.text = "HP: " + GameManager.BASKETS_COUNT;
        UIManager.OnBasketDestroy.AddListener(ChangeHPText);
    }

    private void ChangeHPText(int hp)
    {
        _hp.text = "HP: " + hp;
    }

    private void OnDisable()
    {
        UIManager.OnBasketDestroy.RemoveListener(ChangeHPText);
    }
}
