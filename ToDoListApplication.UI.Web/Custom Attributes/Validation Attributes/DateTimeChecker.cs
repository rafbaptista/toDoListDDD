using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApplication.UI.Web.Custom_Attributes.Validation_Attributes
{
    public class DateTimeChecker : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            DateTime inputValue = (DateTime)value;
            return inputValue > DateTime.Now;
        }
    }
}