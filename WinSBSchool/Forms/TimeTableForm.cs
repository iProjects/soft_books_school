using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class TimeTableForm : Form
    {

        #region "enum"
        enum CalendarMode
        {
            MONTH_MODE = 0,
            WEEK_MODE,
            DAY_MODE
        }
        enum CalendarItemType
        {
            LESSON = 0,
            EXTRA_CURRICULAR_ACTIVITY,
            MEETING,
            BREAK
        }
        #endregion "enum"

        #region "private fields"
        string connection;
        List<CalendarItem> _items = new List<CalendarItem>();
        List<ItemInfo_DTO> _items_dto = new List<ItemInfo_DTO>();
        CalendarItem contextItem = null;
        SBSchoolDBEntities db;
        Repository rep;
        string user;
        ClassStream _ClassStream;
        string _activity_venue;
        public FileInfo ItemsFile
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "DBScripts/items.xml"));
            }
        }
        private CalendarHighlightRange[] _highlightRanges;
        private CalendarMode CurrentCalendarMode;
        private const int maximumViewDays = 31;
        private const int minimumDaysInWeekView = 7;
        private const int maximumDaysInWeekView = 7;
        private const int daysInWeek = 7;
        /// <summary>
         /// Gets or sets the time ranges that should be highlighted as work-time.
         /// This ranges are week based.
         /// </summary>
          public CalendarHighlightRange[] HighlightRanges
          {
              get { return _highlightRanges; }
             set { _highlightRanges = value;   }
          }
        #endregion "private fields"

        #region "constructor"
        public TimeTableForm(string _user, string Conn)
        {
            InitializeComponent();

            user = _user;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }
        #endregion "constructor"

        #region "private methods"
        private void TimeTable_Load(object sender, EventArgs e)
        {
            try
            {
                IQueryable<ClassStream> scstreams = db.ClassStreams.OrderBy(i => i.Description);
                List<ClassStream> classstreams = scstreams.ToList();
                bindingSourceClassStream.DataSource = classstreams;
                cboClassStreams.DataSource = bindingSourceClassStream;
                cboClassStreams.ValueMember = "Id";
                cboClassStreams.DisplayMember = "Description";

                /*read the xml from database*/
                //if (ItemsFile.Exists)
                //{
                //    List<ItemInfo> lst = new List<ItemInfo>();
                //    XmlSerializer xml = new XmlSerializer(lst.GetType());
                //    using (Stream _school = ItemsFile.OpenRead())
                //    {
                //        lst = xml.Deserialize(_school) as List<ItemInfo>;
                //    }
                //    foreach (ItemInfo item in lst)
                //    {
                //        CalendarItem cal = new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Text);
                //        if (!(item.R == 0 && item.G == 0 && item.B == 0))
                //        {
                //            cal.ApplyColor(Color.FromArgb(item.A, item.R, item.G, item.B));
                //        }
                //        _items.Add(cal);
                //    }
                //    PlaceItems();
                //}


                //Monthview colors
                monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
                monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#FFD700");
                monthView1.DaySelectedTextColor = CalendarColorTable.FromHex("#FF1493");
                monthView1.MonthTitleTextColor = CalendarColorTable.FromHex("#00008B");
                monthView1.MonthTitleTextColorInactive = CalendarColorTable.FromHex("#FFF0F5");
                monthView1.MonthTitleColor = CalendarColorTable.FromHex("#00FF00");
                monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#8A2BE2");

                monthView1.SelectionStart = DateTime.Now;
                monthView1.SelectionEnd = DateTime.Now;
                monthView1.MaxSelectionCount = 40;
                monthView1.DayNamesVisible = true; 

                DateTime today = DateTime.Today;
                DateTime firstMonthDay = new DateTime(today.Year, today.Month, 1);
                DateTime lastMonthDay = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                calendar1.SetViewRange(firstMonthDay, lastMonthDay);
                calendar1.FirstDayOfWeek = DayOfWeek.Monday;

                calendar1.HighlightRanges = new CalendarHighlightRange[] { 
                  new CalendarHighlightRange( DayOfWeek.Monday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                 new CalendarHighlightRange( DayOfWeek.Tuesday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                 new CalendarHighlightRange( DayOfWeek.Wednesday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                 new CalendarHighlightRange( DayOfWeek.Thursday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
                 new CalendarHighlightRange( DayOfWeek.Friday, new TimeSpan(8,0,0), new TimeSpan(17,0,0)),
             };

                Populate_Timetable();

                radioButtonWeekMode.Checked = true;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PlaceItems()
        {
            try
            {
                foreach (CalendarItem item in _items)
                {
                    if (calendar1.ViewIntersects(item))
                    { 
                        calendar1.Items.Add(item);
                    }
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void Populate_Timetable()
        {
            try
            {
                calendar1.Items.Clear();
                _items = new List<CalendarItem>();
                string calendar_timetable_Temp_filename = "DBScripts/items_Temp.xml";
                this.GetDataFromDB(calendar_timetable_Temp_filename);
                if (File.Exists(calendar_timetable_Temp_filename))
                {
                    List<ItemInfo_DTO> calendar_timetable = this.GetDataFromXML(calendar_timetable_Temp_filename);
                    foreach (var item in calendar_timetable)
                    {
                        CalendarItem cal = new CalendarItem(calendar1, DateTime.Parse(item.StartTime), DateTime.Parse(item.EndTime), item.Text);
                        if (!(item.R == "0" && item.G == "0" && item.B == "0"))
                        {
                            cal.ApplyColor(Color.FromArgb(int.Parse(item.A), int.Parse(item.R), int.Parse(item.G), int.Parse(item.B)));
                        }
                        _items.Add(cal);
                    }
                }
                PlaceItems();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<ItemInfo_DTO> GetDataFromXML(string filename)
        {
            try
            {
                using (XmlReader xmlRdr = new XmlTextReader(filename))
                {
                    return new List<ItemInfo_DTO>(
                       (from sysElem in XDocument.Load(xmlRdr).Element("ArrayOfItemInfo").Elements("ItemInfo")
                        select new ItemInfo_DTO(
                           (string)sysElem.Attribute("StartTime"),
                           (string)sysElem.Attribute("EndTime"),
                           (string)sysElem.Attribute("Text"),
                           (string)sysElem.Attribute("A"),
                           (string)sysElem.Attribute("R"),
                           (string)sysElem.Attribute("G"),
                           (string)sysElem.Attribute("B")
                        )).ToList());
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private bool GetDataFromDB(string filename)
        {
            try
            {
                List<ItemInfo_DTO> lst = new List<ItemInfo_DTO>();
                if (cboClassStreams.SelectedIndex != -1)
                {
                    ClassStream cs = (ClassStream)cboClassStreams.SelectedItem;
                    string _startDate = monthView1.SelectionStart.ToString();
                    string _endDate = monthView1.SelectionEnd.ToString();
                    var _ttquery = from tt in db.TimeTables
                                   where tt.ClassStreamId == cs.Id
                                   select tt;
                    List<TimeTable> _StreamTT = _ttquery.ToList();
                    List<ItemInfo_DTO> timetable_list = new List<ItemInfo_DTO>();
                    foreach (var item in _StreamTT)
                    {
                        string _xml = item.ClassTimeTableXML;

                        XmlSerializer xmls = new XmlSerializer(lst.GetType());
                        XmlReader xr = XmlReader.Create(new StringReader(_xml));
                        var xMembers = from members in XElement.Load(xr).Elements()
                                       select members;
                        var status = new BindingList<KeyValuePair<string, string>>();
                        foreach (var x in xMembers.Attributes())
                        {
                            status.Add(new KeyValuePair<string, string>(x.Name.ToString(), x.Value.ToString()));
                        }

                        IEnumerable<string> allStrings = status.Select(z => z.Value).ToList();
                        List<IEnumerable<string>> listOfLists = new List<IEnumerable<string>>();
                        for (int i = 0; i < allStrings.Count(); i += 7)
                        {
                            listOfLists.Add(allStrings.Skip(i).Take(7));
                        }

                        foreach (var x in listOfLists)
                        {
                            var _arr = x.ToArray();

                            ItemInfo_DTO info_dto = new ItemInfo_DTO(_arr[0], _arr[1], _arr[2], _arr[3], _arr[4], _arr[5], _arr[6]);
                            if (!timetable_list.Contains(info_dto))
                            {
                                timetable_list.Add(info_dto);
                            }
                        }
                    }
                    var xml = new XElement("ArrayOfItemInfo", timetable_list.Select(x => new XElement("ItemInfo",
                                   new XAttribute("StartTime", x.StartTime.ToString()),
                                   new XAttribute("EndTime", x.EndTime.ToString()),
                                    new XAttribute("Text", x.Text),
                                     new XAttribute("A", x.A.ToString()),
                                      new XAttribute("R", x.R.ToString()),
                                      new XAttribute("G", x.G.ToString()),
                                      new XAttribute("B", x.B.ToString()))));
                    xml.Save(filename);
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /*save calendar to xml*/
                string calendar_timetable_filename = "DBScripts/items.xml";
                if (_items.Count != 0)
                {
                    var xml = new XElement("ArrayOfItemInfo", _items.Select(x => new XElement("ItemInfo",
                                        new XAttribute("StartTime", x.StartDate.ToString()),
                    new XAttribute("EndTime", x.EndDate.ToString()),
                     new XAttribute("Text", x.Text),
                      new XAttribute("A", x.ForeColor.A.ToString()),
                       new XAttribute("R", x.ForeColor.R.ToString()),
                       new XAttribute("G", x.ForeColor.G.ToString()),
                       new XAttribute("B", x.ForeColor.B.ToString()))));
                    xml.Save(calendar_timetable_filename);

                    /*save xml to db*/
                    XmlDocument doc = new XmlDocument();
                    doc.Load(calendar_timetable_filename);
                    string timetable_xml_contents = doc.InnerXml;
                    string temp_timetable_xml = File.ReadAllText(calendar_timetable_filename);
                    if (cboClassStreams.SelectedIndex != -1)
                    {
                        ClassStream cs = (ClassStream)cboClassStreams.SelectedItem;
                        TimeTable _tt = new TimeTable();
                        _tt.ClassStreamId = cs.Id;
                        _tt.ClassTimeTableXML = timetable_xml_contents;

                        if (db.TimeTables.Any(i => i.ClassStreamId == _tt.ClassStreamId))
                        {
                            var _ttquery = (from tt in db.TimeTables
                                            where tt.ClassStreamId == _tt.ClassStreamId
                                            select tt)
                                          .FirstOrDefault();

                            TimeTable _tt_dto = _ttquery;
                            _tt_dto.ClassTimeTableXML = _tt.ClassTimeTableXML;
                            rep.UpdateTimeTable(_tt_dto);

                            if (_tt_dto != null)
                            {
                                List<ItemInfo_DTO> calendar_timetable = this.GetDataFromXML(calendar_timetable_filename);
                                foreach (var item in calendar_timetable)
                                {
                                    TimeTableDet ttd = new TimeTableDet();
                                    ttd.TimeTableId = _tt_dto.Id;
                                    ttd.SubjectShortCode = "Agr";
                                    ttd.RoomId = 1;
                                    ttd.Recurrent = "D";
                                    ttd.Activity = item.Text;
                                    ttd.Venue = item.Text;
                                    ttd.Text = item.Text;
                                    ttd.StartTime = DateTime.Parse(item.StartTime);
                                    ttd.EndTime = DateTime.Parse(item.EndTime);
                                    ttd.A = int.Parse(item.A);
                                    ttd.R = int.Parse(item.R);
                                    ttd.G = int.Parse(item.G);
                                    ttd.B = int.Parse(item.B);

                                    if (!db.TimeTableDets.Any(i => i.TimeTableId == ttd.TimeTableId && i.StartTime == ttd.StartTime && i.EndTime == ttd.EndTime && i.Text == ttd.Text))
                                    {
                                        db.TimeTableDets.AddObject(ttd);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            MessageBox.Show("Save Successful!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (!db.TimeTables.Any(i => i.ClassStreamId == _tt.ClassStreamId))
                        {
                            db.TimeTables.AddObject(_tt);
                            db.SaveChanges();

                            var _ttquery = (from tt in db.TimeTables
                                            where tt.ClassStreamId == _tt.ClassStreamId
                                            select tt)
                                              .FirstOrDefault();
                            TimeTable _tt_dto = _ttquery;

                            if (_tt_dto != null)
                            {
                                List<ItemInfo_DTO> calendar_timetable = this.GetDataFromXML(calendar_timetable_filename);
                                foreach (var item in calendar_timetable)
                                {
                                    TimeTableDet ttd = new TimeTableDet();
                                    ttd.TimeTableId = _tt_dto.Id;
                                    ttd.SubjectShortCode = "Agr";
                                    ttd.RoomId = 1;
                                    ttd.Recurrent = "D";
                                    ttd.Activity = item.Text;
                                    ttd.Venue = item.Text;
                                    ttd.Text = item.Text;
                                    ttd.StartTime = DateTime.Parse(item.StartTime);
                                    ttd.EndTime = DateTime.Parse(item.EndTime);
                                    ttd.A = int.Parse(item.A);
                                    ttd.R = int.Parse(item.R);
                                    ttd.G = int.Parse(item.G);
                                    ttd.B = int.Parse(item.B);

                                    if (!db.TimeTableDets.Any(i => i.TimeTableId == ttd.TimeTableId && i.StartTime == ttd.StartTime && i.EndTime == ttd.EndTime && i.Text == ttd.Text))
                                    {
                                        db.TimeTableDets.AddObject(ttd);
                                        db.SaveChanges();
                                    }
                                }
                            }
                            MessageBox.Show("Save Successful!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void TimeTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                /* Ask if you want save changes and save xml to db*/
                //if (!File.Exists(calendar_timetable_filename))
                //{
                //foreach (var item in _items)
                //{
                //    XDocument doc = XDocument.Load(calendar_timetable_filename);
                //    ItemInfo_DTO itemdto = new ItemInfo_DTO();
                //    doc.Element("ArrayOfItemInfo").Add(
                //   new XElement("ItemInfo",
                //   new XAttribute("StartTime", item.StartDate.ToString()),
                //    new XAttribute("EndTime", item.EndDate.ToString()),
                //     new XAttribute("Text", item.Text),
                //      new XAttribute("A", item.PatternColor.A.ToString()),
                //       new XAttribute("R", item.PatternColor.R.ToString()),
                //       new XAttribute("G", item.PatternColor.G.ToString()),
                //       new XAttribute("B", item.PatternColor.B.ToString())));
                //    doc.Save(calendar_timetable_filename);
                //}
                //    //List<ItemInfo> lst = new List<ItemInfo>();
                //    //foreach (CalendarItem item in _items)
                //    //{
                //    //    lst.Add(new ItemInfo(item.StartDate, item.EndDate, item.Text, item.BackgroundColor));
                //    //}
                //    //XmlSerializer xmls = new XmlSerializer(lst.GetType());
                //    //using (Stream _school = ItemsFile.OpenWrite())
                //    //{
                //    //    xmls.Serialize(_school, lst);
                //    //    _school.Close();
                //    //}
                //}
                // XDocument doc = XDocument.Load(filename);
                // doc.Element("ArrayOfItemInfo").Add(
                //new XElement("ItemInfo",
                //new XAttribute("StartTime", _arr[0]),
                // new XAttribute("EndTime", _arr[1]),
                // new XAttribute("Text", _arr[2]),
                // new XAttribute("A", _arr[3]),
                // new XAttribute("R", _arr[4]),
                // new XAttribute("G", _arr[5]),
                // new XAttribute("B", _arr[6])));
                // doc.Save(filename);
                //if (!File.Exists(calendar_timetable_Temp_filename))
                //{
                //    var xml = new XElement("ArrayOfItemInfo", new XElement("ItemInfo",
                //               new XAttribute("StartTime", ""),
                //               new XAttribute("EndTime", ""),
                //                new XAttribute("Text", ""),
                //                 new XAttribute("A", ""),
                //                  new XAttribute("R", ""),
                //                  new XAttribute("G", ""),
                //                  new XAttribute("B", "")));
                //    xml.Save(calendar_timetable_Temp_filename);
                //}
                //List<ItemInfo> lst = new List<ItemInfo>();
                //foreach (CalendarItem item in _items)
                //{
                //    lst.Add(new ItemInfo(item.StartDate, item.EndDate, item.Text, item.BackgroundColor));
                //}
                //XmlSerializer xmls = new XmlSerializer(lst.GetType());

                //if (ItemsFile.Exists)
                //{
                //    ItemsFile.Delete();
                //}
                //using (Stream _school = ItemsFile.OpenWrite())
                //{
                //    xmls.Serialize(_school, lst);
                //    _school.Close();
                //}

                //string calendar_timetable_filename = "DBScripts/items.xml";
                //if (File.Exists(calendar_timetable_filename))
                //{
                //    foreach (var item in _items)
                //    {
                //        XDocument doc = XDocument.Load(calendar_timetable_filename);
                //        ItemInfo_DTO itemdto = new ItemInfo_DTO();
                //        doc.Element("ArrayOfItemInfo").Add(
                //        new XElement("ItemInfo",
                //        new XAttribute("StartTime", item.StartDate.ToString()),
                //         new XAttribute("EndTime", item.EndDate.ToString()),
                //          new XAttribute("Text", item.Text),
                //           new XAttribute("A", item.PatternColor.A),
                //            new XAttribute("R", item.PatternColor.R),
                //            new XAttribute("G", item.PatternColor.G),
                //            new XAttribute("B", item.PatternColor.B)));
                //        doc.Save(calendar_timetable_filename);
                //    }
                //}

                //List<ItemInfo> lst = new List<ItemInfo>();
                //foreach (CalendarItem item in _items)
                //{
                //    lst.Add(new ItemInfo(item.StartDate, item.EndDate, item.Text, item.BackgroundColor));
                //}
                //XmlSerializer xmls = new XmlSerializer(lst.GetType());

                //if (ItemsFile.Exists)
                //{
                //    ItemsFile.Delete();
                //}
                //using (Stream _school = ItemsFile.OpenWrite())
                //{
                //    xmls.Serialize(_school, lst);
                //    _school.Close();
                //}

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            try
            {
                //PlaceItems();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            try
            {
                //_items.Add(e.Item);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
            try
            {
                Text = e.Item.Text; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            try
            {
                //MessageBox.Show(e.Item.Text);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            try
            {
                //calendar1.ActivateEditMode();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            try
            {
                _items.Remove(e.Item);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            try
            {
                calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //e.SuppressKeyPress = true;
                //e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void calendar1_ItemSelected(object sender, CalendarItemEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void TimeTableForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //if (e.Button == MouseButtons.Left)
                //{
                //    foreach (CalendarItem item in _items)
                //    {
                //        if (calendar1.ViewIntersects(item))
                //        {
                //            calendar1.Items.AsReadOnly();
                //        }
                //    }
                //}
                //if (e.Button == MouseButtons.Right)
                //{
                //    foreach (CalendarItem item in _items)
                //    {
                //        if (calendar1.ViewIntersects(item))
                //        {
                //            calendar1.Items.AsReadOnly();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void fiveMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendar1.TimeScale = CalendarTimeScale.FiveMinutes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void sixMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendar1.TimeScale = CalendarTimeScale.SixMinutes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void tenMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendar1.TimeScale = CalendarTimeScale.TenMinutes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void fifteenMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void thirtyMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void sixtyMinutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void redTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ApplyColor(Color.Red);
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void yellowTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ApplyColor(Color.Gold);
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void greenTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ApplyColor(Color.Green);
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void blueTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ApplyColor(Color.DarkBlue);
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void otherColorTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        foreach (CalendarItem item in calendar1.GetSelectedItems())
                        {
                            item.ApplyColor(dlg.Color);
                            calendar1.Invalidate(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void diagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.Pattern = System.Drawing.Drawing2D.HatchStyle.ForwardDiagonal;
                    item.PatternColor = Color.Red;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.Pattern = System.Drawing.Drawing2D.HatchStyle.Vertical;
                    item.PatternColor = Color.Red;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.Pattern = System.Drawing.Drawing2D.HatchStyle.Horizontal;
                    item.PatternColor = Color.Red;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void hatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                    item.PatternColor = Color.Red;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.Pattern = System.Drawing.Drawing2D.HatchStyle.DiagonalCross;
                    item.PatternColor = Color.Empty;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
                Populate_Timetable();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //calendar1.ActivateEditMode();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void northToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ImageAlign = CalendarItemImageAlign.North;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void eastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ImageAlign = CalendarItemImageAlign.East;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void southToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ImageAlign = CalendarItemImageAlign.South;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void westToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    item.ImageAlign = CalendarItemImageAlign.West;
                    calendar1.Invalidate(item);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "*.gif|*.gif|*.png|*.png|*.jpg|*.jpg";

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        Image img = Image.FromFile(dlg.FileName);

                        foreach (CalendarItem item in calendar1.GetSelectedItems())
                        {
                            item.Image = img;
                            calendar1.Invalidate(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboClassStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /*repopulate the*/

                /*_items =  db.timetable.where(_SchoolClass=>_SchoolClass.ClassstreamId == clsid)*/
                Populate_Timetable();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void pickSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ttdf_On_Activity_Venue_Selected(object sender, Activity_Venue_SelectEventArgs e)
        {
            try
            {
                Set_Activity_Venue(e._Activity_Venue,e._Object); 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void Set_Activity_Venue(ItemInfo item,Object obj)
        {
            try
            {
                if (item != null)
                {
                    _activity_venue = item.Text;
                    CalendarItem cal = new CalendarItem(calendar1, item.StartTime, item.EndTime, item.Text);
                    if (!(item.R == 0 && item.G == 0 && item.B == 0))
                    {
                        cal.ApplyColor(Color.FromArgb(item.A, item.R, item.G, item.B));
                    }
                    cal.Tag = obj;
                    _items.Add(cal);
                    PlaceItems();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnSearchClassStream_Click(object sender, EventArgs e)
        {
            try
            {
                SearchClassStreamSimpleForm scssf = new SearchClassStreamSimpleForm(connection) { Owner = this };
                scssf.OnClassStreamListSelected += new SearchClassStreamSimpleForm.ClassStreamSelectHandler(scssf_OnClassStreamListSelected);
                scssf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void scssf_OnClassStreamListSelected(object sender, ClassStreamSelectEventArgs e)
        {
            try
            {
                SetClassStream(e._ClassStream);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetClassStream(ClassStream _class_Stream)
        {
            try
            {
                if (_class_Stream != null)
                {
                    _ClassStream = _class_Stream;
                    bindingSourceClassStream.DataSource = _ClassStream;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboClassStreams.SelectedIndex != -1)
                {
                    ClassStream cs = (ClassStream)cboClassStreams.SelectedItem;
                    var _ttquery = (from tt in db.TimeTables
                                    where tt.ClassStreamId == cs.Id
                                    select tt).FirstOrDefault();
                    TimeTable _tt = _ttquery;
                    if (_tt != null)
                    {
                        //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(cs, _tt, user, connection);
                        //_viewer.WindowState = FormWindowState.Normal;
                        //_viewer.StartPosition = FormStartPosition.CenterScreen;
                        //_viewer.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboClassStreams.SelectedIndex != -1)
                {
                    ClassStream cs = (ClassStream)cboClassStreams.SelectedItem;
                    var _ttquery = (from tt in db.TimeTables
                                    where tt.ClassStreamId == cs.Id
                                    select tt).FirstOrDefault();
                    TimeTable _tt = _ttquery;
                    if (_tt != null)
                    {
                        //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(cs, _tt, user, connection);
                        //_viewer.WindowState = FormWindowState.Normal;
                        //_viewer.StartPosition = FormStartPosition.CenterScreen;
                        //_viewer.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void lessonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /* picks an activity*/
                ClassStream clsstrm = (ClassStream)cboClassStreams.SelectedItem;
                DateTime _startDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _startDate = monthView1.SelectionStart;
                }
                else
                {
                    _startDate = DateTime.Today;
                }
                DateTime _endDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _endDate = monthView1.SelectionStart;
                }
                else
                {
                    _endDate = DateTime.Today;
                }
                string _type = "lesson";
                TimeTableDetailsForm ttdf = new TimeTableDetailsForm(_type,_startDate, _endDate, clsstrm, connection) { Owner = this };
                ttdf.On_Activity_Venue_Selected += new TimeTableDetailsForm.Activity_Venue_SelectHandler(ttdf_On_Activity_Venue_Selected);
                ttdf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /* picks an activity*/
                ClassStream clsstrm = (ClassStream)cboClassStreams.SelectedItem;
                DateTime _startDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _startDate = monthView1.SelectionStart;
                }
                else
                {
                    _startDate = DateTime.Today;
                }
                DateTime _endDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _endDate = monthView1.SelectionStart;
                }
                else
                {
                    _endDate = DateTime.Today;
                }
                string _type = "break";
                TimeTableDetailsForm ttdf = new TimeTableDetailsForm(_type,_startDate, _endDate, clsstrm, connection) { Owner = this };
                ttdf.On_Activity_Venue_Selected += new TimeTableDetailsForm.Activity_Venue_SelectHandler(ttdf_On_Activity_Venue_Selected);
                ttdf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void extracurricularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /* picks an activity*/
                ClassStream clsstrm = (ClassStream)cboClassStreams.SelectedItem;
                DateTime _startDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _startDate = monthView1.SelectionStart;
                }
                else
                {
                    _startDate = DateTime.Today;
                }
                DateTime _endDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _endDate = monthView1.SelectionStart;
                }
                else
                {
                    _endDate = DateTime.Today;
                }
                string _type = "extracurricular";
                TimeTableDetailsForm ttdf = new TimeTableDetailsForm(_type,_startDate, _endDate, clsstrm, connection) { Owner = this };
                ttdf.On_Activity_Venue_Selected += new TimeTableDetailsForm.Activity_Venue_SelectHandler(ttdf_On_Activity_Venue_Selected);
                ttdf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void meetingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                /* picks an activity*/
                ClassStream clsstrm = (ClassStream)cboClassStreams.SelectedItem;
                DateTime _startDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _startDate = monthView1.SelectionStart;
                }
                else
                {
                    _startDate = DateTime.Today;
                }
                DateTime _endDate;
                if (monthView1.SelectionStart != new DateTime())
                {
                    _endDate = monthView1.SelectionStart;
                }
                else
                {
                    _endDate = DateTime.Today;
                }
                string _type = "meeting";
                TimeTableDetailsForm ttdf = new TimeTableDetailsForm(_type,_startDate, _endDate, clsstrm, connection) { Owner = this };
                ttdf.On_Activity_Venue_Selected += new TimeTableDetailsForm.Activity_Venue_SelectHandler(ttdf_On_Activity_Venue_Selected);
                ttdf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonMonthMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Set_Calendar_Vew_Mode();
                Populate_Timetable();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonWeekMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Set_Calendar_Vew_Mode();
                Populate_Timetable();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonDayMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Set_Calendar_Vew_Mode();
                Populate_Timetable();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool Set_Calendar_Vew_Mode()
        {
            try
            {
                foreach (Control ctrl in groupBoxCalendarMode.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {
                                case "radioButtonMonthMode":
                                    CurrentCalendarMode = CalendarMode.MONTH_MODE;
                                    Show_Calendar_Mode();
                                    break;
                                case "radioButtonWeekMode":
                                    CurrentCalendarMode = CalendarMode.WEEK_MODE;
                                    Show_Calendar_Mode();
                                    break;
                                case "radioButtonDayMode":
                                    CurrentCalendarMode = CalendarMode.DAY_MODE;
                                    Show_Calendar_Mode();
                                    break;
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            try
            {
                base.OnMouseWheel(e);
                if (calendar1.Focused)
                {
                    //monthView1.ViewStart = calendar1.ViewStart.Subtract(
                    //    new TimeSpan(DateTime.DaysInMonth(calendar1.ViewStart.Year,
                    //        (calendar1.ViewStart.Month - 1)), 0, 0, 0));
                }
                else
                {
                    //DateTime firstMonthDay = monthView1.ViewStart.AddMonths(1);
                    //DateTime lastMonthDay = monthView1.ViewStart.AddMonths(2);
                    //calendar1.SetViewRange(firstMonthDay, lastMonthDay);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool Show_Calendar_Mode()
        {
            try
            {
                DateTime today = DateTime.Today;
                if (CurrentCalendarMode == CalendarMode.MONTH_MODE)
                {
                    DateTime firstMonthDay = new DateTime(today.Year, today.Month, 1);
                    DateTime lastMonthDay = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                    calendar1.SetViewRange(firstMonthDay, lastMonthDay);
                    monthView1.ViewStart = calendar1.ViewStart.Subtract(
                        new TimeSpan(DateTime.DaysInMonth(calendar1.ViewStart.Year, (calendar1.ViewStart.Month - 1)), 0, 0, 0)
                        );
                }
                if (CurrentCalendarMode == CalendarMode.WEEK_MODE)
                {
                    DateTime firstWeekDay = today.Subtract(new TimeSpan(((int)today.DayOfWeek - 1), 0, 0, 0));
                    DateTime lastWeekDay = today.AddDays(daysInWeek - (int)today.DayOfWeek + 1);
                    calendar1.SetViewRange(firstWeekDay, lastWeekDay);
                    monthView1.ViewStart = calendar1.ViewStart.Subtract(
                        new TimeSpan(DateTime.DaysInMonth(calendar1.ViewStart.Year, (calendar1.ViewStart.Month - 1)), 0, 0, 0)
                        );
                }
                if (CurrentCalendarMode == CalendarMode.DAY_MODE)
                {
                    calendar1.SetViewRange(today, today);
                    monthView1.ViewStart = calendar1.ViewStart.Subtract(
                        new TimeSpan(DateTime.DaysInMonth(calendar1.ViewStart.Year, (calendar1.ViewStart.Month - 1)), 0, 0, 0)
                        );
                }
                ShowDateInToolbox();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        private bool ShowDateInToolbox()
        {
            try
            {
                StringBuilder dateStart = new StringBuilder();
                StringBuilder dateFinish = new StringBuilder();
                System.Globalization.DateTimeFormatInfo myInvariantInfo = new System.Globalization.DateTimeFormatInfo();

                if (CurrentCalendarMode == CalendarMode.MONTH_MODE)
                {
                    dateStart.Append(myInvariantInfo.GetMonthName(calendar1.ViewStart.Month));
                    if (calendar1.ViewStart.Year == calendar1.ViewEnd.Year)
                    {
                        if (calendar1.ViewStart.Month != calendar1.ViewEnd.Month)
                        {
                            dateFinish.Append(" - " + myInvariantInfo.GetMonthName(calendar1.ViewEnd.Month));
                        }
                    }
                    else
                    {
                        dateStart.Append("  " + calendar1.ViewStart.Year + " - ");
                        dateFinish.Append(myInvariantInfo.GetMonthName(calendar1.ViewEnd.Month));
                    }

                    dateFinish.Append("  " + calendar1.ViewEnd.Year);
                }
                if ((CurrentCalendarMode == CalendarMode.WEEK_MODE) || (CurrentCalendarMode == CalendarMode.DAY_MODE))
                {
                    if (calendar1.ViewStart.Date == calendar1.ViewEnd.Date)
                    {
                        dateFinish.Append(calendar1.ViewEnd.Day.ToString());
                        dateFinish.Append("  " + myInvariantInfo.GetMonthName(calendar1.ViewEnd.Month));
                        dateFinish.Append("  " + calendar1.ViewEnd.Year);
                    }
                    else
                    {
                        dateStart.Append(calendar1.ViewStart.Day.ToString());
                        if (calendar1.ViewStart.Year == calendar1.ViewEnd.Year)
                        {
                            if (calendar1.ViewStart.Month != calendar1.ViewEnd.Month)
                            {
                                dateStart.Append("  " + myInvariantInfo.GetMonthName(calendar1.ViewStart.Month));
                            }
                        }
                        else
                        {
                            dateStart.Append("  " + myInvariantInfo.GetMonthName(calendar1.ViewStart.Month));
                            dateStart.Append("  " + calendar1.ViewStart.Year + " - ");
                        }
                        dateFinish.Append(" - " + calendar1.ViewEnd.Day.ToString());
                        dateFinish.Append("  " + myInvariantInfo.GetMonthName(calendar1.ViewEnd.Month));
                        dateFinish.Append("  " + calendar1.ViewEnd.Year);
                    }
                }
                this.Text = dateStart.ToString() + dateFinish.ToString();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        /// <summary>
        /// Get the first day of the month for
        /// any full date submitted
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        private DateTime GetFirstDayOfMonth(DateTime dtDate)
        {
            // set return value to the first day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtFrom = dtDate;
            // remove all of the days in the month
            // except the first day and set the
            // variable to hold that date
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
            // return the first day of the month
            return dtFrom;
        }
        /// <summary>
        /// Get the first day of the month for a
        /// month passed by it'_school integer value
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        private DateTime GetFirstDayOfMonth(int iMonth)
        {
            // set return value to the last day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtFrom = new DateTime(DateTime.Now.Year, iMonth, 1);
            // remove all of the days in the month
            // except the first day and set the
            // variable to hold that date
            dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1));
            // return the first day of the month
            return dtFrom;
        }
        /// <summary>
        /// Get the last day of the month for any
        /// full date
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        private DateTime GetLastDayOfMonth(DateTime dtDate)
        {
            // set return value to the last day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtTo = dtDate;
            // overshoot the date by a month
            dtTo = dtTo.AddMonths(1);
            // remove all of the days in the next month
            // to get bumped down to the last day of the
            // previous month
            dtTo = dtTo.AddDays(-(dtTo.Day));
            // return the last day of the month
            return dtTo;
        }
        /// <summary>
        /// Get the last day of a month expressed by it'_school
        /// integer value
        /// </summary>
        /// <param name="iMonth"></param>
        /// <returns></returns>
        private DateTime GetLastDayOfMonth(int iMonth)
        {
            // set return value to the last day of the month
            // for any date passed in to the method
            // create a datetime variable set to the passed in date
            DateTime dtTo = new DateTime(DateTime.Now.Year, iMonth, 1);
            // overshoot the date by a month
            dtTo = dtTo.AddMonths(1);
            // remove all of the days in the next month
            // to get bumped down to the last day of the
            // previous month
            dtTo = dtTo.AddDays(-(dtTo.Day));
            // return the last day of the month
            return dtTo;
        }
        #endregion "private methods"





    }
}