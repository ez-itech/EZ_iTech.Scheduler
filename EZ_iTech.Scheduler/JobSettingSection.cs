using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace EZ_iTech.Scheduler {

    /// <summary>
    /// 作业的配置节点声明
    /// </summary>
    internal sealed class JobSettingSection : ConfigurationSection {
        [ConfigurationProperty("jobSettings", IsDefaultCollection = true)]
        public JobSettings JobSettings {
            get {
                return this["jobSettings"] as JobSettings;
            }
        }
    }
}
