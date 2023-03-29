using System;
using UnityEngine;

public abstract class FSMMonoBehaviour<T> : MonoBehaviour where T : struct, Enum
{
	[Header("Debug")]
	public T state;
	public T nextState;

	protected abstract T NoneState { get; }
    protected abstract T IdleState { get; }

    protected virtual void Awake()
    {
        state = NoneState;
        nextState = NoneState;

    }

    protected virtual void Start()
    {
        state = NoneState;
		nextState = IdleState;

    }

	protected virtual void Update()
	{
		if (nextState.Equals(NoneState)) CheckState();
		if (!nextState.Equals(NoneState))
		{

			state = nextState;
			nextState = NoneState;
			InitState();
		}
		UpdateState();
	}


	protected abstract void CheckState();
	protected abstract void InitState();
	protected abstract void UpdateState();
}