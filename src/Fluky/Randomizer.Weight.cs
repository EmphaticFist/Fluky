﻿using System.Collections.Generic;
using System.Linq;

namespace Fluky
{
  public partial class Randomizer
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Choose<T>(IList<T> list) where T : IWeighted
    {
      if (!list.Any())
        return default(T);

      var totalWeight = list.Sum(x => x.Weight);
      var choice = Natural(0, totalWeight);
      var sum = 0;

      foreach (var obj in list)
      {
        for (var i = sum; i < obj.Weight + sum; i++)
        {
          if (i >= choice)
          {
            return obj;
          }
        }
        sum += obj.Weight;
      }

      return list.First();
    }
  }
}
