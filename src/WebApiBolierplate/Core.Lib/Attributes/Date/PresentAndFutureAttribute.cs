﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Lib.Attributes.Date
{
    /// <summary>
    /// Sets validation to ensure that date value is in future or today
    /// </summary>
    public class PresentAndFutureAttribute : ValidationAttribute
    {
        public PresentAndFutureAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var val = Convert.ToDateTime(value);
            var dateValue = new DateTime(val.Year, val.Month, val.Day, 0, 0, 0);
            var now = DateTime.UtcNow;
            return dateValue >= new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
        }
    }
}
