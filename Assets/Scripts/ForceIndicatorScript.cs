using UnityEngine;
using UnityEngine.UI;

public class ForceIndicatorScript : MonoBehaviour
{
    public static float forceFactor;
    
    [SerializeField]
    private Image indicatorFg;
   
    [SerializeField]
    private float sensitivity = 0.01f;

    void Start()
    {
        forceFactor = indicatorFg.fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * sensitivity;
        if (dx != 0)
        {
            indicatorFg.fillAmount = Mathf.Clamp(indicatorFg.fillAmount + dx, 0.1f, 1.0f);
            forceFactor = indicatorFg.fillAmount;
        }
    }
}