using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedStatusEffect", menuName = "StatusEffects/SpeedStatusEffect", order = 1)]
public class SpeedStatusEffect : StatusEffect
{
    public float speedMultiplier = 1.5f;


    public override void OnActive(GameObject player)
    {
        if (player.GetComponent<MoveControl>() is not MoveControl mover) return;
        mover.moveMultiplier += speedMultiplier;
        Aim.Main.speedImage.SetActive(true);
    }

    public override void OnInActive(GameObject player)
    {
        if (player.GetComponent<MoveControl>() is not MoveControl mover) return;
        mover.moveMultiplier -= speedMultiplier;
        Aim.Main.speedImage.SetActive(false);
    }
}
