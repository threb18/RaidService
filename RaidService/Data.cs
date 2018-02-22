using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Deltabyte.Info;

namespace RaidService
{
    public class Location : IComparable<Location>
    {
        #region Properties
        public bool IsSet { get; set; }
        public bool IsEnclosure { get; set; }
        public int Enclosure { get; set; }
        public int Slot { get; set; }
        public int Connector { get; set; }
        public int Device { get; set; }
        #endregion

        #region Constructor
        public Location()
        {
            IsSet = false;
            IsEnclosure = false;
            Enclosure = -1;
            Slot = -1;
            Connector = -1;
            Device = -1;
        }

        public Location(Location l)
        {
            IsSet = l.IsSet;
            IsEnclosure = l.IsEnclosure;
            Enclosure = l.Enclosure;
            Slot = l.Slot;
            Connector = l.Connector;
            Device = l.Device;
        }

        public Location(bool e, int a, int b)
        {
            IsSet = true;
            IsEnclosure = e;
            if (e)
            {
                Enclosure = a;
                Slot = b;
                Connector = -1;
                Device = -1;
            }
            else
            {
                Connector = a;
                Device = b;
                Enclosure = -1;
                Slot = -1;
            }
        }
        #endregion

        #region Methods
        public bool Equal(Location l)
        {
            if (IsSet != l.IsSet) return false;
            if (IsEnclosure != l.IsEnclosure) return false;
            if (Enclosure != l.Enclosure) return false;
            if (Slot != l.Slot) return false;
            if (Connector != l.Connector) return false;
            if (Device != l.Device) return false;
            return true;
        }

        public bool NotEqual(Location l)
        {
            if (IsSet != l.IsSet) return true;
            if (IsEnclosure != l.IsEnclosure) return true;
            if (Enclosure != l.Enclosure) return true;
            if (Slot != l.Slot) return true;
            if (Connector != l.Connector) return true;
            if (Device != l.Device) return true;
            return false;
        }

        public int CompareTo(Location l)
        {
            if (l == null) return 1;
            if ((l.Enclosure != -1) && (Connector != -1)) return -1;
            else if ((Enclosure != -1) && (l.Connector != -1)) return 1;
            else if ((l.Enclosure != -1) && (Enclosure != -1))
            {
                int res = Enclosure.CompareTo(l.Enclosure);
                return (res != 0) ? res : Slot.CompareTo(l.Slot);
            }
            else if ((l.Connector != -1) && (Connector != -1))
            {
                int res = Connector.CompareTo(l.Connector);
                return (res != 0) ? res : Device.CompareTo(l.Device);
            }
            return 0;
        }

        public override string ToString()
        {
            return string.Format("[{0} {1} {2} {3} {4} {5}]", IsSet, IsEnclosure, Enclosure, Slot, Connector, Device);
        }
        public string Info()
        {
            return string.Format("[{0} {1} {2} {3} {4} {5}]", IsSet, IsEnclosure, Enclosure, Slot, Connector, Device);
        }
        #endregion
    }

