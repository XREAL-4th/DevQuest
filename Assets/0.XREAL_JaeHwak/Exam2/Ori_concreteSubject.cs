using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ori_concreteSubject : MonoBehaviour, ISubject
{
    public Ori_concreteObserver Ori_ConcreteObserver;

    public List<IObserver> observers = new List<IObserver>();
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        if (observers.IndexOf(observer) > 0) observers.Remove(observer);
    }
    public void Notify()
    {
        //observers[0].OnNotify();
        Ori_ConcreteObserver.OnNotify();

/*      질문 : 아래 방식으로 하면 호출이 되지 않습니다.. List 사용에서 문제가 있는 것일까요?
 *      // 추가로 ConcreteObserver는 런타임에서 생성하는 것일까요? 
        foreach (IObserver o in observers)
        {
            o.OnNotify();
        }*/
    }

    private void Awake()
    {
        Ori_ConcreteObserver = GameObject.FindObjectOfType<Ori_concreteObserver>();
    }

    void start()
    {
        AddObserver(Ori_ConcreteObserver);
    }

}
