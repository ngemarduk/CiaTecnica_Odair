using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CiaTecnica_MVC.Helper
{
    public class MinAge : ValidationAttribute
    {
        private int _Limit;
        public MinAge(int Limit)
        { // The constructor which we use in modal.
            this._Limit = Limit;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bday = DateTime.Parse(value.ToString());
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age))
            {
                age--;
            }
            if (age < _Limit)
            {
                var result = new ValidationResult("Desculpe você não tem idade mínima requerida");
                return result;
            }


            return null;

        }
    }
}


/*
 * Endereço https://stackoverflow.com/questions/38149190/datetime-required-18-years
 * Data: 05/02/2019
 */
