using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class TimeTableDetailsForm : Form
    {
        string connection;
        ItemInfo _ItemInfo;
        SBSchoolDBEntities db; 
        //delegate
        public delegate void Activity_Venue_SelectHandler(object sender, Activity_Venue_SelectEventArgs e);
        //event
        public event Activity_Venue_SelectHandler On_Activity_Venue_Selected;
        List<Venue> _venues;
        List<Activity> _activities;
        ClassStream _ClassStream;
        DateTime _startDate;
        DateTime _endDate;
        string _type;

        public TimeTableDetailsForm(string type,DateTime startDate, DateTime endDate, ClassStream clsstrm, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

            if (clsstrm == null)
                throw new ArgumentNullException("Class Stream is invalid");
            _ClassStream = clsstrm;

            _startDate = startDate;
            _endDate = endDate;

            _type = type;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (IsTimeTableDetailValid())
                {
                    TimeTableDet _ttDet = new TimeTableDet();
                    switch (_type)
                    {
                        case "lesson":
                            var _activity = (Activity)_lstActivities.SelectedItem;
                            Subject _subject = db.Subjects.Where(i => i.ShortCode == _activity.Name).FirstOrDefault();
                            if (_subject != null)
                            {
                                _ttDet.SubjectShortCode = _subject.ShortCode;
                            }
                            var _venue = (Venue)_lstVenues.SelectedItem;
                            Room _room = db.Rooms.Where(i => i.Description.StartsWith(_venue.Name)).FirstOrDefault();
                            if (_room != null)
                            {
                                _ttDet.RoomId = _room.Id;
                            }
                            var _recurrent = (KeyValuePair<string, string>)cboRecurrent.SelectedItem;
                            _ttDet.Recurrent = _recurrent.Key; 
                            _ttDet.Activity = _activity.Name; 
                            _ttDet.Venue = _venue.Name;
                            string _text = _lstActivities.SelectedValue.ToString() + " - " + _lstVenues.SelectedValue.ToString() + " - " + dtpStartDate.Value.TimeOfDay.ToString() + " - " + dtpEndDate.Value.TimeOfDay.ToString();
                            _ttDet.Text = _text;
                            _ttDet.StartTime = dtpStartDate.Value;
                            _ttDet.EndTime = dtpEndDate.Value;

                            _ItemInfo = new ItemInfo(dtpStartDate.Value, dtpEndDate.Value, _text, Color.BlueViolet);

                            On_Activity_Venue_Selected(this, new Activity_Venue_SelectEventArgs(_ItemInfo, _ttDet));
                            TimeTableForm f = (TimeTableForm)this.Owner;
                            f.Text = _ItemInfo.Text;
                            f.PlaceItems();
                            this.Close();
                            break;
                        case "break":
                            var _brecurrent = (KeyValuePair<string, string>)cboRecurrent.SelectedItem;
                            _ttDet.Recurrent = _brecurrent.Key;
                            var _bactivity = (Activity)_lstActivities.SelectedItem;
                            _ttDet.Activity = _bactivity.Name;
                            var _bvenue = (Venue)_lstVenues.SelectedItem;
                            _ttDet.Venue = _bvenue.Name;
                            string _btext = _lstActivities.SelectedValue.ToString() + " - " + _lstVenues.SelectedValue.ToString() + " - " + dtpStartDate.Value.TimeOfDay.ToString() + " - " + dtpEndDate.Value.TimeOfDay.ToString();
                            _ttDet.Text = _btext;
                            _ttDet.StartTime = dtpStartDate.Value;
                            _ttDet.EndTime = dtpEndDate.Value;

                            _ItemInfo = new ItemInfo(dtpStartDate.Value, dtpEndDate.Value, _btext, Color.BlueViolet);

                            On_Activity_Venue_Selected(this, new Activity_Venue_SelectEventArgs(_ItemInfo, _ttDet));
                            TimeTableForm bf = (TimeTableForm)this.Owner;
                            bf.Text = _ItemInfo.Text;
                            bf.PlaceItems();
                            this.Close();
                            break;
                        case "extracurricular":
                            var _erecurrent = (KeyValuePair<string, string>)cboRecurrent.SelectedItem;
                            _ttDet.Recurrent = _erecurrent.Key;
                            var _eactivity = (Activity)_lstActivities.SelectedItem;
                            _ttDet.Activity = _eactivity.Name;
                            var _evenue = (Venue)_lstVenues.SelectedItem;
                            _ttDet.Venue = _evenue.Name;
                            string _etext = _lstActivities.SelectedValue.ToString() + " - " + _lstVenues.SelectedValue.ToString() + " - " + dtpStartDate.Value.TimeOfDay.ToString() + " - " + dtpEndDate.Value.TimeOfDay.ToString();
                            _ttDet.Text = _etext;
                            _ttDet.StartTime = dtpStartDate.Value;
                            _ttDet.EndTime = dtpEndDate.Value;

                            _ItemInfo = new ItemInfo(dtpStartDate.Value, dtpEndDate.Value, _etext, Color.BlueViolet);

                            On_Activity_Venue_Selected(this, new Activity_Venue_SelectEventArgs(_ItemInfo, _ttDet));
                            TimeTableForm ef = (TimeTableForm)this.Owner;
                            ef.Text = _ItemInfo.Text;
                            ef.PlaceItems();
                            this.Close();
                            break;
                        case "meeting":
                            var _mrecurrent = (KeyValuePair<string, string>)cboRecurrent.SelectedItem;
                            _ttDet.Recurrent = _mrecurrent.Key;
                            var _mactivity = (Activity)_lstActivities.SelectedItem;
                            _ttDet.Activity = _mactivity.Name;
                            var _mvenue = (Venue)_lstVenues.SelectedItem;
                            _ttDet.Venue = _mvenue.Name;
                            string _mtext = _lstActivities.SelectedValue.ToString() + " - " + _lstVenues.SelectedValue.ToString() + " - " + dtpStartDate.Value.TimeOfDay.ToString() + " - " + dtpEndDate.Value.TimeOfDay.ToString();
                            _ttDet.Text = _mtext;
                            _ttDet.StartTime = dtpStartDate.Value;
                            _ttDet.EndTime = dtpEndDate.Value;

                            _ItemInfo = new ItemInfo(dtpStartDate.Value, dtpEndDate.Value, _mtext, Color.BlueViolet);

                            On_Activity_Venue_Selected(this, new Activity_Venue_SelectEventArgs(_ItemInfo, _ttDet));
                            TimeTableForm mf = (TimeTableForm)this.Owner;
                            mf.Text = _ItemInfo.Text;
                            mf.PlaceItems();
                            this.Close();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void TimeTableDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                _venues = new List<Venue>();
                _activities = new List<Activity>();

                var recurrent = new BindingList<KeyValuePair<string, string>>();
                recurrent.Add(new KeyValuePair<string, string>("N", "None"));
                recurrent.Add(new KeyValuePair<string, string>("D", "Daily"));
                recurrent.Add(new KeyValuePair<string, string>("W", "Weekly"));
                recurrent.Add(new KeyValuePair<string, string>("M", "Monthly"));
                recurrent.Add(new KeyValuePair<string, string>("Y", "Yearly"));
                cboRecurrent.DataSource = recurrent;
                cboRecurrent.ValueMember = "Key";
                cboRecurrent.DisplayMember = "Value";

                InitializeControls();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            try
            {
                var cls = (from sc in db.SchoolClasses
                           where sc.Id == _ClassStream.ClassId
                           select sc).SingleOrDefault();

                var clssbjcts = from csbjts in db.ClassSubjects.OrderBy(i => i.SubjectCode)
                                where csbjts.ClassId == cls.Id
                                select csbjts;
                List<ClassSubject> _classsubjects = clssbjcts.ToList();
                foreach (var sub in _classsubjects)
                {
                    _activities.Add(new Activity(sub.Subject.ShortCode, ActivityType.SchoolActivity,sub));
                }
                bindingSourceActivities.DataSource = _activities;
                _lstActivities.DataSource = bindingSourceActivities;
                _lstActivities.ValueMember = "Name";
                _lstActivities.DisplayMember = "Name";

                var _roomsquery = from rm in db.Rooms.OrderBy(i => i.Description)
                                  select rm;
                List<Room> _rooms = _roomsquery.ToList();
                foreach (var rm in _rooms)
                {
                    _venues.Add(new Venue(rm.Description, VenueType.SchoolRoom, rm));
                }
                bindingSourceVenues.DataSource = _venues;
                _lstVenues.DataSource = bindingSourceVenues;
                _lstVenues.ValueMember = "Name";
                _lstVenues.DisplayMember = "Name";

                dtpStartDate.Value = _startDate;
                dtpEndDate.Value = _endDate;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool IsTimeTableDetailValid()
        {
            bool noerror = true;
            if (_lstActivities.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(_lstActivities, "Select Activity!");
                return false;
            }
            if (_lstVenues.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(_lstVenues, "Select Venue!");
                return false;
            }
            if (cboRecurrent.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboRecurrent, "Select Recurrent!");
                return false;
            }
            return noerror;
        }
        public void RefreshActivitiesGrid()
        {
            try
            {
                bindingSourceActivities.DataSource = null;
                bindingSourceActivities.DataSource = _activities;
                _lstActivities.SelectedIndex = _lstActivities.Items.Count - 1;
                int nRowIndex = _lstActivities.Items.Count - 1;
                bindingSourceActivities.Position = nRowIndex;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshVenuesGrid()
        {
            try
            {
                bindingSourceVenues.DataSource = null;
                bindingSourceVenues.DataSource = _venues;
                _lstVenues.SelectedIndex = _lstVenues.Items.Count - 1;
                int nRowIndex = _lstVenues.Items.Count - 1;
                bindingSourceVenues.Position = nRowIndex;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnActivity_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtActivity.Text))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtActivity, "Activity cannot be null!");
                }
                if (!string.IsNullOrEmpty(txtActivity.Text))
                {
                    _activities.Add(new Activity(txtActivity.Text, ActivityType.Others, new object()));
                    RefreshActivitiesGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddVenue_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtVenue.Text))
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtVenue, "Venue cannot be null!");
                }
                if (!string.IsNullOrEmpty(txtVenue.Text))
                {
                    _venues.Add(new Venue(txtVenue.Text, VenueType.Others,new object()));
                    RefreshVenuesGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

    }


    public class Venue
    {
        public string Name { get; set; }
        public VenueType VenueType { get; set; }
        public int RoomId { get; set; }
        public object _object { get; set; }

        public Venue(string name, VenueType venuetype,object _obj)
        {
            Name = name;
            VenueType = venuetype;
            _object = _obj;
        }
    }

    public class Activity
    {
        public string Name { get; set; }
        public ActivityType ActivityType { get; set; }
        public object _object { get; set; }

        public Activity(string name, ActivityType activitytype, object _obj)
        {
            Name = name;
            ActivityType = activitytype;
            _object = _obj;
        }
    }

    public enum VenueType
    {
        SchoolRoom,
        Others
    }

    public enum ActivityType
    {
        SchoolActivity,
        Others
    }

    public class Activity_Venue_SelectEventArgs : System.EventArgs
    {
        // add local member variables to hold text
        private ItemInfo _activity_venue;
        private Object _object;

        // class constructor
        public Activity_Venue_SelectEventArgs(ItemInfo activityvenue,Object obj)
        {
            this._activity_venue = activityvenue;
            this._object = obj;
        }

        // Properties - Viewable by each listener
        public ItemInfo _Activity_Venue
        {
            get
            {
                return _activity_venue;
            }
        }
        public Object _Object
        {
            get
            {
                return _object;
            }
        }
    }



}