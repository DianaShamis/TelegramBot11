using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Дополнительное поле
    /// </summary>
    public class CustomField<TValue> : BaseEntity
    {
        public CustomField()
        { 
            /// to do: валидация на null и пустоту
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public TValue Value { get; set; }   

    }
}