    public class DiskData : IDisposable, IComparable<DiskData>
    {
        #region Properties
        public int Id { get; set; }
        public int Index { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string Revision { get; set; }
        public string Status { get; set; }
        public string Temperature { get; set; }
        public int Temp { get; set; }
        public int Size { get; set; }
        public string Measure { get; set; }
        public string Ssd { get; set; }
        public string Location { get; set; }
        public Location Loc { get; set; }
        #endregion

        #region Constructor
        public DiskData()
        {
            Id = -1;
            Index = -1;
            Size = 0;
            Temp = -1;
            Vendor = string.Empty;
            Model = string.Empty;
            Serial = string.Empty;
            Revision = string.Empty;
            Status = string.Empty;
            Temperature = string.Empty;
            Measure = string.Empty;
            Ssd = string.Empty;
            Location = string.Empty;
            Loc = new Location();
        }

        public DiskData(DiskData d)
        {
            Id = d.Id;
            Index = d.Index;
            Size = d.Size;
            Temp = d.Temp;
            Vendor = d.Vendor;
            Model = d.Model;
            Serial = d.Serial;
            Revision = d.Revision;
            Status = d.Status;
            Temperature = d.Temperature;
            Measure = d.Measure;
            Ssd = d.Ssd;
            Location = d.Location;
            Loc = new Location(d.Loc);
        }

        public void Dispose()
        {
            Vendor = null;
            Model = null;
            Serial = null;
            Revision = null;
            Status = null;
            Temperature = null;
            Measure = null;
            Ssd = null;
            Location = null;
        }
        #endregion

        #region Methods
        public bool Equal(DiskData d)
        {
            if (Id != d.Id) return false;
            if (Index != d.Index) return false;
            if (Size != d.Size) return false;
            if (Temp != d.Temp) return false;
            if (Vendor != d.Vendor) return false;
            if (Model != d.Model) return false;
            if (Serial != d.Serial) return false;
            if (Revision != d.Revision) return false;
            if (Status != d.Status) return false;
            if (Temperature != d.Temperature) return false;
            if (Measure != d.Measure) return false;
            if (Ssd != d.Ssd) return false;
            if (Location != d.Location) return false;
            if (Loc.NotEqual(Loc)) return false;
            return true;
        }

        public bool NotEqual(DiskData d)
        {
            if (Id != d.Id) return true;
            if (Index != d.Index) return true;
            if (Size != d.Size) return true;
            if (Temp != d.Temp) return true;
            if (Vendor != d.Vendor) return true;
            if (Model != d.Model) return true;
            if (Serial != d.Serial) return true;
            if (Revision != d.Revision) return true;
            if (Status != d.Status) return true;
            if (Temperature != d.Temperature) return true;
            if (Measure != d.Measure) return true;
            if (Ssd != d.Ssd) return true;
            if (Location != d.Location) return true;
            if (Loc.NotEqual(Loc)) return true;
            return false;
        }

        public List<string> Info()
        {
            List<string> sl = new List<string>();
            sl.Add(string.Format("{0,-24} : {1}", "Id", Id));
            sl.Add(string.Format("{0,-24} : {1}", "Index", Index));
            sl.Add(string.Format("{0,-24} : {1}", "Size", Size));
            sl.Add(string.Format("{0,-24} : {1}", "Temp", Temp));
            sl.Add(string.Format("{0,-24} : {1}", "Vendor", Vendor));
            sl.Add(string.Format("{0,-24} : {1}", "Model", Model));
            sl.Add(string.Format("{0,-24} : {1}", "Serial", Serial));
            sl.Add(string.Format("{0,-24} : {1}", "Revision", Revision));
            sl.Add(string.Format("{0,-24} : {1}", "Status", Status));
            sl.Add(string.Format("{0,-24} : {1}", "Temperature", Temperature));
            sl.Add(string.Format("{0,-24} : {1}", "Measure", Measure));
            sl.Add(string.Format("{0,-24} : {1}", "SSD", Ssd));
            sl.Add(string.Format("{0,-24} : {1} {2}", "Location", Location, Loc.Info()));
            return sl;
        }

        public int CompareTo(DiskData d)
        {
            return Loc.CompareTo(d.Loc);
        }
        #endregion

        #region Caller
        public static int GetTemp(int i)
        {
            using (Deltabyte.Raid.Disk dsk = new Deltabyte.Raid.Disk())
            {
                return dsk.Data[i].Temperature.Val;
            }
        }

        public static string GetState(int i)
        {
            using (Deltabyte.Raid.Disk dsk = new Deltabyte.Raid.Disk())
            {
                return dsk.Data[i].State;
            }
        }

        public static Tuple<int, string> Refresh(int i)
        {
            using (Deltabyte.Raid.Disk dsk = new Deltabyte.Raid.Disk())
            {
                return new Tuple<int, string>(dsk.Data[i].Temperature.Val, dsk.Data[i].State);
            }
        }
        #endregion
    }
    public class VolumeData : IDisposable
    {
        #region Properties
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Level { get; set; }
        public int Size { get; set; }
        public string Task { get; set; }
        public int Completion { get; set; }
        public List<DiskData> Disks { get; set; }
        #endregion

        #region Constructor
        public VolumeData()
        {
            Id = -1;
            Index = -1;
            Level = -1;
            Size = -1;
            Completion = -1;
            Name = string.Empty;
            Type = string.Empty;
            Status = "Unset";
            Task = string.Empty;
            Disks = new List<DiskData>();
        }

