using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Базовый класс для всех сущностей
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Универсальный идентификатор сущностей
        /// </summary>
        protected Guid Id { get; set; }
        /// <summary>
        /// Дата создания сущностей
        /// </summary>
        protected DateTime CreatedData { get; set; }
        /// <summary>
        /// Имя, Фамилия, Дата рождения и пол персоны
        /// </summary>
        protected DateTime DateOfBirth { get; set; }
        public override bool Equals(object? obj)
        {
            // Проверка на null и сравнение типов
            if (obj is not BaseEntity entity)
                return false;

            // Сравнение идентификаторов
            return Id == entity.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
