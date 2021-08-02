using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //class'ın Attribut'lerini oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            //method'un Attribut'lerini oku
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            //methodu da Listeye ekle
            classAttributes.AddRange(methodAttributes);

            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            //Otomatik olarak sistedeki bütün metodları loglar. Bundan sonra yazılacak metodlar da loglanmış olur

            //Attribüt'te Priorty değeri verilirse o sıraya göre attribütleri çalıştır
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