        public VolumeData(VolumeData v)
        {
            Id = v.Id;
            Index = v.Index;
            Level = v.Level;
            Size = v.Size;
            Completion = v.Completion;
            Name = v.Name;
            Type = v.Type;
            Status = v.Status;
            Task = v.Type;
            Disks = new List<DiskData>();
            Disks.AddRange(v.Disks);
        }

        public void Dispose()
        {
            Name = null;
            Type = null;
            Status = null;
            Task = null;
            foreach (DiskData d in Disks)
            {
                d.Dispose();
            }
        }
        #endregion

        #region Methods
        public void Clear()
        {
            Id = -1;
            Index = -1;
            Level = -1;
            Size = 0;
            Completion = -1;
            Name = string.Empty;
            Type = string.Empty;
            Status = "Unset";
            Task = string.Empty;
            if (Disks != null) Disks.Clear();
        }
        public bool Equal(VolumeData v)
        {
            if (Id != v.Id) return false;
            if (Index != v.Index) return false;
            if (Level != v.Level) return false;
            if (Size != v.Size) return false;
            if (Completion != v.Completion) return false;
            if (Name != v.Name) return false;
            if (Type != v.Type) return false;
            if (Status != v.Status) return false;
            if (Task != v.Task) return false;
            for (int i = 0; i < Disks.Count; i++)
            {
                if (Disks[i].NotEqual(v.Disks[i])) return false;
            }
            return true;
        }

        public bool Equal(VolumeData v, bool b)
        {
            if (Id != v.Id) return false;
            if (Index != v.Index) return false;
            if (Level != v.Level) return false;
            if (Size != v.Size) return false;
            if (Completion != v.Completion) return false;
            if (Name != v.Name) return false;
            if (Type != v.Type) return false;
            if (Status != v.Status) return false;
            if (Task != v.Task) return false;
            if (b)
            {
                for (int i = 0; i < Disks.Count; i++)
                {
                    if (Disks[i].NotEqual(v.Disks[i])) return false;
                }
            }
            return true;
        }
        public bool NotEqual(VolumeData v)
        {
            if (Id != v.Id) return true;
            if (Index != v.Index) return true;
            if (Level != v.Level) return true;
            if (Size != v.Size) return true;
            if (Completion != v.Completion) return true;
            if (Name != v.Name) return true;
            if (Type != v.Type) return true;
            if (Status != v.Status) return true;
            if (Task != v.Task) return true;
            for (int i = 0; i < Disks.Count; i++)
            {
                if (Disks[i].NotEqual(v.Disks[i])) return true;
            }
            return false;
        }

        public bool NotEqual(VolumeData v, bool b)
        {
            if (Id != v.Id) return true;
            if (Index != v.Index) return true;
            if (Level != v.Level) return true;
            if (Size != v.Size) return true;
            if (Completion != v.Completion) return true;
            if (Name != v.Name) return true;
            if (Type != v.Type) return true;
            if (Status != v.Status) return true;
            if (Task != v.Task) return true;
            if (b)
            {
                for (int i = 0; i < Disks.Count; i++)
                {
                    if (Disks[i].NotEqual(v.Disks[i])) return true;
                }
            }
            return false;
        }

        public List<string> Info()
        {
            List<string> sl = new List<string>();
            sl.Add(string.Format("{0,-24} : {1}", "Id", Id));
            sl.Add(string.Format("{0,-24} : {1}", "Index", Index));
            sl.Add(string.Format("{0,-24} : {1}", "Level", Level));
            sl.Add(string.Format("{0,-24} : {1}", "Size", Size));
            sl.Add(string.Format("{0,-24} : {1}", "Completion", Completion));
            sl.Add(string.Format("{0,-24} : {1}", "Name", Name));
            sl.Add(string.Format("{0,-24} : {1}", "Type", Type));
            sl.Add(string.Format("{0,-24} : {1}", "Status", Status));
            sl.Add(string.Format("{0,-24} : {1}", "Task", Task));
            foreach (var d in Disks)
            {
                sl.AddRange(d.Info());
            }
            return sl;
        }
        #endregion
    }

