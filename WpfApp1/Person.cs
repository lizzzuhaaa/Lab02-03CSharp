using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Lab01Sydorova
{
    internal class Person
    {
        private string _firstname;
        private string _lastname;
        private string _email;
        private DateTime _birthdate;
        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime Birthday
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }


        public Person (string firstName, string lastName, string email, DateTime birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;   
            this.Email = email;
            this.Birthday = birthday;
            if (!ValidateEmail(email))
            {
                throw new ValidationEmail("", email);
            }
            if (!ValidateBirthDatePast(birthday))
            {
                throw new ValidationPastBirth("", birthday);
            }
            if(!ValidateBirthDateFuture(birthday))
            {
                throw new ValidationFutureBirth("", birthday);
            }
        }

        public Person(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            ValidateEmail(email);
        }

        public Person(string firstName, string lastName, DateTime birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday= birthday;
            ValidateBirthDatePast(birthday);
            ValidateBirthDateFuture(birthday);
        }

        public bool IsAdult
        {
            get
            {
                DateTime currentDate = DateTime.Now;
                int ageThisYear = currentDate.Year - this.Birthday.Year;
                if (this.Birthday > currentDate.AddYears(-ageThisYear))
                    ageThisYear--;
                return ageThisYear>=18;
            }
        }

        public string SunSign
        {
            get
            {
                switch (this.Birthday.Month)
                {
                    case 1:
                        {
                            if (this.Birthday.Day < 21) return "Capricorn";
                            else return "Aquarius";
                        }
                    case 2:
                        {
                            if (this.Birthday.Day < 20) return "Aquarius";
                            else return "Pisces";
                        }
                    case 3:
                        {
                            if (this.Birthday.Day < 21) return "Pisces";
                            else return "Aries";
                        }
                    case 4:
                        {
                            if (this.Birthday.Day < 21) return "Aries";
                            else return "Taurus";
                        }
                    case 5:
                        {
                            if (this.Birthday.Day < 22) return "Taurus";
                            else return "Gemini";
                        }
                    case 6:
                        {
                            if (this.Birthday.Day < 22) return "Gemini";
                            else return "Cancer";
                        }
                    case 7:
                        {
                            if (this.Birthday.Day < 23) return "Cancer";
                            else return "Leo";
                        }
                    case 8:
                        {
                            if (this.Birthday.Day < 22) return "Leo";
                            else return "Virgo";
                        }
                    case 9:
                        {
                            if (this.Birthday.Day < 24) return "Virgo";
                            else return "Libra";
                        }
                    case 10:
                        {
                            if (this.Birthday.Day < 24) return "Libra";
                            else return "Scorpio";
                        }
                    case 11:
                        {
                            if (this.Birthday.Day < 24) return "Scorpio";
                            else return "Saggitarius";
                        }
                    case 12:
                        {
                            if (this.Birthday.Day < 23) return "Saggitarius";
                            else return "Capricorn";
                        }
                    default: return "";
                }
            }
        }
        
        public string ChineseSign
        {
            get
            {
                switch ((this.Birthday.Year - 4) % 12)
                {
                    case 0:
                        {
                            return "Rat";
                        }
                    case 1:
                        {
                            return "Ox";
                        }
                    case 2:
                        {
                            return "Tiger";
                        }
                    case 3:
                        {
                            return "Rabbit";
                        }
                    case 4:
                        {
                            return "Dragon";
                        }
                    case 5:
                        {
                            return "Snake";
                        }
                    case 6:
                        {
                            return "Horse";
                        }
                    case 7:
                        {
                            return "Goat";
                        }
                    case 8:
                        {
                            return "Monkey";
                        }
                    case 9:
                        {
                            return "Rooster";
                        }
                    case 10:
                        {
                            return "Dog";
                        }
                    case 11:
                        {
                            return "Pig";
                        }
                    default: return "";
                }
            }
        }

        public bool IsBirthday
        {
            get
            {
                if ((this.Birthday.Month == DateTime.Now.Month) && (this.Birthday.Day == DateTime.Now.Day)) { return true; }
                return false;
            }
        }

        private bool ValidateEmail(string email) 
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        private bool ValidateBirthDatePast(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int ageThisYear = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-ageThisYear))
                ageThisYear--;
            if (ageThisYear > 135)
            { return false; }
            return true;
        }
        private bool ValidateBirthDateFuture(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int ageThisYear = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-ageThisYear))
                ageThisYear--;
            if (ageThisYear < 0)
            { return false; }
            return true;
        }
    }
}
