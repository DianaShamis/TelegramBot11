using Domain.Primitives;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

// ToDo: Добавить валидацию допускающаю только русские или английские буквы

// ToDo: Сделать валидацию для всех остальных. Для DateTime 150 лет максимум,
// Gender проверка не undefined, по Telegram есть ли  @ ник не больше 20 символов,
// номер телефона начинается с +37377 , 123 не допускается, 5 цифр после

// ToDo: * FluentValitaton
namespace Domain.Entities
{
    public class Person: BaseEntity
    {
        public Person(FullName fullName, DateTime birthday, Gender gender, string phoneNumber, string telegram)
        {
            FullName = ValidateFullName(fullName);
            Birthday = ValidateBirthday(birthday);
            Gender = ValidateGender(gender);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            Telegram = ValidateTelegram(telegram);
        }
        public FullName FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public int Age => DateTime.Now.Year - Birthday.Year;
        public Gender Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Telegram { get; private set; }

        /// Валидация ФИО (имени, фамилии и отчества)
        private FullName ValidateFullName(FullName fullName)
        {
            // Проверка на ввод имени, фамилии и отчества
            if (string.IsNullOrEmpty(fullName.FirstName))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(fullName.FirstName));
            }
            if (string.IsNullOrEmpty(fullName.LastName))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(fullName.LastName));
            }

            // Проверка на допустимые символы (только русские или английские буквы)
            if (!fullName.FirstName.All(char.IsLetter))
            {
                throw new ValidationException(ValidationMessages.RussianOrEnglish(fullName.FirstName));
            }
            if (!fullName.LastName.All(char.IsLetter))
            {
                throw new ValidationException(ValidationMessages.RussianOrEnglish(fullName.LastName));
            }
            if (!string.IsNullOrEmpty(fullName.MiddleName) && !fullName.MiddleName.All(char.IsLetter))
            {
                throw new ValidationException(ValidationMessages.RussianOrEnglish(fullName.MiddleName));
            }

            return fullName;
        }

        /// Валидация Даты Рождения
        private DateTime ValidateBirthday(DateTime birthday)
        {
            // Проверка на ввод
            if (birthday == DateTime.MinValue)
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(birthday.ToString()));
            }

            // Проверка не является ли дата больше сегодняшней и указанный возраст не больше 150  
            if (birthday > DateTime.Now || birthday < DateTime.Now.AddYears(-150))
            {
                throw new ValidationException(ValidationMessages.InvalidBirthday(birthday.ToString()));
            }

            return birthday;
        }

        /// Валидация Номера Телефона
        private string ValidatePhoneNumber(string phoneNumber)
        {
            // Проверка на ввод номера телефона
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(phoneNumber));
            }

            // Проверка на правильность указанного номера телефона
            string pattern = @"^\+37377(?!.*[123])\d{6}$";
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                throw new ValidationException(ValidationMessages.InvalidPhoneNumber(phoneNumber));
            }

            return phoneNumber;
        }

        /// Валидация Ника в Телеграм
        private string ValidateTelegram(string telegram)
        {
            // Проверка на ввод Телеграма
            if (string.IsNullOrEmpty(telegram))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(telegram));
            }

            // Проверка на правильность указанного Телеграма
            if (telegram.Length > 20 || !telegram.Contains("@"))
            {
                throw new ValidationException(ValidationMessages.InvalidTelegram(telegram));
            }

            return telegram;
        }

        /// Валидация Гендера
        private Gender ValidateGender(Gender gender)
        {
            // Проверка на ввод гендера
            if (gender == Gender.UnderFined)
            {
                throw new ValidationException(ValidationMessages.UndefinedGender(gender.ToString()));
            }

            return gender;
        }
    }
}
