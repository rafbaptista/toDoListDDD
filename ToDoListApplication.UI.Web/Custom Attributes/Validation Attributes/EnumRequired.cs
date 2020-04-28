using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApplication.UI.Web.Custom_Attributes.Validation_Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EnumRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int inputValue = (int)value;            
            return inputValue > 0;            
        }
    }
}