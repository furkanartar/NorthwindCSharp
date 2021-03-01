using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//gelen validatorType'ı kontrol ediyor.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)//doğrulama yapan metot.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//_validatorType'ın reflection ile instance'ını oluşturuyor.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//_validatorType'ın base type'ını buluyoır onunda ilk çalışma tipini buluyor.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //metot'un paremetlerine bakıyor entityType'a denk gelen parametreleri buluyor.
            foreach (var entity in entities)//her paremetreyi tek tek doğruluyor.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}