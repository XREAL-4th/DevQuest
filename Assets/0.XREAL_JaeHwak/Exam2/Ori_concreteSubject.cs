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

/*      ���� : �Ʒ� ������� �ϸ� ȣ���� ���� �ʽ��ϴ�.. List ��뿡�� ������ �ִ� ���ϱ��?
 *      // �߰��� ConcreteObserver�� ��Ÿ�ӿ��� �����ϴ� ���ϱ��? 
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
