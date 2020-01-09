﻿using LangData.Objects;
using LangData.Objects.Base;
using System.Collections.Generic;

namespace LangServices
{
    public interface IService<T> where T : IHaveID
    {
        T Get(int id);
        IEnumerable<T> GetAll();

        T Add(T obj);
        void Add(IEnumerable<T> objs);

        void Remove(T obj);
        void Update(T obj);
    }
}