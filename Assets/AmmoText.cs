using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        text.SetText($"{Player.Main.shooter.weapon.ammo} / {Player.Main.shooter.weapon.maxAmmo}");
    }
}
