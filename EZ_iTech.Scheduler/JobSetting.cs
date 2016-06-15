using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;

namespace EZ_iTech.Scheduler {
    /// <summary>
    /// 作业的描述
    /// </summary>
    public partial class JobSetting : ConfigurationElement {
        /// <summary>
        /// 作业的名称
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name {
            get {
                return (string)this["name"];
            }
        }

        /// <summary>
        /// 作业的描述信息
        /// </summary>
        [ConfigurationProperty("description", IsRequired = false)]
        public string Description {
            get {
                return (string)this["description"];
            }
        }

        /// <summary>
        /// 作业执行的时间区间
        /// </summary>
        [ConfigurationProperty("during", DefaultValue = new string[] { "00:00~23:59:59" })]
        [TypeConverter(typeof(JobDuringConvert))]
        public string[] During {
            get {
                return (string[])this["during"];
            }
        }

        /// <summary>
        /// 作业执行的间隔
        /// </summary>
        [ConfigurationProperty("interval")]
        public int Interval {
            get {
                return (int)this["interval"];
            }
        }

        /// <summary>
        /// 作业需要的资源
        /// </summary>
        [ConfigurationProperty("count", DefaultValue = 1)]
        public int Count {
            get {
                return Math.Min(Math.Max(1, (int)this["count"]), Max);
            }
        }
    }
}
