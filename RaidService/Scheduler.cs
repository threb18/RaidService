using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RaidService
{
    public partial class RaidService : ServiceBase
    {
        private bool Logout = Constants.Logging;

        public RaidService()
        {
            InitializeComponent();
        }

        private Raid raid = null;
        private System.Timers.Timer Periodic = null;

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            if (Logout) Deltabyte.Info.Logger.log(this, string.Format("timer fired...[{0}]", (raid != null) ? raid.IsLocked.ToString() : string.Empty));
            if ((raid != null) && (!raid.IsLocked)) raid.Refresh();
            if (Logout) Deltabyte.Info.Logger.log(this, "timer finished");
        }

        protected override void OnStart(string[] args)
        {
            Deltabyte.Info.Logger.log(this, string.Format("start {0} [{1}]", AppDomain.CurrentDomain.FriendlyName, System.Reflection.Assembly.GetEntryAssembly().GetName().Version));
            raid = new Raid();
            Deltabyte.Info.Logger.log(this, "raid opened");
            Periodic = new System.Timers.Timer();
            Periodic.Interval = 10000;
            Periodic.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            Periodic.Start();
            Deltabyte.Info.Logger.log(this, "timer started");
        }

        protected override void OnStop()
        {
            raid.Dispose();
            Periodic.Stop();
            Periodic.Dispose();
            Deltabyte.Info.Logger.log(this, "timer stopped");
            Deltabyte.Info.Logger.log(this, "service stop");
        }
    }
}
