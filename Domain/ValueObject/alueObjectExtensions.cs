using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public static class ValueObjectExtensions
    {
        // Реализация глубокого сравнения объектов по данным.
        public static bool DeepEquals(this BaseValueObject obj, BaseValueObject another)
        {
            // Проверка на ссылочное равенство и на null
            if (ReferenceEquals(obj, another)) return true;
            if ((obj == null) || (another == null)) return false;
            if (obj.GetType() != another.GetType()) return false;

            // Если свойство не является классом, применяем обычное сравнение.
            if (!obj.GetType().IsClass) return obj.Equals(another);

            // Рекурсивное сравнение всех свойств объектов
            var result = true;
            foreach (var property in obj.GetType().GetProperties())
            {
                var objValue = property.GetValue(obj);
                var anotherValue = property.GetValue(another);

                // Продолжаем рекурсию
                if (!DeepEquals((BaseValueObject)objValue, (BaseValueObject)anotherValue)) result = false;
            }
            return result;
        }
    }
}
