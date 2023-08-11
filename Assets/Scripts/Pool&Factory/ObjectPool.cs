using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T>
{
    Func<T> _factoryMethod;

    List<T> _actualStock;
    bool _isDynamic;

    Action<T> _turnOnCallBack;
    Action<T> _turnOffCallBack;

    public ObjectPool(Func<T> factoryMethod, int initialStock, bool isDynamic, Action<T> turnOn, Action<T> turnOff)
    {
        _factoryMethod = factoryMethod;

        _isDynamic = isDynamic;

        _turnOnCallBack = turnOn;
        _turnOffCallBack = turnOff;

        _actualStock = new List<T>();

        for (int i = 0; i < initialStock; i++)
        {
            T newObjetc = _factoryMethod();
            _turnOffCallBack(newObjetc);
            _actualStock.Add(newObjetc);
        }
    }

    public T GetT()
    {
        var result = default(T); 

        if(_actualStock.Count > 0)
        {
            result =_actualStock[0];
            _actualStock.RemoveAt(0);
        }
        else if (_isDynamic)
        {
            result = _factoryMethod();
        }

        _turnOnCallBack(result);
        return result;
    }

    public void ReturnObject(T obj)
    {
        _turnOffCallBack(obj);
        _actualStock.Add(obj);
    }

}
