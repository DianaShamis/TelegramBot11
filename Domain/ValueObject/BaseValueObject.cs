using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public abstract class BaseValueObject
    {
        /// <summary>
        /// ToDo. Найти и реализовать глубокое сравнение(DeepClone,DeepCompare)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        // Метод для глубокого клонирования объекта
        protected abstract BaseValueObject DeepClone();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // Глубокое клонирование объекта для сравнения
            BaseValueObject thisObj = DeepClone();
            BaseValueObject otherObj = ((BaseValueObject)obj).DeepClone();

            // Сравнение клонов объектов
            return ValueObjectExtensions.DeepEquals(thisObj, otherObj);
        }

        public override int GetHashCode()
        {
            // В качестве хэш-кода можно использовать хэш-код клонированного объекта
            BaseValueObject thisObj = DeepClone();
            return thisObj.GetHashCode();
        }
    }
}
