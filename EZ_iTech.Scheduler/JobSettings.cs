using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EZ_iTech.Scheduler {
    /// <summary>
    /// 描述一组作业
    /// </summary>
    [ConfigurationCollection(typeof(JobSetting), AddItemName = "jobSetting")]
    internal sealed class JobSettings : ConfigurationElementCollection {
        protected override ConfigurationElement CreateNewElement() {
            return new JobSetting();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((JobSetting)element).Name;
        }
    }
}
