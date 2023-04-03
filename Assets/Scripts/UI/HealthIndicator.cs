using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [Header("Preset")]
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private ProgressBar bar;


    private bool GetCurrentTarget(out Enemy res)
    {
        res = null;

        Weapon weapon = Player.Main.shooter.weapon;
        BulletType type = weapon.GetBulletType();
        Ray ray = new (Camera.main.ScreenToWorldPoint(Aim.Main.transform.position), weapon.outTransform.right);
        Physics.SphereCast(ray, type.radius, out RaycastHit hit, type.lifetime * type.bulletSpeed, ~(1 << 7));

        if (hit.transform == null) return false;
        res = hit.transform.GetComponent<Enemy>();
        return res != null;
    }

    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            timer = 0;
            if (GetCurrentTarget(out Enemy enemy))
            {
                text.text = enemy.name;
                bar.gameObject.SetActive(true);
                bar.progress = enemy.Health / enemy.MaxHealth;
            } else
            {
                text.text = "";
                bar.gameObject.SetActive(false);
            }
        }
    }
}
