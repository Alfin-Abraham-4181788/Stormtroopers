using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Defines an enum for the different types of celestial bodies
    /// </summary>
    public enum ProductTypeEnum
    {
        // Adding categories for ProductType list displayed on update page for admin to choose from
        [Display(Name = "Undefined")] Undefined = 0,
        [Display(Name = "Star")] Star = 1,
        [Display(Name = "Planet")] Planet = 2,
        [Display(Name = "Planetary Satellite")] Moon = 3,
    
    }
}

public static class Extensions
{
    /// <summary>
    /// An extension to ProductTypeEnum to get the display name for razor pages
    /// </summary>
    public static string GetName(this Enum productEnum)
    {
        return productEnum.GetType().GetMember(productEnum.ToString()).First()
                        .GetCustomAttribute<DisplayAttribute>().Name;
    }
}
