using UnityEngine;
using UnityEngine.UI;

public class ExpBarUI : MonoBehaviour
{
    [SerializeField] private Text levelLabel;
    private Slider expSlider;

    private void Awake()
    {
        expSlider = GetComponent<Slider>();
    }

    public void SetEXP(float amount)
    {
        expSlider.value = amount;
    }

    public void SetLevel(int level)
    {
        levelLabel.text = "Level: " + level.ToString();
    }
}