    public class ControllerData : IDisposable
    {
        #region Properties
        public int Id { get; set; } = -1;
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Temperature { get; set; }
        public int Temp { get; set; }
        public List<VolumeData> Volumes { get; set; }
        private readonly bool logging = true;
        #endregion

        #region Constructor
        public ControllerData()
        {
        }

        public ControllerData(bool b)
        {
            if (logging) Logger.log(this, "start");
            if (b)
            {
                Load();
            }
            else
            {
                Init(true);
            }
            if (logging) Logger.log(this, "end");
        }

        public void Dispose()
        {
            Vendor = null;
            Model = null;
            Serial = null;
            Name = null;
            Status = null;
            Temperature = null;
            if (Volumes != null)
            {
                foreach (VolumeData v in Volumes)
                {
                    v.Dispose();
                }
            }
        }
        #endregion

        #region Methods
        private void Init(bool b)
        {
            Id = -1;
            Temp = -1;
            Vendor = string.Empty;
            Model = string.Empty;
            Serial = string.Empty;
            Name = string.Empty;
            Status = "Unset";
            Temperature = string.Empty;
            if (b) Volumes = new List<VolumeData>();
        }

        public void Clear()
        {
            if (Volumes != null)
            {
                foreach (var v in Volumes)
                {
                    v.Clear();
                }
                Volumes.Clear();
                Init(false);
            }
            else
            {
                Init(true);
            }
        }

        private void Load()
        {
            if (logging) Logger.log(this, "start");
            int vid = 1;
            int did = 1;
            if (Volumes == null) Volumes = new List<VolumeData>();
            if (logging) Logger.log(this, "controller...");
            using (Deltabyte.Raid.Controller c = new Deltabyte.Raid.Controller())
            {
                Id = 1;
                Status = c.Data.State;
                Vendor = c.Data.Vendor.Item2;
                Model = c.Data.Model.Item2;
                Serial = c.Data.Serial.Item2;
                Name = c.Data.WWName.Item2;
                Temp = c.Data.Temperature.Item2;
                Temperature = Temp.ToString();
            }
            if (logging) Logger.log(this, "...done");
            if (logging) Logger.log(this, "volumes...");
            using (Deltabyte.Raid.Volume v = new Deltabyte.Raid.Volume())
            {
                if (v.Data != null)
                {
                    foreach (var r in v.Data)
                    {
                        VolumeData vol = new VolumeData();
                        vol.Id = vid++;
                        vol.Index = r.Index.Val;
                        vol.Level = r.Type.Val;
                        vol.Size = r.Capacity.Val;
                        vol.Completion = r.TaskCompletion.Val;
                        vol.Name = r.Name.Val;
                        vol.Type = string.Empty;
                        vol.Status = Deltabyte.Raid.Basic.Int2ArrayStatus(r.Status.Val);
                        vol.Task = Deltabyte.Raid.Basic.Int2TaskStatus(r.TaskStatus.Val);
                        if (logging) Logger.log(this, "disks...");
                        if (r.Disk != null)
                        {
                            foreach (var d in r.Disk)
                            {
                                DiskData dsk = new DiskData();
                                dsk.Id = did++;
                                dsk.Index = d.Index.Val;
                                dsk.Size = d.Capacity.Val;
                                dsk.Temp = d.Temperature.Val;
                                dsk.Vendor = d.Vendor.Val;
                                dsk.Model = d.Model.Val;
                                dsk.Serial = d.Serial.Val;
                                dsk.Revision = d.Revision.Val;
                                dsk.Status = d.State;
                                dsk.Temperature = d.Temperature.Val.ToString();
                                dsk.Measure = string.Empty;
                                dsk.Ssd = (d.NonSpinning.Val == 1).ToString();
                                dsk.Location = d.Location.Val;
                                int a = d.Loc.isEnclosure ? d.Loc.Enclosure : d.Loc.Connector;
                                int b = d.Loc.isEnclosure ? d.Loc.Slot : d.Loc.Device;
                                dsk.Loc = new Location(d.Loc.isEnclosure, a, b);
                                vol.Disks.Add(dsk);
                            }
                        }
                        if (logging) Logger.log(this, "...done");
                        //vol.Disks.Sort();
                        Volumes.Add(vol);
                    }
                }
                if (logging) Logger.log(this, "...done");
            }
            if (logging) Logger.log(this, "end");
        }

