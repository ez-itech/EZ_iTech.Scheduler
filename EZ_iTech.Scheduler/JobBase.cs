using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EZ_iTech;

namespace EZ_iTech.Scheduler {
    /// <summary>
    /// 待执行的一个作业
    /// </summary>
    public abstract class JobBase {
        protected JobSetting JobSetting { get; private set; }
        protected Dictionary<int, Func<string>> Funcs { get; private set; }
        protected Thread[] Threads { get; private set; }
        protected bool IsDispose { get; private set; }

        /// <summary>
        /// 作业的执行间隔
        /// </summary>
        public int Interval {
            get {
                return JobSetting.Interval * 1000;
            }
        }

        /// <summary>
        /// 使用指定的任务配置信息构造 Task 实例
        /// </summary>
        /// <param name="jobSetting"></param>
        public JobBase(JobSetting jobSetting, Dictionary<int, Func<string>> funcs) {
            JobSetting = jobSetting;
            Funcs = funcs;

            int count = jobSetting.Count;
            Threads = new Thread[count];
        }

        /// <summary>
        /// 开始执行作业
        /// </summary>
        public virtual void Start() {
            for (int i = 0; i < Threads.Length; i++) {
                var query = from entity in Funcs
                            where entity.Key % Threads.Length == i
                            select entity.Value;

                List<Func<string>> funcs = query.ToList();

                Threads[i] = new Thread(new ThreadStart(() => {
                    while (!IsDispose) {
                        if (JobSetting.CheckStatus()) {
                            foreach (var func in funcs) {
                                try {
                                    func();
                                }
                                catch (Exception ex) {
                                    LogHelper.Instance.Debug(ex, null);
                                }
                            }
                        }

                        Thread.Sleep(Interval);
                    }
                }));

                Threads[i].Name = i.ToString();
                Threads[i].Start();
            }
        }

        /// <summary>
        /// 停止执行作业
        /// </summary>
        public void Stop() {
            IsDispose = true;
        }
    }
}
