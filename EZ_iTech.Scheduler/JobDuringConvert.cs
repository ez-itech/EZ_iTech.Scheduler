using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EZ_iTech.Scheduler {

    /// <summary>
    /// 作业运行区间的解析
    /// </summary>
    internal sealed class JobDuringConvert : ConfigurationConverterBase {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            if (value is string) {
                return ((string)value).Split(new char[] { ',' });
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            if (destinationType == typeof(string)) {
                return string.Join(",", (string[])value);
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
