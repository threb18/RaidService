using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Deltabyte.Info;
using Deltabyte.Info.Extent;

/// <summary>
/// raid data objects
/// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(Location e1, Location e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null)) return false;
            if (ReferenceEquals(e2, null)) return false;
            if (!e1.IsSet.Equals(e2.IsSet)) return false;
            if (!e1.IsEnclosure.Equals(e2.IsEnclosure)) return false;
            if (!e1.Enclosure.Equals(e2.Enclosure)) return false;
            if (!e1.Slot.Equals(e2.Slot)) return false;
            if (!e1.Connector.Equals(e2.Connector)) return false;
            if (!e1.Device.Equals(e2.Device)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(Location e1, Location e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >(Location e1, Location e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.IsSet.CompareTo(e2.IsSet) == 1) return true;
            if (e1.IsEnclosure.CompareTo(e2.IsEnclosure) == 1) return true;
            if (e1.Enclosure.CompareTo(e2.Enclosure) == 1) return true;
            if (e1.Slot.CompareTo(e2.Slot) == 1) return true;
            if (e1.Connector.CompareTo(e2.Connector) == 1) return true;
            if (e1.Device.CompareTo(e2.Device) == 1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <(Location e1, Location e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.IsSet.CompareTo(e2.IsSet) == -1) return true;
            if (e1.IsEnclosure.CompareTo(e2.IsEnclosure) == -1) return true;
            if (e1.Enclosure.CompareTo(e2.Enclosure) == -1) return true;
            if (e1.Slot.CompareTo(e2.Slot) == -1) return true;
            if (e1.Connector.CompareTo(e2.Connector) == -1) return true;
            if (e1.Device.CompareTo(e2.Device) == -1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <=(Location e1, Location e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.IsSet.CompareTo(e2.IsSet) != 1) return true;
            if (e1.IsEnclosure.CompareTo(e2.IsEnclosure) != 1) return true;
            if (e1.Enclosure.CompareTo(e2.Enclosure) != 1) return true;
            if (e1.Slot.CompareTo(e2.Slot) != 1) return true;
            if (e1.Connector.CompareTo(e2.Connector) != 1) return true;
            if (e1.Device.CompareTo(e2.Device) != 1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >=(Location e1, Location e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.IsSet.CompareTo(e2.IsSet) != -1) return true;
            if (e1.IsEnclosure.CompareTo(e2.IsEnclosure) != -1) return true;
            if (e1.Enclosure.CompareTo(e2.Enclosure) != -1) return true;
            if (e1.Slot.CompareTo(e2.Slot) != -1) return true;
            if (e1.Connector.CompareTo(e2.Connector) != -1) return true;
            if (e1.Device.CompareTo(e2.Device) != -1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Equals(Location d)
        {
            if (ReferenceEquals(null, d)) return false;
            if (ReferenceEquals(this, d)) return true;
            if (!IsSet.Equals(d.IsSet)) return false;
            if (!IsEnclosure.Equals(d.IsEnclosure)) return false;
            if (!Enclosure.Equals(d.Enclosure)) return false;
            if (!Slot.Equals(d.Slot)) return false;
            if (!Connector.Equals(d.Connector)) return false;
            if (!Device.Equals(d.Device)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Location)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int code = IsSet.GetHashCode();
                code = (code * 397) ^ IsEnclosure.GetHashCode();
                code = (code * 397) ^ Enclosure.GetHashCode();
                code = (code * 397) ^ Slot.GetHashCode();
                code = (code * 397) ^ Connector.GetHashCode();
                code = (code * 397) ^ Device.GetHashCode();
                return code;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
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

    public class DiskData : IDisposable, IEquatable<DiskData>, IComparable<DiskData>
    {
        #region Properties
        public int Id { get; set; }
        public int Index { get; set; }
        public int Number { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string Revision { get; set; }
        public string Status { get; set; }
        public string Temperature { get; set; }
        public int Temp { get; set; }
        public ulong Size { get; set; }
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
            Number = -1;
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
            Number = d.Number;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(DiskData e1, DiskData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null)) return false;
            if (ReferenceEquals(e2, null)) return false;
            if (!e1.Id.Equals(e2.Id)) return false;
            if (!e1.Index.Equals(e2.Index)) return false;
            if (!e1.Number.Equals(e2.Number)) return false;
            if (!e1.Size.Equals(e2.Size)) return false;
            if (!e1.Temp.Equals(e2.Temp)) return false;
            if (!e1.Vendor.Equals(e2.Vendor)) return false;
            if (!e1.Model.Equals(e2.Model)) return false;
            if (!e1.Serial.Equals(e2.Serial)) return false;
            if (!e1.Revision.Equals(e2.Revision)) return false;
            if (!e1.Status.Equals(e2.Status)) return false;
            if (!e1.Temperature.Equals(e2.Temperature)) return false;
            if (!e1.Measure.Equals(e2.Measure)) return false;
            if (!e1.Ssd.Equals(e2.Ssd)) return false;
            if (!e1.Location.Equals(e2.Location)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(DiskData e1, DiskData e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >(DiskData e1, DiskData e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.Id.CompareTo(e2.Id) == 1) return true;
            if (e1.Index.CompareTo(e2.Index) == 1) return true;
            if (e1.Number.CompareTo(e2.Number) == 1) return true;
            if (e1.Size.CompareTo(e2.Size) == 1) return true;
            if (e1.Temp.CompareTo(e2.Temp) == 1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) == 1) return true;
            if (string.Compare(e1.Model, e2.Model) == 1) return true;
            if (string.Compare(e1.Serial, e2.Serial) == 1) return true;
            if (string.Compare(e1.Revision, e2.Revision) == 1) return true;
            if (string.Compare(e1.Status, e2.Status) == 1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) == 1) return true;
            if (string.Compare(e1.Measure, e2.Measure) == 1) return true;
            if (string.Compare(e1.Ssd, e2.Ssd) == 1) return true;
            if (string.Compare(e1.Location, e2.Location) == 1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <(DiskData e1, DiskData e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.Id.CompareTo(e2.Id) == -1) return true;
            if (e1.Index.CompareTo(e2.Index) == -1) return true;
            if (e1.Number.CompareTo(e2.Number) == -1) return true;
            if (e1.Size.CompareTo(e2.Size) == -1) return true;
            if (e1.Temp.CompareTo(e2.Temp) == -1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) == -1) return true;
            if (string.Compare(e1.Model, e2.Model) == -1) return true;
            if (string.Compare(e1.Serial, e2.Serial) == -1) return true;
            if (string.Compare(e1.Revision, e2.Revision) == -1) return true;
            if (string.Compare(e1.Status, e2.Status) == -1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) == -1) return true;
            if (string.Compare(e1.Measure, e2.Measure) == -1) return true;
            if (string.Compare(e1.Ssd, e2.Ssd) == -1) return true;
            if (string.Compare(e1.Location, e2.Location) == -1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <=(DiskData e1, DiskData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.Id.CompareTo(e2.Id) != 1) return true;
            if (e1.Index.CompareTo(e2.Index) != 1) return true;
            if (e1.Number.CompareTo(e2.Number) != 1) return true;
            if (e1.Size.CompareTo(e2.Size) != 1) return true;
            if (e1.Temp.CompareTo(e2.Temp) != 1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) != 1) return true;
            if (string.Compare(e1.Model, e2.Model) != 1) return true;
            if (string.Compare(e1.Serial, e2.Serial) != 1) return true;
            if (string.Compare(e1.Revision, e2.Revision) != 1) return true;
            if (string.Compare(e1.Status, e2.Status) != 1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) != 1) return true;
            if (string.Compare(e1.Measure, e2.Measure) != 1) return true;
            if (string.Compare(e1.Ssd, e2.Ssd) != 1) return true;
            if (string.Compare(e1.Location, e2.Location) != 1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >=(DiskData e1, DiskData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.Id.CompareTo(e2.Id) != -1) return true;
            if (e1.Index.CompareTo(e2.Index) != -1) return true;
            if (e1.Number.CompareTo(e2.Number) != -1) return true;
            if (e1.Size.CompareTo(e2.Size) != -1) return true;
            if (e1.Temp.CompareTo(e2.Temp) != -1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) != -1) return true;
            if (string.Compare(e1.Model, e2.Model) != -1) return true;
            if (string.Compare(e1.Serial, e2.Serial) != -1) return true;
            if (string.Compare(e1.Revision, e2.Revision) != -1) return true;
            if (string.Compare(e1.Status, e2.Status) != -1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) != -1) return true;
            if (string.Compare(e1.Measure, e2.Measure) != -1) return true;
            if (string.Compare(e1.Ssd, e2.Ssd) != -1) return true;
            if (string.Compare(e1.Location, e2.Location) != -1) return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Equals(DiskData d)
        {
            if (ReferenceEquals(null, d)) return false;
            if (ReferenceEquals(this, d)) return true;
            if (!Id.Equals(d.Id)) return false;
            if (!Index.Equals(d.Index)) return false;
            if (!Number.Equals(d.Number)) return false;
            if (!Size.Equals(d.Size)) return false;
            if (!Temp.Equals(d.Temp)) return false;
            if (!Vendor.Equals(d.Vendor)) return false;
            if (!Model.Equals(d.Model)) return false;
            if (!Serial.Equals(d.Serial)) return false;
            if (!Revision.Equals(d.Revision)) return false;
            if (!Status.Equals(d.Status)) return false;
            if (!Temperature.Equals(d.Temperature)) return false;
            if (!Measure.Equals(d.Measure)) return false;
            if (!Ssd.Equals(d.Ssd)) return false;
            if (!Location.Equals(d.Location)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((DiskData)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int code = Id.GetHashCode();
                code = (code * 397) ^ Index.GetHashCode();
                code = (code * 397) ^ Number.GetHashCode();
                code = (code * 397) ^ Size.GetHashCode();
                code = (code * 397) ^ Temp.GetHashCode();
                code = (code * 397) ^ Vendor.GetHashCode();
                code = (code * 397) ^ Model.GetHashCode();
                code = (code * 397) ^ Serial.GetHashCode();
                code = (code * 397) ^ Revision.GetHashCode();
                code = (code * 397) ^ Status.GetHashCode();
                code = (code * 397) ^ Temperature.GetHashCode();
                code = (code * 397) ^ Measure.GetHashCode();
                code = (code * 397) ^ Ssd.GetHashCode();
                code = (code * 397) ^ Location.GetHashCode();
                code = (code * 397) ^ Loc.GetHashCode();
                return code;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int CompareTo(DiskData d)
        {
            if (d == null) return -1;
            int res = Number.CompareTo(d.Number);
            if (res == 0) res = Id.CompareTo(d.Id);
            if (res == 0) res = Index.CompareTo(d.Index);
            if (res == 0) res = Size.CompareTo(d.Size);
            if (res == 0) res = Temp.CompareTo(d.Temp);
            if (res == 0) res = Vendor.CompareTo(d.Vendor);
            if (res == 0) res = Model.CompareTo(d.Model);
            if (res == 0) res = Serial.CompareTo(d.Serial);
            if (res == 0) res = Revision.CompareTo(d.Revision);
            if (res == 0) res = Status.CompareTo(d.Status);
            if (res == 0) res = Temperature.CompareTo(d.Temperature);
            if (res == 0) res = Measure.CompareTo(d.Measure);
            if (res == 0) res = Ssd.CompareTo(d.Ssd);
            if (res == 0) res = Location.CompareTo(d.Location);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Equal(DiskData d)
        {
            if (Id != d.Id) return false;
            if (Index != d.Index) return false;
            if (Number != d.Number) return false;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool NotEqual(DiskData d)
        {
            if (Id != d.Id) return true;
            if (Index != d.Index) return true;
            if (Number != d.Number) return true;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> Info()
        {
            List<string> sl = new List<string>();
            sl.Add(string.Format("{0,-24} : {1}", "Id", Id));
            sl.Add(string.Format("{0,-24} : {1}", "Index", Index));
            sl.Add(string.Format("{0,-24} : {1}", "Number", Number));
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,2} {1,2} {2,2} {3,-12} {4,-16} {5,-12} {6,3} {7}", Id, Index, Number, Model, Serial, Status, Temperature, Location);
        }
        #endregion

        #region Caller
        /// <summary>
        /// get disk temperature
        /// </summary>
        /// <param name="i">index from 0 to n-1</param>
        /// <returns></returns>
        public static int GetTemp(int i)
        {
            using (Deltabyte.Raid.MergeDisk dsk = new Deltabyte.Raid.MergeDisk())
            {
                //Logger.log(dsk, string.Format("{0}: {1}", i, dsk.Disks[i].Device.RecentTemperature.Val));
                return dsk.Disks[i].Device.RecentTemperature.Val;
            }
        }

        /// <summary>
        /// get disks state
        /// </summary>
        /// <param name="i">index from 0 to n-1</param>
        /// <returns></returns>
        public static string GetState(int i)
        {
            using (Deltabyte.Raid.MergeDisk dsk = new Deltabyte.Raid.MergeDisk())
            {
                return dsk.Disks[i].Device.State;
            }
        }

        /// <summary>
        /// get disk info
        /// </summary>
        /// <param name="i">index from 0 to n-1</param>
        /// <returns></returns>
        public static Tuple<int, string> Refresh(int i)
        {
            using (Deltabyte.Raid.MergeDisk dsk = new Deltabyte.Raid.MergeDisk())
            {
                return new Tuple<int, string>(dsk.Disks[i].Device.RecentTemperature.Val, dsk.Disks[i].Device.State);
            }
        }

        /// <summary>
        /// get current disk count
        /// </summary>
        /// <returns>disk count</returns>
        public static int Count()
        {
            Location loc = new Location();
            int c = 0;
            using (Deltabyte.Raid.Extend ext = new Deltabyte.Raid.Extend())
            {
                c = ext.Data.Count;
            }
            return c;
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
        public ulong Size { get; set; }
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
            Size = 0;
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
            foreach (DiskData d in v.Disks)
            {
                Disks.Add(new DiskData(d));
            }
            //Disks.AddRange(v.Disks);
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
            Disks.Clear();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(VolumeData e1, VolumeData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null)) return false;
            if (ReferenceEquals(e2, null)) return false;
            if (!e1.Id.Equals(e2.Id)) return false;
            if (!e1.Index.Equals(e2.Index)) return false;
            if (!e1.Level.Equals(e2.Level)) return false;
            if (!e1.Size.Equals(e2.Size)) return false;
            if (!e1.Completion.Equals(e2.Completion)) return false;
            if (!e1.Name.Equals(e2.Name)) return false;
            if (!e1.Type.Equals(e2.Type)) return false;
            if (!e1.Status.Equals(e2.Status)) return false;
            if (!e1.Task.Equals(e2.Type)) return false;
            if (!e1.Disks.Equals(e2.Disks)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(VolumeData e1, VolumeData e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >(VolumeData e1, VolumeData e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.Id.CompareTo(e2.Id) == 1) return true;
            if (e1.Index.CompareTo(e2.Index) == 1) return true;
            if (e1.Level.CompareTo(e2.Level) == 1) return true;
            if (e1.Size.CompareTo(e2.Size) == 1) return true;
            if (e1.Completion.CompareTo(e2.Completion) == 1) return true;
            if (string.Compare(e1.Name, e2.Name) == 1) return true;
            if (string.Compare(e1.Type, e2.Type) == 1) return true;
            if (string.Compare(e1.Status, e2.Status) == 1) return true;
            if (string.Compare(e1.Task, e2.Task) == 1) return true;
            if (ReferenceEquals(e1.Disks, e2.Disks)) return false;
            if (ReferenceEquals(e1.Disks, null) && !ReferenceEquals(e2.Disks, null)) return false;
            if (!ReferenceEquals(e1.Disks, null) && ReferenceEquals(e2.Disks, null)) return true;
            if (e1.Disks.Count > e2.Disks.Count) return true;
            for (int i = 0; i < e2.Disks.Count; i++)
            {
                if (e1.Disks[i] > e2.Disks[i]) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <(VolumeData e1, VolumeData e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.Id.CompareTo(e2.Id) == -1) return true;
            if (e1.Index.CompareTo(e2.Index) == -1) return true;
            if (e1.Level.CompareTo(e2.Level) == -1) return true;
            if (e1.Size.CompareTo(e2.Size) == -1) return true;
            if (e1.Completion.CompareTo(e2.Completion) == -1) return true;
            if (string.Compare(e1.Name, e2.Name) == -1) return true;
            if (string.Compare(e1.Type, e2.Type) == -1) return true;
            if (string.Compare(e1.Status, e2.Status) == -1) return true;
            if (string.Compare(e1.Task, e2.Task) == -1) return true;
            if (ReferenceEquals(e1.Disks, e2.Disks)) return false;
            if (ReferenceEquals(e1.Disks, null) && !ReferenceEquals(e2.Disks, null)) return true;
            if (!ReferenceEquals(e1.Disks, null) && ReferenceEquals(e2.Disks, null)) return false;
            if (e1.Disks.Count > e2.Disks.Count) return false;
            for (int i = 0; i < e2.Disks.Count; i++)
            {
                if (e1.Disks[i] < e2.Disks[i]) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <=(VolumeData e1, VolumeData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.Id.CompareTo(e2.Id) != 1) return true;
            if (e1.Index.CompareTo(e2.Index) != 1) return true;
            if (e1.Level.CompareTo(e2.Level) != 1) return true;
            if (e1.Size.CompareTo(e2.Size) != 1) return true;
            if (e1.Completion.CompareTo(e2.Completion) != 1) return true;
            if (string.Compare(e1.Name, e2.Name) != 1) return true;
            if (string.Compare(e1.Type, e2.Type) != 1) return true;
            if (string.Compare(e1.Status, e2.Status) != 1) return true;
            if (string.Compare(e1.Task, e2.Task) != 1) return true;
            if (ReferenceEquals(e1.Disks, e2.Disks)) return true;
            if (ReferenceEquals(e1.Disks, null) && !ReferenceEquals(e2.Disks, null)) return true;
            if (!ReferenceEquals(e1.Disks, null) && ReferenceEquals(e2.Disks, null)) return false;
            if (e1.Disks.Count > e2.Disks.Count) return false;
            if (e1.Disks.Count == e2.Disks.Count)
            {
                for (int i = 0; i < e2.Disks.Count; i++)
                {
                    if (e1.Disks[i] > e2.Disks[i]) return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >=(VolumeData e1, VolumeData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.Id.CompareTo(e2.Id) != -1) return true;
            if (e1.Index.CompareTo(e2.Index) != -1) return true;
            if (e1.Level.CompareTo(e2.Level) != -1) return true;
            if (e1.Size.CompareTo(e2.Size) != -1) return true;
            if (e1.Completion.CompareTo(e2.Completion) != -1) return true;
            if (string.Compare(e1.Name, e2.Name) != -1) return true;
            if (string.Compare(e1.Type, e2.Type) != -1) return true;
            if (string.Compare(e1.Status, e2.Status) != -1) return true;
            if (string.Compare(e1.Task, e2.Task) != -1) return true;
            if (ReferenceEquals(e1.Disks, e2.Disks)) return true;
            if (ReferenceEquals(e1.Disks, null) && !ReferenceEquals(e2.Disks, null)) return false;
            if (!ReferenceEquals(e1.Disks, null) && ReferenceEquals(e2.Disks, null)) return true;
            if (e1.Disks.Count < e2.Disks.Count) return false;
            if (e1.Disks.Count == e2.Disks.Count)
            {
                for (int i = 0; i < e1.Disks.Count; i++)
                {
                    if (e1.Disks[i] < e2.Disks[i]) return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Equals(VolumeData d)
        {
            if (ReferenceEquals(null, d)) return false;
            if (ReferenceEquals(this, d)) return true;
            if (!Id.Equals(d.Id)) return false;
            if (!Index.Equals(d.Index)) return false;
            if (!Level.Equals(d.Level)) return false;
            if (!Size.Equals(d.Size)) return false;
            if (!Completion.Equals(d.Completion)) return false;
            if (!Name.Equals(d.Name)) return false;
            if (!Type.Equals(d.Type)) return false;
            if (!Status.Equals(d.Status)) return false;
            if (!Task.Equals(d.Type)) return false;
            if (!Disks.Equals(d.Disks)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((VolumeData)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int code = Id.GetHashCode();
                code = (code * 397) ^ Index.GetHashCode();
                code = (code * 397) ^ Level.GetHashCode();
                code = (code * 397) ^ Size.GetHashCode();
                code = (code * 397) ^ Completion.GetHashCode();
                code = (code * 397) ^ Name.GetHashCode();
                code = (code * 397) ^ Type.GetHashCode();
                code = (code * 397) ^ Status.GetHashCode();
                code = (code * 397) ^ Task.GetHashCode();
                code = (code * 397) ^ Disks.GetHashCode();
                return code;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int CompareTo(VolumeData d)
        {
            if (d == null) return -1;
            int res = Id.CompareTo(d.Id);
            if (res == 0) res = Index.CompareTo(d.Index);
            if (res == 0) res = Level.CompareTo(d.Level);
            if (res == 0) res = Size.CompareTo(d.Size);
            if (res == 0) res = Completion.CompareTo(d.Completion);
            if (res == 0) res = Name.CompareTo(d.Name);
            if (res == 0) res = Type.CompareTo(d.Type);
            if (res == 0) res = Status.CompareTo(d.Status);
            if (res == 0) res = Task.CompareTo(d.Task);
            if (res == 0) res = Disks.Count.CompareTo(d.Disks.Count);
            if (res == 0)
            {
                for (int i = 0; i < Disks.Count; i++)
                {
                    if (res == 0) res = Disks[i].CompareTo(d.Disks[i]);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,2} {1} {2,-12} {3,12} {4} {5,-12}", Id, Level, Name, Size, Type, Status);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string GetStatus(string s)
        {
            if (Level == Constants.VolumeTypePassthrough) return s;
            if ((Level == Constants.VolumeTypeRaid5) && (missing() > 1)) return Constants.VolumeStatusFailed;
            if ((Level == Constants.VolumeTypeRaid6) && (missing() > 2)) return Constants.VolumeStatusFailed;
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int missing()
        {
            int i = 0;
            foreach (DiskData d in Disks)
            {
                if (d.Status == Constants.DiskStatusMissing) i++;
            }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public void DiskStatus(List<DiskData> o)
        {
            if (Disks.Count == o.Count)
            {
                for (int i = 0; i < Disks.Count; i++)
                {
                    if ((Status == Constants.VolumeStatusRebuilding) && (Disks[i].Status == Constants.DiskStatusNormal) && (o[i].Status == Constants.DiskStatusMissing))
                    {
                        Disks[i].Status = Constants.DiskStatusRebuilding;
                    }
                    else if ((Status == Constants.VolumeStatusRebuilding) && (Disks[i].Status == Constants.DiskStatusNormal) && (o[i].Status == Constants.DiskStatusRebuilding))
                    {
                        Disks[i].Status = Constants.DiskStatusRebuilding;
                    }
                }
            }
            else
            {
                Logger.log(this, string.Format("drive count differs: current = {0}, original = {1}", Disks.Count, o.Count));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="o"></param>
        public void DiskStatus(List<DiskData> c, List<DiskData> o)
        {
            if (c.Count == o.Count)
            {
                for (int i = 0; i < c.Count; i++)
                {
                    if ((Status == Constants.VolumeStatusRebuilding) && (c[i].Status == Constants.DiskStatusNormal) && (o[i].Status == Constants.DiskStatusMissing))
                    {
                        c[i].Status = Constants.DiskStatusRebuilding;
                    }
                    else if ((Status == Constants.VolumeStatusRebuilding) && (c[i].Status == Constants.DiskStatusNormal) && (o[i].Status == Constants.DiskStatusRebuilding))
                    {
                        c[i].Status = Constants.DiskStatusRebuilding;
                    }
                }
            }
            else
            {
                Logger.log(this, string.Format("drive count differs: current = {0}, original = {1}", c.Count, o.Count));
            }
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
        public int DiskCount { get; set; }
        public int Disks { get; set; }
        private readonly bool logging = Constants.Logging;
        #endregion

        #region Constructor
        public ControllerData()
        {
            DiskCount = 0;
            Disks = 0;
        }

        public ControllerData(ControllerData d)
        {
            Id = d.Id;
            Vendor = d.Vendor;
            Model = d.Model;
            Serial = d.Serial;
            Name = d.Name;
            Status = d.Status;
            Temperature = d.Temperature;
            Temp = d.Temp;
            DiskCount = d.DiskCount;
            Disks = d.Disks;
            Volumes = new List<VolumeData>();
            Volumes.AddRange(d.Volumes);
        }

        public ControllerData(bool b)
        {
            if (logging) Logger.log(this, "start");
            DiskCount = 0;
            Disks = 0;
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

        public ControllerData(bool b, bool d)
        {
            logging = d;
            if (logging) Logger.log(this, "start");
            DiskCount = 0;
            Disks = 0;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(ControllerData e1, ControllerData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null)) return false;
            if (ReferenceEquals(e2, null)) return false;
            if (!e1.Id.Equals(e2.Id)) return false;
            if (!e1.Vendor.Equals(e2.Vendor)) return false;
            if (!e1.Model.Equals(e2.Model)) return false;
            if (!e1.Serial.Equals(e2.Serial)) return false;
            if (!e1.Name.Equals(e2.Name)) return false;
            if (!e1.Status.Equals(e2.Status)) return false;
            if (!e1.Temperature.Equals(e2.Temperature)) return false;
            if (!e1.Temp.Equals(e2.Temp)) return false;
            if (!e1.Disks.Equals(e2.Disks)) return false;
            if (!e1.DiskCount.Equals(e2.DiskCount)) return false;
            if (!e1.Volumes.Equals(e2.Volumes)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(ControllerData e1, ControllerData e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >(ControllerData e1, ControllerData e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.Id.CompareTo(e2.Id) == 1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) == 1) return true;
            if (string.Compare(e1.Model, e2.Model) == 1) return true;
            if (string.Compare(e1.Serial, e2.Serial) == 1) return true;
            if (string.Compare(e1.Name, e2.Name) == 1) return true;
            if (string.Compare(e1.Status, e2.Status) == 1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) == 1) return true;
            if (e1.Temp.CompareTo(e2.Temp) == 1) return true;
            if (e1.Disks.CompareTo(e2.Disks) == 1) return true;
            if (e1.DiskCount.CompareTo(e2.DiskCount) == 1) return true;
            if (e1.Volumes.Count.CompareTo(e2.Volumes.Count) == 1) return true;
            for (int i = 0; i < e2.Volumes.Count; i++)
            {
                if (e1.Volumes[i].CompareTo(e2.Volumes[i]) == 1) return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <(ControllerData e1, ControllerData e2)
        {
            if (ReferenceEquals(e1, e2)) return false;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.Id.CompareTo(e2.Id) == -1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) == -1) return true;
            if (string.Compare(e1.Model, e2.Model) == -1) return true;
            if (string.Compare(e1.Serial, e2.Serial) == -1) return true;
            if (string.Compare(e1.Name, e2.Name) == -1) return true;
            if (string.Compare(e1.Status, e2.Status) == -1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) == -1) return true;
            if (e1.Temp.CompareTo(e2.Temp) == -1) return true;
            if (e1.Disks.CompareTo(e2.Disks) == -1) return true;
            if (e1.DiskCount.CompareTo(e2.DiskCount) == -1) return true;
            if (e1.Volumes.Count.CompareTo(e2.Volumes.Count) == -1) return true;
            for (int i = 0; i < e1.Volumes.Count; i++)
            {
                if (e1.Volumes[i].CompareTo(e2.Volumes[i]) == -1) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator <=(ControllerData e1, ControllerData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return true;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return false;
            if (e1.Id.CompareTo(e2.Id) != 1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) != 1) return true;
            if (string.Compare(e1.Model, e2.Model) != 1) return true;
            if (string.Compare(e1.Serial, e2.Serial) != 1) return true;
            if (string.Compare(e1.Name, e2.Name) != 1) return true;
            if (string.Compare(e1.Status, e2.Status) != 1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) != 1) return true;
            if (e1.Temp.CompareTo(e2.Temp) != 1) return true;
            if (e1.Disks.CompareTo(e2.Disks) != 1) return true;
            if (e1.DiskCount.CompareTo(e2.DiskCount) != 1) return true;
            if (e1.Volumes.Count.CompareTo(e2.Volumes.Count) == -1) return true;
            if (e1.Volumes.Count.CompareTo(e2.Volumes.Count) == 0)
            {
                for (int i = 0; i < e2.Volumes.Count; i++)
                {
                    if (e1.Volumes[i].CompareTo(e2.Volumes[i]) == 1) return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator >=(ControllerData e1, ControllerData e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null) && !ReferenceEquals(e2, null)) return false;
            if (!ReferenceEquals(e1, null) && ReferenceEquals(e2, null)) return true;
            if (e1.Id.CompareTo(e2.Id) != -1) return true;
            if (string.Compare(e1.Vendor, e2.Vendor) != -1) return true;
            if (string.Compare(e1.Model, e2.Model) != -1) return true;
            if (string.Compare(e1.Serial, e2.Serial) != -1) return true;
            if (string.Compare(e1.Name, e2.Name) != -1) return true;
            if (string.Compare(e1.Status, e2.Status) != -1) return true;
            if (string.Compare(e1.Temperature, e2.Temperature) != -1) return true;
            if (e1.Temp.CompareTo(e2.Temp) != -1) return true;
            if (e1.Disks.CompareTo(e2.Disks) != -1) return true;
            if (e1.DiskCount.CompareTo(e2.DiskCount) != -1) return true;
            if (e1.Volumes.Count.CompareTo(e2.Volumes.Count) == 1) return true;
            if (e1.Volumes.Count.CompareTo(e2.Volumes.Count) == 0)
            {
                for (int i = 0; i < e2.Volumes.Count; i++)
                {
                    if (e1.Volumes[i].CompareTo(e2.Volumes[i]) == -1) return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Equals(ControllerData d)
        {
            if (ReferenceEquals(null, d)) return false;
            if (ReferenceEquals(this, d)) return true;
            if (!Id.Equals(d.Id)) return false;
            if (!Vendor.Equals(d.Vendor)) return false;
            if (!Model.Equals(d.Model)) return false;
            if (!Serial.Equals(d.Serial)) return false;
            if (!Name.Equals(d.Name)) return false;
            if (!Status.Equals(d.Status)) return false;
            if (!Temperature.Equals(d.Temperature)) return false;
            if (!Temp.Equals(d.Temp)) return false;
            if (!Disks.Equals(d.Disks)) return false;
            if (!DiskCount.Equals(d.DiskCount)) return false;
            if (!Volumes.Equals(d.Volumes)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ControllerData)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Empty;
            string nl = Environment.NewLine;
            s += string.Format("{0,2} {1} {2} {3} {4} {5,3} {6,3} {7,3}{8}", Id, Vendor, Model, Serial, Status, Temp, DiskCount, Disks, nl);
            foreach (VolumeData v in Volumes)
            {
                s += string.Format("    {0}{1}", v, nl);
                foreach (DiskData d in v.Disks)
                {
                    s += string.Format("        {0}{1}", d, nl);
                }
            }
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int code = Id.GetHashCode();
                code = (code * 397) ^ Vendor.GetHashCode();
                code = (code * 397) ^ Model.GetHashCode();
                code = (code * 397) ^ Serial.GetHashCode();
                code = (code * 397) ^ Name.GetHashCode();
                code = (code * 397) ^ Status.GetHashCode();
                code = (code * 397) ^ Temperature.GetHashCode();
                code = (code * 397) ^ Temp.GetHashCode();
                code = (code * 397) ^ Disks.GetHashCode();
                code = (code * 397) ^ DiskCount.GetHashCode();
                code = (code * 397) ^ Volumes.GetHashCode();
                return code;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int CompareTo(ControllerData d)
        {
            if (d == null) return -1;
            int res = Id.CompareTo(d.Id);
            if (res == 0) res = Vendor.CompareTo(d.Vendor);
            if (res == 0) res = Model.CompareTo(d.Model);
            if (res == 0) res = Serial.CompareTo(d.Serial);
            if (res == 0) res = Name.CompareTo(d.Name);
            if (res == 0) res = Status.CompareTo(d.Status);
            if (res == 0) res = Temperature.CompareTo(d.Temperature);
            if (res == 0) res = Temp.CompareTo(d.Temp);
            if (res == 0) res = Disks.CompareTo(d.Disks);
            if (res == 0) res = DiskCount.CompareTo(d.DiskCount);
            if (res == 0) res = Volumes.Count.CompareTo(d.Volumes.Count);
            if (res == 0)
            {
                for (int i = 0; i < Volumes.Count; i++)
                {
                    if (res == 0) res = Volumes[i].CompareTo(d.Volumes[i]);
                    if (res != 0) break;
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
            Disks = 0;
            DiskCount = 0;
            using (Deltabyte.Raid.Volume v = new Deltabyte.Raid.Volume())
            {
                if (v.Data != null)
                {
                    int i = 0;
                    foreach (var r in v.Data)
                    {
                        if (logging) Logger.log(this, r.Info());
                        VolumeData vol = new VolumeData();
                        vol.Id = vid++;
                        vol.Index = r.Index.Val;
                        vol.Level = r.Type.Val;
                        vol.Size = r.Capacity.Val;
                        vol.Completion = r.TaskCompletion.Val;
                        vol.Name = r.Name.Val;
                        vol.Type = string.Empty;
                        vol.Status = v.Raid[i++].State.Val;
                        vol.Task = Deltabyte.Raid.Basic.Int2TaskStatus(r.TaskStatus.Val);
                        if (logging) Logger.log(this, vol.ToString());
                        if (logging) Logger.log(this, "disks...");
                        if (r.Disk != null)
                        {
                            foreach (var d in r.Disk)
                            {
                                DiskCount++;
                                if (d.State != Constants.DiskStatusMissing) Disks++;
                                DiskData dsk = new DiskData();
                                dsk.Id = did++;
                                dsk.Index = d.Index.Val;
                                dsk.Number = d.DisplayNumber;
                                dsk.Size = d.Capacity.Val;
                                dsk.Temp = d.Temperature.Val;
                                dsk.Vendor = d.Vendor.Val;
                                dsk.Model = d.Model.Val;
                                dsk.Serial = d.Serial.Val;
                                dsk.Revision = d.Revision.Val;
                                dsk.Status = d.State;
                                dsk.Temperature = (d.Temperature.Val == -1) ? "nn" : d.Temperature.Val.ToString();
                                dsk.Measure = string.Empty;
                                dsk.Ssd = (d.NonSpinning.Val == 1).ToString();
                                dsk.Location = d.Location.Val;
                                int a = d.Loc.isEnclosure ? d.Loc.Enclosure : d.Loc.Connector;
                                int b = d.Loc.isEnclosure ? d.Loc.Slot : d.Loc.Device;
                                dsk.Loc = new Location(d.Loc.isEnclosure, a, b);
                                if (logging) Logger.log(this, dsk.ToString());
                                vol.Disks.Add(dsk);
                            }
                        }
                        if (logging) Logger.log(this, string.Format("...done. {0}/{1}", DiskCount, Disks));
                        vol.Disks.Sort();
                        Volumes.Add(vol);
                    }
                }
                if (logging) Logger.log(this, string.Format("...done. {0}/{1}", DiskCount, Disks));
            }
            if (logging) Logger.log(this, "end");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            try
            {
                Deltabyte.Raid.Controller c = new Deltabyte.Raid.Controller();
                Status = c.Data.State;
                Temp = c.Data.Temperature.Item2;
                Temperature = Temp.ToString();
                using (Deltabyte.Raid.Volume v = new Deltabyte.Raid.Volume())
                {
                    if (v.Raid != null)
                    {
                        for (int i = 0; i < v.Raid.Count; i++)
                        {
                            Volumes[i].Status = v.Raid[i].State.Val;
                            if (logging) Logger.log(this, string.Format("status = {0} - {1}", Volumes[i].Status, v.Raid[i].State));
                        }
                    }
                }
                Disks = 0;
                Deltabyte.Raid.MergeDisk dsk = new Deltabyte.Raid.MergeDisk();
                foreach (var vol in Volumes)
                {
                    if (logging) Logger.log(this, string.Format("Refresh: {0}", vol.ToString()));
                    vol.Disks.Sort();
                    foreach (var d in vol.Disks)
                    {
                        if (d.Id > 0)
                        {
                            d.Status = dsk.Disks[d.Id - 1].Device.State;
                            d.Temp = dsk.Disks[d.Id - 1].Device.RecentTemperature.Val;
                            if (d.Status != Constants.DiskStatusMissing) Disks++;
                            if (logging) Logger.log(this, string.Format("Refresh: {0}", d.ToString()));
                        }
                    }
                    //vol.Status = GetStatus(vol);
                }
                dsk.Dispose();
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private string GetStatus(VolumeData v)
        {
            string s = Constants.VolumeStatusNormal;
            foreach (DiskData d in v.Disks)
            {
                if (d.Status == Constants.DiskStatusMissing) return Constants.VolumeStatusDegraded;
                if (d.Status == Constants.DiskStatusRebuilding) s = Constants.VolumeStatusRebuilding;
            }
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
            if (Disks != c.Disks) return false;
            for (int i = 0; i < Volumes.Count; i++)
            {
                if (Volumes[i].NotEqual(c.Volumes[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
            if (Disks != c.Disks) return false;
            if (b)
            {
                for (int i = 0; i < Volumes.Count; i++)
                {
                    if (Volumes[i].NotEqual(c.Volumes[i])) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
            if (Disks != c.Disks) return true;
            for (int i = 0; i < Volumes.Count; i++)
            {
                if (Volumes[i].NotEqual(c.Volumes[i])) return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
            if (Disks != c.Disks) return true;
            if (b)
            {
                for (int i = 0; i < Volumes.Count; i++)
                {
                    if (Volumes[i].NotEqual(c.Volumes[i])) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            sl.Add(string.Format("{0,-24} : {1}", "Disks", Disks));
            sl.Add(string.Format("{0,-24} : {1}", "DiskCount", DiskCount));
            //sl.Add(Deltabyte.Raid.Basic.RepeatChar('=', 80));
            foreach (var v in Volumes)
            {
                sl.AddRange(v.Info());
                //sl.Add(Deltabyte.Raid.Basic.RepeatChar('-', 80));
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
        #region Types
        enum MailType
        {
            None = 0,
            Lost = 1,
            Inserted = 2,
            Rebuilding = 3,
            Rebuild = 4
        }
        #endregion

        #region Properties
        public ControllerData Controller { get; set; }
        public ControllerData Current { get; set; }
        public ControllerData Original { get; set; }
        private int LastStatus;
        private int Timer;
        private int Disks;
        private Mail _mail;
        private bool _locked;
        private bool Logout = Constants.Logging;
        #endregion

        #region Constructor
        public Raid()
        {
            if (Logout) Logger.log(this, "start");
            Timer = 12;
            Disks = 0;
            Original = null;
            _locked = false;
            LastStatus = ControllerData.Overall();
            if (Logout) Logger.log(this, "got status");
            if (Logout) Logger.log(this, "load data");
            Load();
            if (Logout) Logger.log(this, "end");
        }

        public Raid(bool b)
        {
            Logout = b;
            if (Logout) Logger.log(this, "start");
            Timer = 12;
            Disks = 0;
            Original = null;
            _locked = false;
            LastStatus = ControllerData.Overall();
            if (Logout) Logger.log(this, "got status");
            if (Logout) Logger.log(this, "load data");
            Load();
            if (Logout) Logger.log(this, "end");
        }

        public Raid(Raid d)
        {
            Controller = d.Controller;
            Current = d.Current;
            Original = d.Original;
            LastStatus = d.LastStatus;
            Timer = d.Timer;
            Disks = d.Disks;
            _mail = d._mail;
            _locked = d._locked;
            Logout = d.Logout;
        }

        public void Dispose()
        {
            if (Current != null) Current.Dispose();
            if (Original != null) Original.Dispose();
            if (_mail != default(Mail)) _mail.Dispose();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator ==(Raid e1, Raid e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (ReferenceEquals(e1, null)) return false;
            if (ReferenceEquals(e2, null)) return false;
            if (!e1.Controller.Equals(e2.Controller)) return false;
            if (!e1.Current.Equals(e2.Current)) return false;
            if (!e1.Original.Equals(e2.Original)) return false;
            if (!e1.LastStatus.Equals(e2.LastStatus)) return false;
            if (!e1.Timer.Equals(e2.Timer)) return false;
            if (!e1.Disks.Equals(e2.Disks)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(Raid e1, Raid e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool Equals(Raid d)
        {
            if (ReferenceEquals(null, d)) return false;
            if (ReferenceEquals(this, d)) return true;
            if (!Controller.Equals(d.Controller)) return false;
            if (!Current.Equals(d.Current)) return false;
            if (!Original.Equals(d.Original)) return false;
            if (!LastStatus.Equals(d.LastStatus)) return false;
            if (!Timer.Equals(d.Timer)) return false;
            if (!Disks.Equals(d.Disks)) return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Raid)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = string.Empty;
            s += string.Format("{0,-16} : {1}{2}", "Controller", Controller, Environment.NewLine);
            s += string.Format("{0,-16} : {1}{2}", "Current", Current, Environment.NewLine);
            s += string.Format("{0,-16} : {1}{2}", "Original", Original, Environment.NewLine);
            s += string.Format("{0,-16} : {1}{2}", "LastStatus", LastStatus, Environment.NewLine);
            s += string.Format("{0,-16} : {1}{2}", "Timer", Timer, Environment.NewLine);
            s += string.Format("{0,-16} : {1}{2}", "Disks", Disks, Environment.NewLine);
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int code = Controller.GetHashCode();
                code = (code * 397) ^ Current.GetHashCode();
                code = (code * 397) ^ Original.GetHashCode();
                code = (code * 397) ^ LastStatus.GetHashCode();
                code = (code * 397) ^ Timer.GetHashCode();
                code = (code * 397) ^ Disks.GetHashCode();
                code = (code * 397) ^ _mail.GetHashCode();
                return code;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public int CompareTo(Raid d)
        {
            if (d == null) return -1;
            int res = Controller.CompareTo(d.Controller);
            if (res == 0) res = Current.CompareTo(d.Current);
            if (res == 0) res = Original.CompareTo(d.Original);
            if (res == 0) res = LastStatus.CompareTo(d.LastStatus);
            if (res == 0) res = Timer.CompareTo(d.Timer);
            if (res == 0) res = Disks.CompareTo(d.Disks);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="o"></param>
        /// <param name="c"></param>
        private void _statuslog(int i, int j, string o, string c)
        {
            Logger.log(this, string.Format("[{0},{1}] o:{2} / c:{3}", i, j, o, c));
        }

        /// <summary>
        /// 
        /// </summary>
        private void _statuslog()
        {
            Logger.log(this, string.Format(""));
            Logger.log(this, string.Format("volumes: current count {0} - original count {1}", Current.Volumes.Count, Original.Volumes.Count));
            for (int i = 0; i < Current.Volumes.Count; i++)
            {
                int cn = Current.Volumes[i].Disks.Count;
                int on = i < Original.Volumes[i].Disks.Count ? Original.Volumes[i].Disks.Count : 0;
                Logger.log(this, string.Format("disks({0}): current count {1} - original count {2}", i, cn, on));
                for (int j = 0; j < Current.Volumes[i].Disks.Count; j++)
                {
                    string cd = Current.Volumes[i].Disks[j].Status;
                    string od = j < Original.Volumes[i].Disks.Count ? Original.Volumes[i].Disks[j].Status : "***";
                    _statuslog(i, j, od, cd);
                }
            }
        }

        /// <summary>
        /// Set proper disk status - missing, rebuilding, present
        /// Areca API just provide status present
        /// </summary>
        private void DiskStatus()
        {
            if (Original == null) return;
            if (Current.Volumes.Count == Original.Volumes.Count)
            {
                for (int i = 0; i < Current.Volumes.Count; i++)
                {
                    if (Current.Volumes[i].Status == Constants.VolumeStatusRebuilding)
                    {
                        if (Current.Volumes[i].Disks.Count == Original.Volumes[i].Disks.Count)
                        {
                            for (int j = 0; j < Current.Volumes[i].Disks.Count; j++)
                            {
                                if ((Original.Volumes[i].Disks[j].Status == Constants.DiskStatusMissing) && (Current.Volumes[i].Disks[j].Status == Constants.DiskStatusNormal))
                                {
                                    Current.Volumes[i].Disks[j].Status = Constants.DiskStatusRebuilding;
                                }
                                else if ((Original.Volumes[i].Disks[j].Status == Constants.DiskStatusRebuilding) && (Current.Volumes[i].Disks[j].Status == Constants.DiskStatusNormal))
                                {
                                    Current.Volumes[i].Disks[j].Status = Constants.DiskStatusRebuilding;
                                }
                            }
                        }
                    }
                    else if (Current.Volumes[i].Status == Constants.VolumeStatusDegraded)
                    {
                        if (Current.Volumes[i].Disks.Count == Original.Volumes[i].Disks.Count)
                        {
                            for (int j = 0; j < Current.Volumes[i].Disks.Count; j++)
                            {
                                if ((Original.Volumes[i].Disks[j].Status == Constants.DiskStatusMissing) && (Current.Volumes[i].Disks[j].Status == Constants.DiskStatusNormal))
                                {
                                    Current.Volumes[i].Disks[j].Status = Constants.DiskStatusMissing;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool IsLocked { get { return _locked; } }

        /// <summary>
        /// 
        /// </summary>
        private void Load()
        {
            _locked = true;
            try
            {
                Current = new ControllerData(true, Logout);
                Disks = Current.Disks;
                DiskStatus();
                Save(true);
                CopyFrom();
                if (Logout) { Controller = Current; Logger.log(this, Info()); }
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
            finally
            {
                _locked = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            if (Logout) Logger.log(this, string.Format("start"));
            _locked = true;
            Tuple<int,int> dc = Deltabyte.Raid.Areca.GetDiskCount();                // item1 = max disk count, item2 = present disk count
            if (Logout) Logger.log(this, string.Format("disk count: {0}/{1}", dc.Item1, dc.Item2));
            if (Disks != dc.Item2)
            {
                if (Logout) Logger.log(this, string.Format("disk count changed {0} - {1}/{2}", Disks, dc.Item1, dc.Item2));
                try
                {
                    Current.Clear();
                    Current.Dispose();
                    Current = new ControllerData(true, Logout);
                    DiskStatus();
                    if (Disks > 0) SetMail();
                    Save(true);
                    CopyFrom();
                }
                catch (Exception e)
                {
                    Logger.log(this, string.Format("disk count changed: {0}", e));
                }
            }
            else
            {
                if (Logout) Logger.log(this, string.Format("check for changes"));
                try
                {
                    int s = ControllerData.Overall();
                    if ((s == 3) && (s == LastStatus) && (--Timer > 0)) { _locked = false; return; }
                    Timer = 12;
                    LastStatus = s;
                    Current.Refresh();
                    DiskStatus();
                    //if (Logout) Logger.log(this, Current.Info());
                    //if (Logout) Logger.log(this, Original.Info());
                    if (Current.NotEqual(Original))
                    {
                        if (Logout) Logger.log(this, "save data");
                        if (Disks > 0) SetMail();
                        Save(false);
                        CopyFrom();
                    }
                }
                catch (Exception e)
                {
                    Logger.log(this, string.Format("data changed: {0}", e));
                }
            }
            Disks = dc.Item2;
            _locked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetMail()
        {
            if (Constants.Logging) Logger.log(this, "start");
            if (Constants.SendMail == false) return;
            if (Current.Disks < Original.Disks)
            {
                if (Constants.Logging) Logger.log(this, string.Format("[01] missing disk: {0} < {1}", Current.Disks, Original.Disks));
                if (Current.Volumes.Count == Original.Volumes.Count)
                {
                    if (Constants.Logging) Logger.log(this, string.Format("[01] volumes count: {0} - {1}", Current.Volumes.Count, Original.Volumes.Count));
                    for (int i = 0; i < Current.Volumes.Count; i++)
                    {
                        if (Current.Volumes[i].Disks.Count <= 2) continue;
                        int n = Original.Volumes[i].Disks.Count - Current.Volumes[i].Disks.Count;
                        if (Constants.Logging) Logger.log(this, string.Format("[01] found non system volume [{0}]: {1} - {2}", Current.Volumes[i].Name, Current.Volumes[i].Status, Original.Volumes[i].Status));
                        for (int j = 0; j < Current.Volumes[i].Disks.Count; j++)
                        {
                            if (Constants.Logging) Logger.log(this, string.Format("[01] disk status: {0} - {1}", Current.Volumes[i].Disks[j].Status, Original.Volumes[i].Disks[j].Status));
                            if ((Current.Volumes[i].Disks[j].Status == Constants.DiskStatusMissing) && (Original.Volumes[i].Disks[j].Status == Constants.DiskStatusNormal))
                            {
                                if (Constants.Logging) Logger.log(this, string.Format("[01] send lost disk mail"));
                                Send(MailData.DiskLost(Current.Volumes[i].Disks[j].Number, Current.Volumes[i].Name, Current.Volumes[i].Disks.Count < 8), Types.EventType.Error);
                                if (--n == 0) break;
                            }
                        }
                    }
                }
            }
            if (Current.Disks > Original.Disks)
            {
                if (Constants.Logging) Logger.log(this, string.Format("[02] new disk: {0} > {1}", Current.Disks, Original.Disks));
                if (Current.Volumes.Count == Original.Volumes.Count)
                {
                    if (Constants.Logging) Logger.log(this, string.Format("[02] volumes count: {0} - {1}", Current.Volumes.Count, Original.Volumes.Count));
                    for (int i = 0; i < Current.Volumes.Count; i++)
                    {
                        if (Current.Volumes[i].Disks.Count <= 2) continue;
                        int n = Current.Volumes[i].Disks.Count - Original.Volumes[i].Disks.Count;
                        if (Constants.Logging) Logger.log(this, string.Format("[02] found non system volume [{0}]: {1} - {2}", Current.Volumes[i].Name, Current.Volumes[i].Status, Original.Volumes[i].Status));
                        for (int j = 0; j < Current.Volumes[i].Disks.Count; j++)
                        {
                            if (Constants.Logging) Logger.log(this, string.Format("[02] disk status: {0} - {1}", Current.Volumes[i].Disks[j].Status, Original.Volumes[i].Disks[j].Status));
                            if ((Current.Volumes[i].Disks[j].Status == Constants.DiskStatusRebuilding) && (Original.Volumes[i].Disks[j].Status == Constants.DiskStatusMissing))
                            {
                                if (Constants.Logging) Logger.log(this, string.Format("[02] send inserted disk mail"));
                                Send(MailData.DiskInserted(Current.Volumes[i].Disks[j].Number), Types.EventType.Info);
                                if (--n == 0) break;
                            }
                        }
                    }
                }
            }
            if (Current.Volumes.Count == Original.Volumes.Count)
            {
                if (Constants.Logging) Logger.log(this, string.Format("[03] volumes count: {0} - {1}", Current.Volumes.Count, Original.Volumes.Count));
                for (int i = 0; i < Current.Volumes.Count; i++)
                {
                    if (Constants.Logging) Logger.log(this, string.Format("[03] found volume [{0}]: {1} - {2}", Current.Volumes[i].Name, Current.Volumes[i].Status, Original.Volumes[i].Status));
                    if ((Current.Volumes[i].Status.ToLower() == Constants.VolumeStatusNormal) && (Original.Volumes[i].Status.ToLower() == Constants.VolumeStatusRebuilding))
                    {
                        if (Constants.Logging) Logger.log(this, string.Format("[03] send rebuild disk mail"));
                        Send(MailData.Rebuild(DiskNumber()), Types.EventType.Info);
                        break;
                    }
                }
            }
            if (Constants.Logging) Logger.log(this, "end");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        private void Send(Tuple<string, string, string> s, Types.EventType t)
        {
            if (Constants.Logging) Logger.log(this, "start");
            if (Constants.SendMail == false) return;
            Mail m = new Mail();
            m.SetTemplate(Constants.MailBodyTemplateFile);
            MailData.Set(m, Types.ReceiverType.Admin, string.Empty);
            MailData.Send(m, s, t);
            if (Constants.Logging) Logger.log(this, "end");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int DiskNumber()
        {
            for (int i = 0; i < Original.Volumes.Count; i++)
            {
                for (int j = 0; j < Original.Volumes[i].Disks.Count; j++)
                {
                    if (Constants.Logging) Logger.log(this, string.Format("original = {0} / Current = {1}", Original.Volumes[i].Disks[j].Status, Current.Volumes[i].Disks[j].Status));
                    if ((Original.Volumes[i].Disks[j].Status == Constants.DiskStatusRebuilding) && (Current.Volumes[i].Disks[j].Status == Constants.DiskStatusNormal))
                    {
                        return Original.Volumes[i].Disks[j].Number;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="init"></param>
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

        /// <summary>
        /// 
        /// </summary>
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
            Current.Disks = Original.Disks;
            Current.DiskCount = Original.DiskCount;
            Current.Volumes = new List<VolumeData>();
            foreach (var item in Original.Volumes)
            {
                Current.Volumes.Add(new VolumeData(item));
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
            Original.Disks = Current.Disks;
            Original.DiskCount = Current.DiskCount;
            Original.Volumes = new List<VolumeData>();
            foreach (var item in Current.Volumes)
            {
                Original.Volumes.Add(new VolumeData(item));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool Equal(Raid r)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool NotEqual(Raid r)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> Info()
        {
            List<string> sl = new List<string>();
            sl.AddRange(Current.Info());
            sl.AddRange(Original.Info());
            return sl;
        }
        #endregion
    }

    public class Data : IDisposable
    {
        #region Properties
        private MySqlConnection Connection { get; set; }
        private string _connection = Constants.ConnectionPath;
        List<Tuple<string, string>> Values;
        private string User = Environment.UserName;
        private DateTime Now;
        private bool Connected = false;
        private bool _logging = Constants.Logging;
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
                Logger.log(this, e.ToString());
            }

        }
        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean IsConnected()
        {
            return Connected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool RefreshConnection()
        {
            try
            {
                Connected = false;
                Connection.Close();
                Connection.Dispose();
                Connection = new MySqlConnection(_connection);
                Connected = true;
            }
            catch (Exception e)
            {
                Logger.log(this, e.ToString());
            }
            return Connected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> SetDisk(DiskData d)
        {
            Now = DateTime.Now;
            List<Tuple<string, string>> vals = new List<Tuple<string, string>>();
            vals.Add(new Tuple<string, string>("id", d.Id.ToString()));
            vals.Add(new Tuple<string, string>("num", d.Number.ToString()));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void SetDB(ControllerData c)
        {
            if (_logging) Logger.log(this, "start");
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
                                    //if (d.Size == -1) d.Size = 0;
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
            if (_logging) Logger.log(this, "end");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void RefreshDB(ControllerData c)
        {
            if (_logging) Logger.log(this, "start");
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
            if (_logging) Logger.log(this, "end");
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
            if (_logging) Logger.log(this, "start");
            string c = string.Empty;
            foreach (var item in v)
            {
                if (c != string.Empty) c += ", ";
                c += item.Item1;
            }
            string sql = "insert into " + t + " (" + c + ") values (";
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
                Logger.log(this, string.Format("{0}{1}{2}{3}", Environment.NewLine, sql, Environment.NewLine, e));
            }
            if (_logging) Logger.log(this, "end");
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
            if (_logging) Logger.log(this, "start");
            string sql = "update " + t + " set ";
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
                if (_logging) Logger.log(this, string.Format("sql = {0} [{1}]", sql, id));
                using (MySqlCommand cmd = new MySqlCommand(sql, Connection))
                {
                    foreach (var item in v)
                    {
                        if (_logging) Logger.log(this, string.Format("{0} : {1}", item.Item1, item.Item2));
                        if (item.Item1 == "usr") continue;
                        if (item.Item1 == "dat") continue;
                        if (string.IsNullOrWhiteSpace(item.Item2))
                        {
                            if (_logging) Logger.log(this, string.Format("is null {0}", item.Item1));
                            cmd.Parameters.AddWithValue("@" + item.Item1, DBNull.Value);
                        }
                        else
                        {
                            if (_logging) Logger.log(this, string.Format("is not null {0} : {1}", item.Item1, item.Item2));
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
                Logger.log(this, string.Format("{0}{1}{2}{3}", Environment.NewLine, sql, Environment.NewLine, e));
                RefreshConnection();
            }
            if (_logging) Logger.log(this, "end");
            return false;
        }

        /// <summary>
        /// delete relevant record
        /// </summary>
        /// <param name="id">id to delete</param>
        /// <returns></returns>
        public Boolean delete(string t)
        {
            if (_logging) Logger.log(this, "start");
            string sql = "delete from " + t;
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
                Logger.log(this, string.Format("{0}{1}{2}{3}", Environment.NewLine, sql, Environment.NewLine, e));
            }
            if (_logging) Logger.log(this, "end");
            return false;
        }
        #endregion
    }
}