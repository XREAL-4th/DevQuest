using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Presets")]
    public ItemType type;

    protected abstract void OnGotten(GameObject player);

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        OnGotten(other.gameObject);
        Destroy(gameObject);
    }
}