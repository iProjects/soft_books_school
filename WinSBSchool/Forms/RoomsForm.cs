using System; 
using System.Collections.Generic; 
using System.ComponentModel;
using System.Configuration; 
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing; 
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using CommonLib; 
using DAL;

namespace WinSBSchool.Forms
{
    public partial class RoomsForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string _user;
        string connection;

        public RoomsForm(string user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
            _user = user;
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddRoomForm arf = new AddRoomForm(connection) { Owner = this };
                arf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count != 0)
            {
                try
                {
                    Room room = (Room)bindingSourceRooms.Current;
                    Forms.EditRoomForm esf = new Forms.EditRoomForm(room, connection) { Owner = this };
                    esf.Text = room.Description.ToUpper().Trim();
                    esf.ShowDialog(); 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count != 0)
            {
                try
                {
                    Room room = (Room)bindingSourceRooms.Current;

                    var _registeredexamsquery = from re in db.RegisteredExams
                                                where re.RoomId == room.Id
                                                select re;
                    List<RegisteredExam> _RegisteredExams = _registeredexamsquery.ToList();

                    var _timetabledetsquery = from tt in db.TimeTableDets
                                              where tt.RoomId == room.Id
                                              select tt;
                    List<TimeTableDet> _TimeTableDets = _timetabledetsquery.ToList();

                    if (_RegisteredExams.Count > 0)
                    {
                        MessageBox.Show("There is a Registered Exam Associated with this Room.\n DeAssociate the Registered Exam  First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (_TimeTableDets.Count > 0)
                    {
                        MessageBox.Show("There is a Time Table Detail Associated with this Room.\n DeAssociate the Time Table Detail First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Room\n" + room.Description.ToUpper().ToString().Trim().ToUpper(), "Confirm Delete",
        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.DeleteRoom(room);
                            RefreshGrid();

                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshGrid()
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceRooms.DataSource = null;
                    var _roomsquery = from rm in db.Rooms
                                      where rm.IsDeleted == false
                                      select rm;
                    bindingSourceRooms.DataSource = _roomsquery.ToList();
                    groupBox2.Text = bindingSourceRooms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewRooms.Rows)
                    {
                        dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewRooms.Rows.Count - 1;
                        bindingSourceRooms.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceRooms.DataSource = null;
                    var _roomsquery = from rm in db.Rooms
                                      where rm.IsDeleted == false
                                      where rm.Status == "A"
                                      select rm;
                    bindingSourceRooms.DataSource = _roomsquery.ToList();
                    groupBox2.Text = bindingSourceRooms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewRooms.Rows)
                    {
                        dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewRooms.Rows.Count - 1;
                        bindingSourceRooms.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void RoomsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                DataGridViewComboBoxColumn colCboxStatus = new DataGridViewComboBoxColumn();
                colCboxStatus.HeaderText = "Status";
                colCboxStatus.Name = "cbStatus";
                colCboxStatus.DataSource = status;
                // The display member is the name column in the column datasource  
                colCboxStatus.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxStatus.DataPropertyName = "Status";
                // The value member is the primary key of the parent table  
                colCboxStatus.ValueMember = "Key";
                colCboxStatus.MaxDropDownItems = 10;
                colCboxStatus.Width = 80;
                colCboxStatus.DisplayIndex = 6;
                colCboxStatus.MinimumWidth = 5;
                colCboxStatus.FlatStyle = FlatStyle.Flat;
                colCboxStatus.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatus.ReadOnly = true; 
                colCboxStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewRooms.Columns.Contains("cbStatus"))
                {
                    dataGridViewRooms.Columns.Add(colCboxStatus);
                }

                var _roomsquery = from rm in db.Rooms
                                  where rm.IsDeleted == false
                                  where rm.Status=="A"
                                  select rm;
                bindingSourceRooms.DataSource = _roomsquery.ToList();
                groupBox2.Text = bindingSourceRooms.Count.ToString();
                dataGridViewRooms.AutoGenerateColumns = false;
                dataGridViewRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRooms.DataSource = bindingSourceRooms;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewRooms_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count != 0)
            {
                try
                {
                    Room room = (Room)bindingSourceRooms.Current;
                    Forms.EditRoomForm esf = new Forms.EditRoomForm(room, connection) { Owner = this };
                    esf.Text = room.Description.ToUpper().Trim();
                    esf.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            } 
        }
        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInActive.Checked)
                {
                    bindingSourceRooms.DataSource = null;
                    var _roomsquery = from rm in db.Rooms
                                      where rm.IsDeleted == false
                                      select rm;
                    bindingSourceRooms.DataSource = _roomsquery.ToList();
                    groupBox2.Text = bindingSourceRooms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewRooms.Rows)
                    {
                        dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewRooms.Rows.Count - 1;
                        bindingSourceRooms.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceRooms.DataSource = null;
                    var _roomsquery = from rm in db.Rooms
                                      where rm.IsDeleted == false
                                      where rm.Status == "A"
                                      select rm;
                    bindingSourceRooms.DataSource = _roomsquery.ToList();
                    groupBox2.Text = bindingSourceRooms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewRooms.Rows)
                    {
                        dataGridViewRooms.Rows[dataGridViewRooms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewRooms.Rows.Count - 1;
                        bindingSourceRooms.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewRooms_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }




    }
}