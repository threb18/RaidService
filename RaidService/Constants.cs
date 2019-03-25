using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidService
{
    public static class Constants
    {
        public static readonly string ConnectionPath = "server=localhost;userid=root;password=Gib8aufNr.5712;database=deltabyte";
        public static readonly string MailBodyTemplateFile = @"C:\Program Files\Acquifer\RaidService\Acquifer_Mail_Template.html";
        public static readonly string VolumeStatusUnknown = "other";
        public static readonly string VolumeStatusNormal = "optimal";
        public static readonly string VolumeStatusDegraded = "degraded";
        public static readonly string VolumeStatusRebuilding = "rebuilding";
        public static readonly string VolumeStatusFailed = "failed";
        public static readonly string DiskStatusNormal = "present";
        public static readonly string DiskStatusRebuilding = "rebuilding";
        public static readonly string DiskStatusMissing = "missing";
        public static readonly string DiskStatusFailed = "failed";
        public static readonly int VolumeTypePassthrough = 20;
        public static readonly int VolumeTypeRaid5 = 8;
        public static readonly int VolumeTypeRaid6 = 9;
        public static readonly bool Logging = false;
        public static readonly bool SendMail = true;
    }
}
