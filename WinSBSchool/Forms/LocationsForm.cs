using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;
using System.Diagnostics;

namespace WinSBSchool.Forms
{
    public partial class LocationsForm : Form
    {
        #region "Private Fields"
        string connection;
        public string _SSKEY;
        List<LocationProperty> _locationproperties;
        List<Location> _locations;
        SBSchoolDBEntities db;
        Repository rep;
        bool busy = false;
        #endregion "Private Fields"

        #region "Constructor"
        public LocationsForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void LocationsForm_Load(object sender, EventArgs e)
        {
            try
            {  
                dataGridViewLocationProperties.AutoGenerateColumns = false;
                this.dataGridViewLocationProperties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewLocationProperties.DataSource = bindingSourceLocationProperties;

                var _locationsquery = db.Locations.Include("LocationProperties");
                _locations = _locationsquery.ToList();
                bindingSourceLocations.DataSource = _locations;

                treeViewLocations.CheckBoxes = true;
                treeViewLocations.FullRowSelect = true;
                treeViewLocations.HideSelection = false;
                treeViewLocations.HotTracking = true;
                treeViewLocations.ShowLines = true;
                treeViewLocations.ShowNodeToolTips = true;
                treeViewLocations.ShowPlusMinus = true;
                treeViewLocations.ShowRootLines = true; 

                BuildTree();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            {
                 
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
        public void BuildTree()
        {
            try
            {
                treeViewLocations.Nodes.Clear(); // Clear any existing items
                treeViewLocations.BeginUpdate(); // prevent overhead and flicker
                // load all the lowest tree nodes

                TreeNode root = new TreeNode();
                DAL.Location _economicActivity = new DAL.Location() { Id = 0, Description = "Locations", LocationProperties = new System.Data.Objects.DataClasses.EntityCollection<LocationProperty>(), Parent = 0, BoardingCost = 0, TransportCost = 0, IsDeleted = false };
                LocationNode i = new LocationNode("0",
                                          "RootLocation",
                                          _economicActivity);
                root.Text = i.Key + "-" + "Locations";
                root.Tag = i;
                PopulateTreeViewLocations(root);
                treeViewLocations.Nodes.Add(root);

                treeViewLocations.EndUpdate(); // re-enable the tree
                treeViewLocations.Refresh(); // refresh the treeview display
                treeViewLocations.ExpandAll(); // expand all nodes
                if (treeViewLocations.Nodes.Count > 0)
                {
                    // Select the root node
                    treeViewLocations.SelectedNode = treeViewLocations.Nodes[0];
                }
                int count = treeViewLocations.GetNodeCount(true);
                groupBox2.Text = "Locations  " + count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewLocations(TreeNode node)
        {
            try
            {
                var _locationsQuery = from lc in db.Locations
                                      where lc.Parent == 0
                                      select lc;
                List<Location> _locations = _locationsQuery.ToList();

                foreach (var _location in _locations)
                {

                    LocationNode i = new LocationNode(_location.Id.ToString(),
                                              "LocationModel",
                                              _location);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _location.Description;
                    node.Nodes.Add(clnode);

                    PopulateTreeViewLocationsChildren(clnode, _location);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeViewLocationsChildren(TreeNode node, Location location)
        {
            try
            {
                var _locationsQuery = from lc in db.Locations
                                      where lc.Parent == location.Id
                                      select lc;
                List<Location> _locations = _locationsQuery.ToList();

                foreach (var _location in _locations)
                {
                    LocationNode i = new LocationNode(_location.Id.ToString(),
                                              "LocationModel",
                                              _location);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = i.Key + "-" + _location.Description;
                    node.Nodes.Add(clnode);

                    PopulateTreeViewLocationsChildren(clnode, _location);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Save Successfull", "SB School");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewLocations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // Get the node that was Selected
                TreeNode selectedNode = e.Node;
                _locationproperties = new List<LocationProperty>();
                bindingSourceLocationProperties.DataSource = null;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {

                        case "RootLocation":
                            addLocationToolStripMenuItem.Enabled = true;
                            editLocationToolStripMenuItem.Enabled = false;
                            viewDetailsToolStripMenuItem.Enabled = false;
                            deleteLocationToolStripMenuItem.Enabled = false;
                            break;
                        default:
                            addLocationToolStripMenuItem.Enabled = true;
                            editLocationToolStripMenuItem.Enabled = true;
                            viewDetailsToolStripMenuItem.Enabled = true;
                            deleteLocationToolStripMenuItem.Enabled = true;
                            break; 
                    }
                    switch (enode.Table)
                    {
                        case "RootLocation":
                            break;
                        default:
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            string _text = selectedNode.Text.ToString().Split('-')[1];
                            var _locationquery = (from loc in db.Locations
                                                  where loc.Id == itemId
                                                  where loc.Description == _text
                                                  select loc).FirstOrDefault();
                            Location location = _locationquery; 
                            
                            if (location != null)
                            {
                                bindingSourceLocationProperties.DataSource = location.LocationProperties; 
                                foreach (DataGridViewRow row in dataGridViewLocationProperties.Rows)
                                {
                                    dataGridViewLocationProperties.Rows[dataGridViewLocationProperties.Rows.Count - 1].Selected = true;
                                    int nRowIndex = dataGridViewLocationProperties.Rows.Count - 1;
                                    bindingSourceLocationProperties.Position = nRowIndex;
                                } 
                            } 
                            break;
                    }
                }
                groupBox3.Text = "Location Properties  " + bindingSourceLocationProperties.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void addLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewLocations.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation":
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            AddLocationForm f = new AddLocationForm(itemId, connection) { Owner = this };
                            f.ShowDialog();
                            break;
                        default:
                            int aitemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            AddLocationForm af = new AddLocationForm(aitemId, connection) { Owner = this };
                            af.ShowDialog();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void editLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewLocations.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation": 
                            MessageBox.Show("Cannot Edit Root Node", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            int eitemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            string _etext = selectedNode.Text.ToString().Split('-')[1];
                            var _eLocationquery = (from loc in db.Locations
                                                   where loc.Id == eitemId
                                                   where loc.Description == _etext
                                                   select loc).FirstOrDefault();
                            DAL.Location _eLocation = _eLocationquery;
                            EditLocationForm ef = new EditLocationForm(  _eLocation, connection) { Owner = this };
                            ef.Text = _eLocation.Description.Trim().ToUpper();
                            ef.ShowDialog();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewLocations.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation": 
                            break;
                        default:
                            int eitemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            string _etext = selectedNode.Text.ToString().Split('-')[1];
                            var _eLocationquery = (from loc in db.Locations
                                                   where loc.Id == eitemId
                                                   where loc.Description == _etext
                                                   select loc).FirstOrDefault();
                            DAL.Location _eLocation = _eLocationquery;
                            EditLocationForm ef = new EditLocationForm(  _eLocation, connection) { Owner = this };
                            ef.Text = _eLocation.Description.Trim().ToUpper();
                            ef.DisableControls();
                            ef.ShowDialog();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void deleteLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode selectedNode = treeViewLocations.SelectedNode;
                if (selectedNode != null)
                {
                    LocationNode enode = (LocationNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "RootLocation": 
                            MessageBox.Show("Cannot Delete Root Node", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            int itemId = int.Parse(selectedNode.Text.ToString().Split('-')[0]);
                            string _text = selectedNode.Text.ToString().Split('-')[1];

                            var _Locationquery = (from loc in db.Locations
                                                  where loc.Id == itemId
                                                  where loc.Description == _text
                                                  select loc).FirstOrDefault();
                            DAL.Location _Location = _Locationquery;

                            var _LocationChildrenquery = from loc in db.Locations
                                                         where loc.Parent == _Location.Id
                                                         select loc;
                            List<Location> _LocationChildren = _LocationChildrenquery.ToList();

                            var _locationpropsQuery = from lc in db.LocationProperties
                                                      where lc.LocationId == _Location.Id
                                                      select lc;
                            List<LocationProperty> _locationprops = _locationpropsQuery.ToList();

                            if (_Location.Description.Trim().Equals("Locations"))
                            {
                                MessageBox.Show("Cannot Delete Root Node!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (_locationprops.Count > 0)
                            {
                                MessageBox.Show("There is a Location Property Associated with this Location.\n Delete the Location Property First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (_LocationChildren.Count > 0)
                            {
                                MessageBox.Show("There is a Location Associated with this Location as its Parent.\n Delete the Child Location First!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } 
                            else
                            {
                                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Location \n" + _Location.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                                {
                                    //var _LocationPropertiesquery = from locprop in db.LocationProperties
                                    //                               where locprop.LocationId == _Location.Id
                                    //                               select locprop;
                                    //List<LocationProperty> _LocationProperties = _LocationPropertiesquery.ToList();

                                    //foreach (var locprop in _LocationProperties)
                                    //{
                                    //    db.LocationProperties.DeleteObject(locprop);
                                    //    db.SaveChanges();
                                    //}

                                    db.Locations.DeleteObject(_Location);
                                    db.SaveChanges();

                                    BuildTree();
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLocationProperties_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLocationProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridViewLocationProperties_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCell cell = (DataGridViewCell)dataGridViewLocationProperties.Rows[e.RowIndex].Cells[e.ColumnIndex];

                DataGridViewRow row = dataGridViewLocationProperties.Rows[e.RowIndex];

                if (!row.IsNewRow && cell.ColumnIndex == this.dataGridViewLocationProperties.Columns["ColumnLocKey"].Index)
                {
                    cell.ReadOnly = true;
                }
                if (!row.IsNewRow && cell.ColumnIndex == this.dataGridViewLocationProperties.Columns["ColumnLocDescription"].Index)
                {
                    cell.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewLocations_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
            finally
            {
                busy = false;
            }
        }
        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
        }
        private void btnExpandAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewLocations.ExpandAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCollapseAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewLocations.CollapseAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void bindingSourceLocationProperties_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                // Cast your strongly-typed bindingsource List to a DataView and add a new DataRowView 
                //DataRowView rowView = ((DataView)bindingSourceLocationProperties.List).AddNew();

                ////// Get data table view 
                ////DataView dataTableView = bindingSourceLocationProperties.List as DataView; 
                //////// Create row from view
                ////DataRowView rowView = dataTableView.AddNew();  
                //rowView["LocValueType"] = "Location";
                //rowView["IsDeleted"] = false; 
                ////// Set New row
                //e.NewObject = rowView;
                ////bindingSourceLocationProperties.MoveLast(); 

                //RaiseBindingSourceEvents();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RaiseBindingSourceEvents()
        {
            try
            {
                bindingSourceLocationProperties.AddingNew += (s, ev) => NotifyMessage("bindingSourceLocationProperties","AddingNew");
                bindingSourceLocationProperties.BindingComplete += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "BindingComplete");
                bindingSourceLocationProperties.CurrentChanged += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "CurrentChanged");
                bindingSourceLocationProperties.CurrentItemChanged += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "CurrentItemChanged");
                bindingSourceLocationProperties.DataError += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "DataError");
                bindingSourceLocationProperties.DataMemberChanged += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "DataMemberChanged");
                bindingSourceLocationProperties.DataSourceChanged += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "DataSourceChanged");
                bindingSourceLocationProperties.ListChanged += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "ListChanged");
                bindingSourceLocationProperties.PositionChanged += (s, ev) => NotifyMessage("bindingSourceLocationProperties", "PositionChanged");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool NotifyMessage(string _Title, string _Text)
        {
            try
            {
                appNotifyIcon.Text = Utils.APP_NAME;
                appNotifyIcon.Icon = new Icon("Resources/Icons/SchoolStudents.ico");
                appNotifyIcon.BalloonTipIcon = ToolTipIcon.Info; 
                appNotifyIcon.BalloonTipTitle = _Title;
                appNotifyIcon.BalloonTipText = _Text;
                appNotifyIcon.Visible = true;
                appNotifyIcon.ShowBalloonTip(900000);

                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        #endregion "Private Methods"







    }
}