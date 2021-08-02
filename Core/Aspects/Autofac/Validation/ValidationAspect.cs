using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    /// <summary>
    /// MethodInterception'ı implents ettiği için attribüt özellliği kazanmış oldu
    /// </summary>
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        /// <summary>
        /// validatorType validator tipi ver
        /// Göderilem tip IValidator türünde değilse hata ver
        /// Tip Kısıtlı Çalışma
        /// </summary>
        /// <param name="validatorType"></param>
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        /// <summary>
        /// OnBefore Method'un Başında Çalışsın istediğim için onu override ettik.
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection yapıyor
            //ÇAlışma anında new'lenmesini sağlıyor. _validatorType'ı new'le
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //ProductValidator'ın genericArguman'larından ilkini bul entityTpe'a ata
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //method'un Argumanlarını gez entityType'a eşit olanları entities'e ata
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //bulduğun entities'leri gez ValidationTool.Validate'e göre validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }

        
    }
}
