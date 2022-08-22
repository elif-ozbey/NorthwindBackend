
using Castle.DynamicProxy;
using Core.CrossCutingConcern.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if(!typeof(IValidator).IsAssignableFrom(validatorType))

            //gonderilen validator type Ivalidator turunde degilse' yanlis bir validator kullaniyorsun seklinde hata verecegiz
            {
                throw new Exception(AspectMessages.WrongValidationType); ;
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Validator a ulastik ve new ledik
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //getgenericArguments product validatorin base i olan abstract validator~in argumanlarii veriyor. 1 tane arguman oldugu icin
            //0 inci argumala basliyoruz
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
                //bunlarda parametreler. git metoda oranin parametrelerine bak ve onlari filtrele. 
                //Metodun(product meneger) argumanlarini(parametrelerini) bul' orda product tipinde olani bul
                foreach(var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
