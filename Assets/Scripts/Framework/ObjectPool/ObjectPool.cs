using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.ObjectPool
{
    public class ObjectPool<T> where T:class, IDisposable, new()
    {
        private readonly string _poolName;
        public string PoolName => _poolName;

        private int _maxSize;
        public int MaxSize => _maxSize;

        public int CurrentSize => _pool.Count;

        private Queue<T> _pool;

        public ObjectPool(string poolName)
        {
            this._poolName = poolName;
        }

        public ObjectPool(string poolName, int warmSize=3, int maxSize=10)
        {
            _pool = new Queue<T>();
            this._poolName = poolName;

            WarnPool(warmSize);
        }

        private void WarnPool(int warmSize)
        {
            int size = 0;
            if (warmSize > 0 && warmSize <= _maxSize)
            {
                size = Mathf.Max(warmSize - _pool.Count, 0);
            }

            while (size > 0)
            {
                _pool.Enqueue(new T());
                size--;
            }
        }

        public T CreateGo()
        {
            T obj = default(T);
            if (_pool.Count > 0)
            {
                obj = _pool.Dequeue();
            }
            else
            {
                obj = new T();
            }
            return obj;
        }

        public void ReleaseGo(T obj)
        {
            obj.Dispose();
            _pool.Enqueue(obj);
        }

        public void DestoryPool()
        {
            while (_pool.Count > 0)
            {
                T go = _pool.Dequeue();
                go.Dispose();
            }
        }
    }
}