        public void Refresh()
        {
            try
            {
                Deltabyte.Raid.Controller c = new Deltabyte.Raid.Controller();
                Status = c.Data.State;
                Temp = c.Data.Temperature.Item2;
                Temperature = Temp.ToString();
                foreach (var vol in Volumes)
                {
                    foreach (var dsk in vol.Disks)
                    {
                        dsk.Status = DiskData.GetState(dsk.Id-1);
                        dsk.Temp = DiskData.GetTemp(dsk.Id-1);
                    }
                }
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
        }

        public bool Equal(ControllerData c)
        {
            if (Id != c.Id) return false;
            if (Temp != c.Temp) return false;
            if (Vendor != c.Vendor) return false;
            if (Model != c.Model) return false;
            if (Serial != c.Serial) return false;
            if (Name != c.Name) return false;
            if (Status != c.Status) return false;
            if (Temperature != c.Temperature) return false;
            for (int i = 0; i < Volumes.Count; i++)
            {
                if (Volumes[i].NotEqual(c.Volumes[i])) return false;
            }
            return true;
        }

        public bool Equal(ControllerData c, bool b)
        {
            if (Id != c.Id) return false;
            if (Temp != c.Temp) return false;
            if (Vendor != c.Vendor) return false;
            if (Model != c.Model) return false;
            if (Serial != c.Serial) return false;
            if (Name != c.Name) return false;
            if (Status != c.Status) return false;
            if (Temperature != c.Temperature) return false;
            if (b)
            {
                for (int i = 0; i < Volumes.Count; i++)
                {
                    if (Volumes[i].NotEqual(c.Volumes[i])) return false;
                }
            }
            return true;
        }

        public bool NotEqual(ControllerData c)
        {
            if (Id != c.Id) return true;
            if (Temp != c.Temp) return true;
            if (Vendor != c.Vendor) return true;
            if (Model != c.Model) return true;
            if (Serial != c.Serial) return true;
            if (Name != c.Name) return true;
            if (Status != c.Status) return true;
            if (Temperature != c.Temperature) return true;
            for (int i = 0; i < Volumes.Count; i++)
            {
                if (Volumes[i].NotEqual(c.Volumes[i])) return true;
            }
            return false;
        }

        public bool NotEqual(ControllerData c, bool b)
        {
            if (Id != c.Id) return true;
            if (Temp != c.Temp) return true;
            if (Vendor != c.Vendor) return true;
            if (Model != c.Model) return true;
            if (Serial != c.Serial) return true;
            if (Name != c.Name) return true;
            if (Status != c.Status) return true;
            if (Temperature != c.Temperature) return true;
            if (b)
            {
                for (int i = 0; i < Volumes.Count; i++)
                {
                    if (Volumes[i].NotEqual(c.Volumes[i])) return true;
                }
            }
            return false;
        }

        public List<string> Info()
        {
            List<string> sl = new List<string>();
            sl.Add(string.Format("{0,-24} : {1}", "Id", Id));
            sl.Add(string.Format("{0,-24} : {1}", "Temp", Temp));
            sl.Add(string.Format("{0,-24} : {1}", "Vendor", Vendor));
            sl.Add(string.Format("{0,-24} : {1}", "Model", Model));
            sl.Add(string.Format("{0,-24} : {1}", "Serial", Serial));
            sl.Add(string.Format("{0,-24} : {1}", "Name", Name));
            sl.Add(string.Format("{0,-24} : {1}", "Status", Status));
            sl.Add(string.Format("{0,-24} : {1}", "Temperature", Temperature));
            sl.Add(Deltabyte.Raid.Basic.RepeatChar('=', 80));
            foreach (var v in Volumes)
            {
                sl.AddRange(v.Info());
                sl.Add(Deltabyte.Raid.Basic.RepeatChar('-', 80));
            }
            return sl;
        }
        #endregion

        #region Caller
        public static bool Okay()
        {
            return Deltabyte.Raid.SnmpController.CheckStatus();
        }

        public static int Overall()
        {
            return Deltabyte.Raid.SnmpController.CheckStatus() ? 3 : 2;
        }

        public static string GetTemp()
        {
            return Deltabyte.Raid.SnmpController.CheckTemperature().ToString();
        }

        public static string GetState()
        {
            using (ControllerData c = new ControllerData(true))
            {
                return c.Status;
            }
        }
        #endregion
    }

