using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZ_iTech.Scheduler {
    /// <summary>
    /// 作业执行的时间区间
    /// </summary>
    internal sealed class Range {
        private string _startDateTimeStr;
        private string _stopDateTimeStr;

        /// <summary>
        /// 使用指定的开始时间和结束时间，构造 TimeSpan 实例
        /// </summary>
        /// <param name="startDateTimeStr">开始时间</param>
        /// <param name="stopDateTimeStr">结束时间</param>
        public Range(string startDateTimeStr, string stopDateTimeStr) {
            _startDateTimeStr = startDateTimeStr;
            _stopDateTimeStr = stopDateTimeStr;
        }

        /// <summary>
        /// 判断给定的时间是否在作业的可执行区间内
        /// </summary>
        /// <param name="dateTime">待判断时间</param>
        /// <returns></returns>
        public bool IsWithin(DateTime dateTime) {
            DateTime startDateTime = DateTime.Parse(_startDateTimeStr);
            DateTime stopDateTime = DateTime.Parse(_stopDateTimeStr);

            if (dateTime >= startDateTime && dateTime < stopDateTime) {
                return true;
            }

            return false;
        }
    }
}
