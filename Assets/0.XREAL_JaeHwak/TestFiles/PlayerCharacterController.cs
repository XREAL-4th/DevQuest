using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
	public float moveSpeed = 1.0f;

	private CharacterController _characterController;
	private Vector3 _currentMovement;

	void Start()
	{
		_characterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		float hAxis = Input.GetAxisRaw("Horizontal");
		float vAxis = Input.GetAxisRaw("Vertical");

		// �̵��� ���� : �̵��ϰ��� �ϴ� ���� * �̵� �ӵ� * Time.deltaTime
		_currentMovement = new Vector3(hAxis, 0, vAxis) * moveSpeed * Time.deltaTime;

		_characterController.Move(_currentMovement);
		transform.LookAt(transform.position + _currentMovement);
	}
}