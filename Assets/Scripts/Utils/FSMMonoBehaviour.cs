using System;
using UnityEngine;

public abstract class FSMMonoBehaviour<T> : MonoBehaviour where T : struct, Enum
{
	[Header("Debug")]
	public T state = (T)(typeof(T).GetEnumValues().GetValue(0));
	public T nextState = (T)(typeof(T).GetEnumValues().GetValue(0));

	private T noneState = (T)(typeof(T).GetEnumValues().GetValue(0));

	protected virtual void Update()
	{
		if (nextState.Equals(noneState)) CheckState();
		if (!nextState.Equals(noneState))
		{

			state = nextState;
			nextState = noneState;
			InitState();
		}
		UpdateState();
	}


	protected abstract void CheckState();
	protected abstract void InitState();
	protected abstract void UpdateState();
}