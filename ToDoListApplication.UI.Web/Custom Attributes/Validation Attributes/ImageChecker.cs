using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoListApplication.UI.Web.Custom_Attributes.Validation_Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ImageChecker : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var image = (HttpPostedFileBase)value;
                string[] acceptedImages = new string[] { "jpg", "jpeg", "png" };

                if (!acceptedImages.Any(x => image.ContentType.Contains(x)))
                {
                    ErrorMessage = "Unupported image format, please upload jpg, jpged or png";
                    return false;
                }

                if (image.ContentLength > 3 * 1024 * 1024)
                {
                    ErrorMessage = "Please upload a image smaller then 3MB";
                    return false;
                }
            }                          
            return true;
        }
        
    }
}