using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Transform playerHead;
    [SerializeField] private float spawnDistance = 2f;
    [SerializeField] private float yOffset = 0f;

    [SerializeField] private GameObject panel;

    private Vector3 _playerHeadForward;

    private void Awake()
    {
        _playerHeadForward = playerHead.forward;
    }

    private void Update()
    {
        // show the panel in front of the player
        var position = playerHead.position;
        //panel.transform.position = position + new Vector3(_playerHeadForward.x, yOffset, _playerHeadForward.z).normalized * spawnDistance;

        Vector3 offset = new Vector3(0, yOffset, spawnDistance);
        panel.transform.position = playerHead.TransformPoint(offset);
        // rotate the panel to face the player frame by frame
        panel.transform.LookAt(new Vector3(position.x, panel.transform.position.y, position.z));
        panel.transform.forward *= -1;
    }
}
