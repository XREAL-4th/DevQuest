using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image HealthbarSprite;
    [SerializeField] private GameObject FloatingText;

    private float lerpDuration = 0.5f;

    public void UpdateHealthBar(float MaxHealth, float CurrentHealth, float Damage)
    {
        if (Damage > 0)
        {
            GameObject cloneText = Instantiate(FloatingText, this.transform.position, this.transform.rotation);
            cloneText.GetComponent<FloatingText>().text.text = (-Damage).ToString();
            cloneText.transform.SetParent(this.transform);
            StartCoroutine(ChangeValueTo(MaxHealth, CurrentHealth));
        }
    }

    IEnumerator ChangeValueTo(float MaxHealth, float CurrentHealth)
    {
        float timeElapsed = 0;
        float value = HealthbarSprite.fillAmount;
        while(timeElapsed < lerpDuration)
        {
            HealthbarSprite.fillAmount = Mathf.Lerp(value, (float)CurrentHealth / MaxHealth, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        HealthbarSprite.fillAmount = (float)CurrentHealth / MaxHealth;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
