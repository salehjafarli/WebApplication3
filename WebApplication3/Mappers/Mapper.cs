using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication3.Mappers
{
    /// <summary>
    ///  Entity Model mapper
    /// </summary>
    /// <typeparam name="T1">Entity </typeparam>
    /// <typeparam name="T2"> Model</typeparam>
    public static class Mapper<T1,T2> 
    {
        public static T2 Map(T1 obj)
        {
            var x = obj.GetType().GetProperties();
            var res = (T2)Activator.CreateInstance(typeof(T2));
            var y = typeof(T2).GetProperties();
            foreach (var item in x)
            {
                var prop = y.FirstOrDefault(z => z.Name == item.Name);
                
                if (prop!=null)
                {
                    if (!(prop.PropertyType != typeof(DateTime) && prop.PropertyType != typeof(string) && prop.PropertyType.IsClass == true))
                    {
                        prop.SetValue(res, item.GetValue(obj));
                    }
                    
                }
                
            }

            return res;

        }
        public static T1 Map(T2 obj)
        {
            var x = obj.GetType().GetProperties();

            var res = (T1)Activator.CreateInstance(typeof(T1));
            var y = typeof(T1).GetProperties();
            foreach (var item in x)
            {
                var prop = y.FirstOrDefault(z => z.Name == item.Name);
                if (prop != null)
                {
                    if (!(prop.PropertyType != typeof(DateTime) && prop.PropertyType != typeof(string) && prop.PropertyType.IsClass == true))
                    {
                        prop.SetValue(res, item.GetValue(obj));
                    }

                }
            }

            return res;
        }


    }
}
