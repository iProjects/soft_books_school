using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class RegisterSingleExamForm : Form
    {
        int _ExamId;
        string connection;
        SBSchoolDBEntities db;
        Repository rep;
        string _User;
        string _function;
        RegisteredExam _regexam;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public RegisterSingleExamForm(string function, int _examId, string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_examId == null)
                throw new ArgumentNullException("ExamId");
            _ExamId = _examId;

            if (string.IsNullOrEmpty(_user))
                throw new ArgumentNullException("user");
            _User = _user;

            _function = function;
        }
        public RegisterSingleExamForm(string function, RegisteredExam regexam, string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (regexam == null)
                throw new ArgumentNullException("RegisteredExam");
            _regexam = regexam;

            if (string.IsNullOrEmpty(_user))
                throw new ArgumentNullException("user");
            _User = _user;

            _function = function;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsRegisteredExamValid())
            {
                try
                {
                    switch (_function)
                    {
                        case "Add":
                            int _examTypeId = ((ExamType)bindingSourceExamType.Current).Id;

                            if (db.RegisteredExams.Any(o => o.ExamId == _ExamId && o.ExamTypeId == _examTypeId && o.IsDeleted == false))
                            {
                                //Match!
                                MessageBox.Show("Exam Already Registered", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!db.RegisteredExams.Any(o => o.ExamId == _ExamId && o.ExamTypeId == _examTypeId && o.IsDeleted == false))
                            {
                                //No Match!
                                RegisteredExam r = new RegisteredExam();
                                r.ExamId = _ExamId;
                                r.ExamTypeId = _examTypeId;
                                if (cboRooms.SelectedIndex != -1)
                                {
                                    r.RoomId = int.Parse(cboRooms.SelectedValue.ToString());
                                }
                                r.ExamDate = dtpExamDate.Value;
                                if (!string.IsNullOrEmpty(cboinvigilator.Text))
                                {
                                    r.Invilgilator = cboinvigilator.Text;
                                }
                                if (cboStatus.SelectedIndex != -1)
                                {
                                    r.Status = cboStatus.SelectedValue.ToString();
                                }
                                r.ContributionFlag = chkContribution.Checked;
                                double _contrib;
                                if (chkContribution.Checked && !string.IsNullOrEmpty(txtContr.Text) && double.TryParse(txtContr.Text, out _contrib))
                                {
                                    r.Contribution = _contrib;
                                }
                                if (!chkContribution.Checked)
                                {
                                    r.Contribution = 1;
                                }
                                int _outof;
                                if (!string.IsNullOrEmpty(txtOutOf.Text) && int.TryParse(txtOutOf.Text, out _outof))
                                {
                                    r.OutOf = _outof;
                                }
                                if (!string.IsNullOrEmpty(txtModifiedBy.Text))
                                {
                                    r.ModifiedBy = txtModifiedBy.Text.Trim();
                                }
                                r.LastModified = DateTime.Now;
                                r.IsDeleted = false;

                                db.RegisteredExams.AddObject(r);
                                db.SaveChanges();

                                MessageBox.Show("Registered", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ExamsForm _f = (ExamsForm)this.Owner;
                                _f.RefreshRegisteredExamsGrid();
                                this.Close();
                            }
                            break;
                        case "Edit":
                            if (cboRooms.SelectedIndex != -1)
                            {
                                _regexam.RoomId = int.Parse(cboRooms.SelectedValue.ToString());
                            }
                            _regexam.ExamDate = dtpExamDate.Value;
                            if (!string.IsNullOrEmpty(cboinvigilator.Text))
                            {
                                _regexam.Invilgilator = cboinvigilator.Text;
                            }
                            if (cboStatus.SelectedIndex != -1)
                            {
                                _regexam.Status = cboStatus.SelectedValue.ToString();
                            }
                            _regexam.ContributionFlag = chkContribution.Checked;
                            double contrib;
                            if (chkContribution.Checked && !string.IsNullOrEmpty(txtContr.Text) && double.TryParse(txtContr.Text, out contrib))
                            {
                                _regexam.Contribution = contrib;
                            }
                            if (!chkContribution.Checked)
                            {
                                _regexam.Contribution = 1;
                            }
                            int outof;
                            if (!string.IsNullOrEmpty(txtOutOf.Text) && int.TryParse(txtOutOf.Text, out outof))
                            {
                                _regexam.OutOf = outof;
                            }
                            if (!string.IsNullOrEmpty(txtModifiedBy.Text))
                            {
                                _regexam.ModifiedBy = txtModifiedBy.Text.Trim();
                            }
                            _regexam.LastModified = DateTime.Now;

                            rep.UpdateRegisteredExam(_regexam);

                            ExamsForm f = (ExamsForm)this.Owner;
                            f.RefreshRegisteredExamsGrid();
                            this.Close();

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsRegisteredExamValid()
        {
            bool noerror = true;
            if (cbExamType.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbExamType, "Select Exam Type!");
                return false;
            }
            if (chkContribution.Checked && string.IsNullOrEmpty(txtContr.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtContr, "Contribution Percentage cannot be null!");
                return false;
            }
            double contribution;
            if (chkContribution.Checked && !string.IsNullOrEmpty(txtContr.Text) && !double.TryParse(txtContr.Text, out contribution))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtContr, "Contribution Must be double!");
                return false;
            }
            int outof;
            if (!string.IsNullOrEmpty(txtOutOf.Text) && !int.TryParse(txtOutOf.Text, out outof))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOutOf, "Out of Must be integer!");
                return false;
            }
            return noerror;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidExamDets()
        {
            bool valid = false;
            if (!chkContribution.Checked)
            {
                valid = true;
            }
            else
            {
                //TotalAssets should add up to 100
                var total = 0.00;
                var contrib = 0.00;
                var totalq = db.RegisteredExams.Where(ex => ex.ExamId == _ExamId && ex.ContributionFlag == true && ex.Status == "A").Select(ex => ex.Contribution);

                if (double.TryParse(txtContr.Text, out contrib))
                {
                }
                if (totalq.Count() > 0)
                {
                    total = contrib + totalq.Sum() ?? 0.00;
                }
                if (totalq.Count() == 0)
                {
                    total = contrib;
                }
                if (total == 1.00)
                {
                    valid = true;
                }
                if (total < 1.00)
                {
                    valid = true;
                }
                if (total > 1.00)
                {
                    valid = false;
                }
            }
            return valid;
        }
        private void groupBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidExamDets())
            {
                MessageBox.Show("Not adding up to 1", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
        private void RegisterSingleExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                switch (_function)
                {
                    case "Add":
                        var _existingexamtypesquery = from re in db.RegisteredExams
                                                      join et in db.ExamTypes on re.ExamTypeId equals et.Id
                                                      where re.IsDeleted == false
                                                      where re.ExamId == _ExamId
                                                      select re.ExamTypeId;
                        List<int> _existingexamTypes = _existingexamtypesquery.ToList();

                        var _newexamtypesquery = from et in db.ExamTypes
                                                 where et.IsDeleted == false
                                                 where et.Status == "A"
                                                 where !_existingexamTypes.Contains(et.Id)
                                                 orderby et.ShortCode
                                                 select et;
                        List<ExamType> _newexamTypes = _newexamtypesquery.ToList();

                        bindingSourceExamType.DataSource = _newexamTypes;
                        cbExamType.DataSource = bindingSourceExamType;
                        cbExamType.ValueMember = "Id";
                        cbExamType.DisplayMember = "Description";
                        break;
                    case "Edit":
                        var _examtypesquery = from et in db.ExamTypes
                                              where et.IsDeleted == false
                                              where et.Status == "A"
                                              orderby et.ShortCode
                                              select et;
                        List<ExamType> _examTypes = _examtypesquery.ToList();

                        bindingSourceExamType.DataSource = _examTypes;
                        cbExamType.DataSource = bindingSourceExamType;
                        cbExamType.ValueMember = "Id";
                        cbExamType.DisplayMember = "Description";
                        break;
                }

                txtModifiedBy.Text = _User;
                txtModifiedBy.Enabled = false;

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                var roomsquery = from rm in db.Rooms
                                 where rm.Status == "A"
                                 where rm.IsDeleted == false
                                 orderby rm.Description
                                 select rm;

                List<Room> _Rooms = roomsquery.ToList();
                cboRooms.DataSource = _Rooms;
                cboRooms.ValueMember = "Id";
                cboRooms.DisplayMember = "Description";

                groupBoxContribution.Visible = false;

                var _teachers_query = from tc in db.Teachers
                                      where tc.IsDeleted == false
                                      where tc.Status.Equals("A")
                                      where tc.IsLeft.Equals(false)
                                      select tc;

                List<Teacher> _teachers = _teachers_query.ToList();
                cboinvigilator.DataSource = _teachers;
                cboinvigilator.ValueMember = "Id";
                cboinvigilator.DisplayMember = "Name";

                if (_regexam != null)
                {
                    InitializeControls();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkContribution_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContribution.Checked)
            {
                groupBoxContribution.Visible = true;
            }
            else
            {
                groupBoxContribution.Visible = false;
            }
        }
        private void txtContr_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
            //If period key was pressed, accept.
            if (e.KeyCode == Keys.OemPeriod)
            {
                nonNumberEntered = false;
            }
        }
        private void txtContr_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtOutOf_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
            //If period key was pressed, accept.
            if (e.KeyCode == Keys.OemPeriod)
            {
                nonNumberEntered = false;
            }
        }
        private void txtOutOf_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        public void DisableControls()
        {
            try
            {
                cbExamType.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void InitializeControls()
        {
            try
            {
                if (_regexam.ExamTypeId != null)
                {
                    cbExamType.SelectedValue = _regexam.ExamTypeId;
                }
                if (_regexam.RoomId != null)
                {
                    cboRooms.SelectedValue = _regexam.RoomId;
                }
                if (_regexam.ExamDate != null)
                {
                    dtpExamDate.Value = _regexam.ExamDate ?? DateTime.Now;
                }
                if (_regexam.Invilgilator != null)
                {
                    cboinvigilator.Text = _regexam.Invilgilator.Trim();
                }
                if (_regexam.Status != null)
                {
                    cboStatus.SelectedValue = _regexam.Status.Trim();
                }
                if (_regexam.ContributionFlag != null)
                {
                    chkContribution.Checked = _regexam.ContributionFlag;
                }
                if (_regexam.Contribution != null)
                {
                    txtContr.Text = _regexam.Contribution.ToString();
                }
                if (_regexam.ExamTypeId != null)
                {
                    cbExamType.SelectedValue = _regexam.ExamTypeId;
                }
                if (_regexam.OutOf != null)
                {
                    txtOutOf.Text = _regexam.OutOf.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ExamType _examtype = (ExamType)cbExamType.SelectedItem;
                if (_examtype != null)
                {
                    if (_examtype.PercentageContribution != null)
                    {
                        txtOutOf.Text = _examtype.PercentageContribution.ToString();
                    }
                    else
                    {
                        txtOutOf.Text = "100";
                    }
                }
                else
                {
                    txtOutOf.Text = "100";
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }





    }
}