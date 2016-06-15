using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace EZ_iTech.Scheduler {
    /// <summary>
    /// 从配置文件中获取任务的配置
    /// </summary>
    public partial class JobSetting {

        /// <summary>
        /// 从配置文件中获取所有的作业配置
        /// </summary>
        private static JobSettings _jobSettings;

        /// <summary>
        /// 作业配置集合
        /// </summary>
        public static List<JobSetting> Settings { get; private set; }

        static JobSetting() {
            try {
                Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                JobSettingSection jobSec = (JobSettingSection)cfg.GetSection("jobSettingSection");
                _jobSettings = jobSec.JobSettings;

                if (null == Settings) {
                    Settings = new List<JobSetting>();
                    foreach (JobSetting item in _jobSettings) {
                        Settings.Add(item);
                    }
                }
            }
            catch (Exception ex) {
                LogHelper.Instance.Error("[EZ_iTech.Scheduler] -> 配置文件错误！", ex);
            }
        }
    }
}
