using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthImage;
    [SerializeField] Agent agent;

    void Awake()
    {
        agent.HealthChanged += OnHeathChanged;
    }

    void OnDestroy()
    {
        agent.HealthChanged -= OnHeathChanged;
    }


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    private void OnHeathChanged() => UpdateUI(agent.HealthRate);

    public void UpdateUI(float healthRate)
    {
        healthImage.fillAmount = healthRate;
    }
}
