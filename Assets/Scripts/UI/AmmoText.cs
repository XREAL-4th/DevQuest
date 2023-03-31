using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentAmmoText, maxAmmoText, maganizeText;

    private void Update()
    {
        currentAmmoText.SetText(Player.Main.shooter.weapon.ammo.ToString());
        maxAmmoText.SetText(Player.Main.shooter.weapon.type.ammoPerMaganize.ToString());
        maganizeText.SetText($"x {Player.Main.shooter.weapon.maganizes}");
    }
}
