using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deltabyte.Info.Extent;

namespace RaidService
{
    public static class MailData
    {
        public static bool Send(Mail m, Tuple<string, string, string> t, Types.EventType e)
        {
            if (Constants.SendMail == false) return true;
            if (m.Receiver.Count == 0) return false;
            return m.Substitute(t, e);
        }

        public static bool Receiver(Mail m, List<Tuple<Types.ReceiverType, string>> rcv)
        {
            m.Receiver.Clear();
            foreach (var r in rcv)
            {
                if ((r.Item1 != Types.ReceiverType.Admin) && string.IsNullOrWhiteSpace(r.Item2)) continue;
                m.Receiver.Add(new Tuple<Types.ReceiverType, string>(r.Item1, r.Item2));
            }
            return m.Receiver.Count > 0;
        }

        public static Tuple<Types.ReceiverType, string> Set(Types.ReceiverType t, string a)
        {
            return new Tuple<Types.ReceiverType, string>(t, a);
        }

        public static void Set(Mail m, Types.ReceiverType t, string a)
        {
            m.Receiver.Add(new Tuple<Types.ReceiverType, string>(t, a));
        }

        public static Tuple<string, string, string> DiskLost(int i, string r, bool b)
        {
            return Text.DiskLost(i, r, b);
        }

        public static Tuple<string, string, string> DiskInserted(int i)
        {
            return Text.DiskInserted(i);
        }

        public static Tuple<string, string, string> Rebuilding()
        {
            return Text.Rebuilding();
        }

        public static Tuple<string, string, string> Rebuild(int i)
        {
            return Text.Rebuild(i);
        }
    }
}
