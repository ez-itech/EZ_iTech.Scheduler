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
        /// 作业可以运行的时间区间
        /// </summary>
        internal List<Range> Ranges { get; set; }

        /// <summary>
        /// 设置最大的资源占用
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// 构造作业的实例，并设置当前作业可占用的最大资源
        /// </summary>
        /// <param name="max"></param>
        public JobSetting(int max = Int32.MaxValue) {
            Max = max;

            if (null != During) {
                Ranges = new List<Range>();
                foreach (var item in During) {
                    string[] timeStr;
                    timeStr = item.Split('~');

                    Ranges.Add(new Range(timeStr[0], timeStr[1]));
                }
            }
        }

        /// <summary>
        /// 检查当前时间点是否满足运行条件
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckStatus() {
            DateTime time = DateTime.Now;

            var query = from entity in Ranges
                        where entity.IsWithin(time)
                        select entity;

            if (query.Count() > 0)
                return true;

            return false;
        }
    }
}
