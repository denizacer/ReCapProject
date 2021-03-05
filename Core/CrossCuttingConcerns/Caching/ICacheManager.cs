using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{

    public interface ICacheManager
    {
        T Get<T>(string key);//getall, get farklı biri list diğeri değil onun için t tipinde tanımladık
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);//hangisini yok etcem getall mu get mi ona yarıyor
    }
}
