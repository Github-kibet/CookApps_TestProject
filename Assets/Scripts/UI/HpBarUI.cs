using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
    private Slider hpSlider;

    private void Start()
    {
        hpSlider = GetComponent<Slider>();
    }

    public void SetHp(float amount)
    {
        hpSlider.value = amount;
    }
}
