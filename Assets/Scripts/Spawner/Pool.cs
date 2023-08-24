using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T _template;
    private Transform _container;
    private List<T> _pool = new List<T>();

    public Pool(T template, Transform container)
    {
        _template = template;
        _container = container;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
        {
            return element;
        }

        return CreateObject();
    }

    private bool HasFreeElement(out T element)
    {
        element = null;

        foreach(T item in _pool)
        {
            if (item.gameObject.activeInHierarchy == false)
            {
                element = item;
                return true;
            }
        }

        return false;
    }

    private T CreateObject()
    {
        T obj = Object.Instantiate(_template, _container);
        obj.gameObject.SetActive(false);
        _pool.Add(obj);
        return obj;
    }
}
