using UnityEngine;
using UnityEngine.UI;

public class ForceIndicatorScript : MonoBehaviour
{
    [SerializeField] private Image indicatorFg;
    public static float forceFactor;
    [SerializeField] private float maxForce = 300f;  // Максимальная сила (длина вектора)
    [SerializeField] private float sensitivity = 0.01f;

    private void Start()
    {
        forceFactor = indicatorFg.fillAmount;
    }

    private void Update()
    {
        // Рассчитываем длину вектора силы и нормализуем его по отношению к maxForce
        float normalizedForce = Mathf.Clamp(Diamondscript.currentForce.magnitude / maxForce, 0.0f, 1.0f);

        // Обновляем fillAmount индикатора и forceFactor
        indicatorFg.fillAmount = normalizedForce;
        forceFactor = normalizedForce;
    }
}