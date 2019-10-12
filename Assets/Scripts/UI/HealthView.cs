using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    public Image healthBar;
    public Gradient BarColor;
    public Image HealthImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;

        HealthImage.color = BarColor.Evaluate(fillAmount);
    }
}
