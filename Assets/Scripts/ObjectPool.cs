using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
	private T _objPrefab; // ������ ��'����, ���� ������ ��������
	private int _initSize = 10; // ��������� ������� ��'����

	private Queue<T> _pool = new Queue<T>(); // ����� ��'���� �� �����

	public ObjectPool(T objPrefab)
	{
		_objPrefab = objPrefab;
		for (int i = 0; i < _initSize; i++)
		{
			T obj = GameObject.Instantiate(_objPrefab);
			// obj.name = "Zombie" + obj.GetHashCode();
			obj.gameObject.SetActive(false);
			_pool.Enqueue(obj);
		}
	}

	public T GetObject()
	{
		if (_pool.Count > 0)
		{
			T obj = _pool.Dequeue();
			return obj;
		}
		else
		{
			T obj = GameObject.Instantiate(_objPrefab);
			_objPrefab.gameObject.SetActive(false);
			return obj;
		}
	}

	public void ReturnObject(T obj)
	{
		obj.gameObject.SetActive(false);
		_pool.Enqueue(obj);
	}
}