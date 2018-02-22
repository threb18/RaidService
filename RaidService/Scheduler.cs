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
        private bool Logout = false;

        public RaidService()
        {
            InitializeComponent();
        }

        private Raid raid = null;
        private System.Timers.Timer Periodic = null;

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            if (Logout) Deltabyte.Info.Logger.log(this, "timer fired...");
            if (raid != null) raid.Refresh();
            if (Logout) Deltabyte.Info.Logger.log(this, "timer finished");
        }

        protected override void OnStart(string[] args)
        {
            Deltabyte.Info.Logger.log(this, "service start");
            raid = new Raid();
            Deltabyte.Info.Logger.log(this, "raid opened");
            Periodic = new System.Timers.Timer();
            Periodic.Interval = 5000;
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