    public class Raid : IDisposable
    {
        #region Properties
        public ControllerData Controller { get; set; }
        public ControllerData Current { get; set; }
        public ControllerData Original { get; set; }
        private int LastStatus;
        private int Timer;
        private bool Logout = false;
        #endregion

        #region Constructor
        public Raid()
        {
            Logger.log(this, "start");
            Timer = 12;
            LastStatus = ControllerData.Overall();
            Logger.log(this, "got status");
            Logger.log(this, "load data");
            Load();
            Logger.log(this, "end");
        }

        public void Dispose()
        {
            if (Current != null) Current.Dispose();
            if (Original != null) Original.Dispose();
        }
        #endregion

        #region Methods
        private void Load()
        {
            try
            {
                Current = new ControllerData(true);
                Save(true);
                CopyFrom();
                if (Logout) { Controller = Current; Logger.log(this, Info()); }
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
        }

        public void Refresh()
        {
            int s = ControllerData.Overall();
            if ((s == 3) && (s == LastStatus) && (--Timer > 0)) return;
            Timer = 12;
            LastStatus = s;
            Current.Refresh();
            if (Current.NotEqual(Original))
            {
                Save(false);
                CopyFrom();
            }
        }

        private void Save(bool init)
        {
            using (Data dbms = new Data())
            {
                if (init)
                {
                    dbms.DeleteDB("volumedisks");
                    dbms.DeleteDB("disk");
                    dbms.DeleteDB("volume");
                    dbms.DeleteDB("controller");
                    dbms.SetDB(Current);
                }
                else
                {
                    dbms.RefreshDB(Current);
                }
            }
        }

        private void CopyTo()
        {
            if (Original == null) return;
            if (Current == null) Current = new ControllerData();
            Current.Clear();
            Current.Id = Original.Id;
            Current.Temp = Original.Temp;
            Current.Vendor = Original.Vendor;
            Current.Model = Original.Model;
            Current.Serial = Original.Serial;
            Current.Name = Original.Name;
            Current.Status = Original.Status;
            Current.Temperature = Original.Temperature;
            Current.Volumes = new List<VolumeData>();
            foreach (var item in Original.Volumes)
            {
                Current.Volumes.Add(new VolumeData(item));
            }
        }

        private void CopyFrom()
        {
            if (Current == null) return;
            if (Original == null) Original = new ControllerData();
            Original.Clear();
            Original.Id = Current.Id;
            Original.Temp = Current.Temp;
            Original.Vendor = Current.Vendor;
            Original.Model = Current.Model;
            Original.Serial = Current.Serial;
            Original.Name = Current.Name;
            Original.Status = Current.Status;
            Original.Temperature = Current.Temperature;
            Original.Volumes = new List<VolumeData>();
            foreach (var item in Current.Volumes)
            {
                Original.Volumes.Add(new VolumeData(item));
            }
        }

        public bool Equal(Raid r)
        {
            return true;
        }

        public bool NotEqual(Raid r)
        {
            return false;
        }

        public List<string> Info()
        {
            List<string> sl = new List<string>();
            sl.AddRange(Controller.Info());
            return sl;
        }
        #endregion
    }

    public class Data : IDisposable
    {
        #region Properties
        private MySqlConnection Connection { get; set; }
        private string _connection = "server=localhost;user=root;database=Deltabyte;port=3306;password=Gib8aufNr.5712";
        List<Tuple<string, string>> Values;
        private string User = Environment.UserName;
        private DateTime Now;
        private bool Connected = false;
        private bool _logging = false;
        #endregion

        #region Constructor
        public Data()
        {
            try
            {
                Connection = new MySqlConnection(_connection);
                Connected = true;
            }
            catch (Exception e)
            {
                SetException(e);
            }

        }
        public void Dispose()
        {

        }
        #endregion

        #region Methods
        public Boolean IsConnected()
        {
            return Connected;
        }

