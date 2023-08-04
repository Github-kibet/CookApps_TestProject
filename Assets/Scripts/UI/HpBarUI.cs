using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
    private Slider hpSlider;

    private void Awake()
    {
        hpSlider = GetComponent<Slider>();
    }

    public void SetHp(float amount)
    {
        hpSlider.value = amount;
    }
}
