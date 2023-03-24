using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour 
{
    public ItemType type;

    protected abstract void OnGotten(GameObject player);
    private void OnCollisionEnter(Collision collision) => OnGotten(collision.gameObject);
}