        public List<Tuple<string, string>> SetController(ControllerData c)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("id", c.Id.ToString()));
            vals.Add(new Tuple<string, string>("vendor", c.Vendor));
            vals.Add(new Tuple<string, string>("model", c.Model));
            vals.Add(new Tuple<string, string>("serial", c.Serial));
            vals.Add(new Tuple<string, string>("webname", c.Name));
            vals.Add(new Tuple<string, string>("status", c.Status));
            vals.Add(new Tuple<string, string>("temperature", c.Temperature));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public List<Tuple<string, string>> SetVolume(VolumeData v)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("id", v.Id.ToString()));
            vals.Add(new Tuple<string, string>("num", v.Index.ToString()));
            vals.Add(new Tuple<string, string>("name", v.Name));
            vals.Add(new Tuple<string, string>("type", v.Type));
            vals.Add(new Tuple<string, string>("status", v.Status));
            vals.Add(new Tuple<string, string>("level", v.Level.ToString()));
            vals.Add(new Tuple<string, string>("size", v.Size.ToString()));
            vals.Add(new Tuple<string, string>("task", v.Task));
            vals.Add(new Tuple<string, string>("completion", v.Completion.ToString()));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public List<Tuple<string, string>> SetDisk(DiskData d)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("id", d.Id.ToString()));
            vals.Add(new Tuple<string, string>("num", d.Index.ToString()));
            vals.Add(new Tuple<string, string>("vendor", d.Vendor));
            vals.Add(new Tuple<string, string>("model", d.Model));
            vals.Add(new Tuple<string, string>("serial", d.Serial));
            vals.Add(new Tuple<string, string>("revision", d.Revision));
            vals.Add(new Tuple<string, string>("status", d.Status));
            vals.Add(new Tuple<string, string>("temperature", d.Temperature));
            vals.Add(new Tuple<string, string>("size", d.Size.ToString()));
            vals.Add(new Tuple<string, string>("measure", d.Measure));
            vals.Add(new Tuple<string, string>("ssd", d.Ssd));
            vals.Add(new Tuple<string, string>("location", d.Location));
            vals.Add(new Tuple<string, string>("enclosure", d.Loc.Enclosure.ToString()));
            vals.Add(new Tuple<string, string>("slot", d.Loc.Slot.ToString()));
            vals.Add(new Tuple<string, string>("connector", d.Loc.Connector.ToString()));
            vals.Add(new Tuple<string, string>("device", d.Loc.Device.ToString()));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public List<Tuple<string, string>> SetVolumeDisk(int i, int v, int d)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("id", i.ToString()));
            vals.Add(new Tuple<string, string>("vid", v.ToString()));
            vals.Add(new Tuple<string, string>("did", d.ToString()));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public List<Tuple<string, string>> RefreshController(ControllerData c)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("status", c.Status));
            vals.Add(new Tuple<string, string>("temperature", c.Temperature));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public List<Tuple<string, string>> RefreshVolume(VolumeData v)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("status", v.Status));
            //vals.Add(new Tuple<string, string>("task", v.Task));
            //vals.Add(new Tuple<string, string>("completion", v.Completion.ToString()));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public List<Tuple<string, string>> RefreshDisk(DiskData d)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("status", d.Status));
            vals.Add(new Tuple<string, string>("temperature", d.Temperature));
            vals.Add(new Tuple<string, string>("usr", User));
            vals.Add(new Tuple<string, string>("dat", Now.ToString("yyyy-MM-dd HH:mm:ss")));
            return vals;
        }

        public void DeleteDB(string s)
        {
            if (Connected)
            {
                Connection.Open();
                using (MySqlTransaction trans = Connection.BeginTransaction())
                {
                    try
                    {
                        delete(s);
                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        Logger.log(this, e.ToString());
                    }
                    finally
                    {
                        Connection.Close();
                    }
                }
            }
        }

        public void SetDB(ControllerData c)
        {
            try
            {
                if (Connected)
                {
                    Connection.Open();
                    using (MySqlTransaction trans = Connection.BeginTransaction())
                    {
                        try
                        {
                            int id = 1;
                            insert("controller", SetController(c), trans);
                            foreach (VolumeData v in c.Volumes)
                            {
                                insert("volume", SetVolume(v), trans);
                                foreach (DiskData d in v.Disks)
                                {
                                    if (d.Size == -1) d.Size = 0;
                                    insert("disk", SetDisk(d), trans);
                                    insert("volumedisks", SetVolumeDisk(id++, v.Id, d.Id), trans);
                                }
                            }
                            trans.Commit();
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                            Logger.log(this, e.ToString());
                        }
                        finally
                        {
                            Connection.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
        }

        public void RefreshDB(ControllerData c)
        {
            try
            {
                if (Connected)
                {
                    Connection.Open();
                    using (MySqlTransaction trans = Connection.BeginTransaction())
                    {
                        try
                        {
                            UInt64 id = 1;
                            update("controller", id, RefreshController(c));
                            foreach (VolumeData v in c.Volumes)
                            {
                                update("volume", (UInt64)v.Id, RefreshVolume(v));
                                foreach (DiskData d in v.Disks)
                                {
                                    update("disk", (UInt64)d.Id, RefreshDisk(d));
                                }
                            }
                            trans.Commit();
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                            Logger.log(this, e.ToString());
                        }
                        finally
                        {
                            Connection.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
        }
        #endregion

        #region Dbms
        /// <summary>
        /// insert record
        /// </summary>
        /// <param name="t">table name</param>
        /// <param name="v">list of columns and values</param>
        /// <returns></returns>
        public Boolean insert(string t, List<Tuple<string, string>> v, MySqlTransaction m)
        {
            string c = string.Empty;
            foreach (var item in v)
            {
                if (c != string.Empty) c += ", ";
                c += item.Item1;
            }
            string sql = "insert into " + t + " (" + c + ") values (";
            ResetException();
            try
            {
                for (int i = 0; i < v.Count; i++)
                {
                    if (i > 0) sql += ", ";
                    sql += "@" + i.ToString();
                }
                sql += ")";
                using (MySqlCommand cmd = new MySqlCommand(sql, Connection, m))
                {
                    int i = 0;
                    foreach (var item in v)
                    {
                        if (_logging) Logger.log(this, string.Format("{0} : {1}", item.Item1, item.Item2));
                        if (string.IsNullOrWhiteSpace(item.Item2))
                        {
                            cmd.Parameters.AddWithValue("@" + i.ToString(), DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + i.ToString(), item.Item2);
                        }
                        i++;
                    }
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                SetException(e, sql);
            }
            return false;
        }

        /// <summary>
        /// update relevant record
        /// </summary>
        /// <param name="t">table name</param>
        /// <param name="id">record identifier</param>
        /// <param name="v">list of pairs column, value to change</param>
        /// <returns></returns>
        public Boolean update(string t, UInt64 id, List<Tuple<string, string>> v)
        {
            string sql = "update " + t + " set ";
            ResetException();
            try
            {
                foreach (var item in v)
                {
                    if (item.Item1 == "id") continue;
                    if (item.Item1 == "usr") continue;
                    if (item.Item1 == "dat") continue;
                    sql += item.Item1 + " = @" + item.Item1 + ", ";
                }
                sql += " usr = @usr, dat = CURRENT_TIMESTAMP where id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
                {
                    foreach (var item in v)
                    {
                        if (item.Item1 == "usr") continue;
                        if (item.Item1 == "dat") continue;
                        if (string.IsNullOrWhiteSpace(item.Item2))
                        {
                            cmd.Parameters.AddWithValue("@" + item.Item1, DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@" + item.Item1, item.Item2);
                        }
                    }
                    cmd.Parameters.AddWithValue("@usr", Environment.UserName);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                SetException(e, sql);
            }
            return false;
        }

        /// <summary>
        /// delete relevant record
        /// </summary>
        /// <param name="id">id to delete</param>
        /// <returns></returns>
        public Boolean delete(string t)
        {
            string sql = "delete from " + t;
            ResetException();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
                {
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                SetException(e, sql);
            }
            return false;
        }


        #endregion

        #region Error
        private void SetException(Exception e)
        {
            Logger.log(this, e.ToString());
        }

        private void SetException(Exception e, string s)
        {
            Logger.log(this, e.ToString() + " (" + s + ")");
        }

        private void SetException(Exception e, string s, string x)
        {
            Logger.log(this, e.ToString() + " (" + s + ") " + x);
        }

        private void ResetException()
        {
        }
        #endregion
    }
}