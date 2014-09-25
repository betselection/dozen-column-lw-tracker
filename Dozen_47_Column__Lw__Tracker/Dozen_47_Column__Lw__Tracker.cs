//  Dozen_47_Column__Lw__Tracker.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Dozen/Column Lw Tracker.
/// </summary>
namespace Dozen_47_Column__Lw__Tracker
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Dozen/Column Lw Tracker class.
    /// </summary>
    public class Dozen_47_Column__Lw__Tracker : Form
    {
        /// <summary>
        /// The tracker data grid view.
        /// </summary>
        private DataGridView trackerDataGridView;

        /// <summary>
        /// The roulette class instance.
        /// </summary>
        private Roulette roulette = new Roulette();

        /// <summary>
        /// The marshal object.
        /// </summary>
        private object marshal = null;

        /// <summary>
        /// The history list.
        /// </summary>
        private List<int> historyList = new List<int>();

        /// <summary>
        /// The previous dozens list.
        /// </summary>
        private List<int> prevDozensList = new List<int>();

        /// <summary>
        /// The previous columns list.
        /// </summary>
        private List<int> prevColumnsList = new List<int>();

        /// <summary>
        /// The current dozens list.
        /// </summary>
        private List<int> currentDozensList = new List<int>();

        /// <summary>
        /// The current columns list.
        /// </summary>
        private List<int> currentColumnsList = new List<int>();

        /// <summary>
        /// Hit on last two dozens list
        /// </summary>
        private List<string> lastTwoDozensList = new List<string>();

        /// <summary>
        /// Jump from last dozen list
        /// </summary>
        private List<string> jumpDozenList = new List<string>();

        /// <summary>
        /// Hit on last two columns list
        /// </summary>
        private List<string> lastTwoColumnsList = new List<string>();

        /// <summary>
        /// Jump from last column list
        /// </summary>
        private List<string> jumpColumnList = new List<string>();

        /// <summary>
        /// Hit on last two dozens advisor
        /// </summary>
        private string lastTwoDozensAdvisor = string.Empty;

        /// <summary>
        /// Hit on last two columns advisor
        /// </summary>
        private string lastTwoColumnsAdvisor = string.Empty;

        /// <summary>
        /// Jump from last dozen advisor
        /// </summary>
        private string jumpDozenAdvisor = string.Empty;

        /// <summary>
        /// Jump from last column advisor
        /// </summary>
        private string jumpColumnAdvisor = string.Empty;

        /// <summary>
        /// Bigger font for DataGrid rows
        /// </summary>
        private Font bigFont = new System.Drawing.Font(FontFamily.GenericMonospace, 15.75F, System.Drawing.FontStyle.Bold ^ FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (byte)0);

        /// <summary>
        /// Tracker as BindingList of TrackerData (bound to DataGridView)
        /// </summary>
        private BindingList<TrackerData> tracker = new BindingList<TrackerData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Dozen_47_Column__Lw__Tracker.Dozen_47_Column__Lw__Tracker"/> class.
        /// </summary>
        public Dozen_47_Column__Lw__Tracker()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            this.trackerDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)this.trackerDataGridView).BeginInit();
            this.SuspendLayout();

            // trackerDataGridView
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.trackerDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.trackerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackerDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.trackerDataGridView.Dock = DockStyle.Fill;
            this.trackerDataGridView.Location = new System.Drawing.Point(0, 0);
            this.trackerDataGridView.Name = "trackerDataGridView";
            this.trackerDataGridView.ReadOnly = true;
            this.trackerDataGridView.RowHeadersVisible = false;
            this.trackerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.trackerDataGridView.AutoSize = true;
            this.trackerDataGridView.Size = new System.Drawing.Size(564, 111);
            this.trackerDataGridView.TabIndex = 0;

            // DozenColumnLwTracker
            this.ClientSize = new System.Drawing.Size(564, 111);
            this.Controls.Add(this.trackerDataGridView);
            this.Name = "DozenColumnLwTracker";
            this.Text = "Dozen/Column Lw Tracker";
            this.Load += new System.EventHandler(this.FormTracker_Load);
            ((System.ComponentModel.ISupportInitialize)this.trackerDataGridView).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            // Alternating background
            this.trackerDataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            this.trackerDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Prevent automatic generation of columns
            this.trackerDataGridView.AutoGenerateColumns = false;

            // Prevent resize
            this.trackerDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.trackerDataGridView.AllowUserToResizeRows = false;

            // Add Name column
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Width = 60;
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nameColumn.DefaultCellStyle.Font = this.bigFont;
            this.trackerDataGridView.Columns.Add(nameColumn);

            // Add Advisor column
            DataGridViewTextBoxColumn advisorColumn = new DataGridViewTextBoxColumn();
            advisorColumn.Width = 60;
            advisorColumn.DataPropertyName = "Advisor";
            advisorColumn.HeaderText = "Advisor";
            advisorColumn.DefaultCellStyle.Font = this.bigFont;
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.trackerDataGridView.Columns.Add(advisorColumn);

            // Add Registry column
            DataGridViewTextBoxColumn registryColumn = new DataGridViewTextBoxColumn();
            registryColumn.DataPropertyName = "Registry";
            registryColumn.HeaderText = "Registry";
            registryColumn.DefaultCellStyle.Font = this.bigFont;
            registryColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.trackerDataGridView.Columns.Add(registryColumn);

            // Set trackerDataGridView's data source
            this.trackerDataGridView.DataSource = this.tracker;
        }

        /// <summary>
        /// Inits the instance.
        /// </summary>
        /// <param name="passedMarshal">Passed marshal.</param>
        public void Init(object passedMarshal)
        {
            // Set marshal
            this.marshal = passedMarshal;

            // Set icon
            this.Icon = (Icon)this.marshal.GetType().GetProperty("Icon").GetValue(this.marshal, null);

            // Show form
            this.Show();
        }

        /// <summary>
        /// Processes input.
        /// </summary>
        public void Input()
        {
            // Set last
            string last = (string)this.marshal.GetType().GetProperty("Last").GetValue(this.marshal, null);

            // Check for undo
            if (last == "-U")
                {
                    // remove number
                    this.RemoveNumber();
                }
            else
                {
                    // Add current one
                    this.AddNumber(Convert.ToInt32(last));
                }
        }

        /// <summary>
        /// Tracker form's entry point
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FormTracker_Load(object sender, EventArgs e)
        {
            // Populate tracker's base rows
            this.tracker.Add(new TrackerData("LD"));
            this.tracker.Add(new TrackerData("JD"));
            this.tracker.Add(new TrackerData("LC"));
            this.tracker.Add(new TrackerData("JC"));
        }

        /// <summary>
        /// Sets current and previous dozens and columns
        /// </summary>
        private void SetDC()
        {
            /*                        
             * Clear/Reset relevant variables
             */

            // Prev/Next
            this.prevDozensList.Clear();
            this.prevColumnsList.Clear();
            this.currentDozensList.Clear();
            this.currentColumnsList.Clear();

            // Advisors
            this.lastTwoDozensAdvisor = string.Empty;
            this.lastTwoColumnsAdvisor = string.Empty;
            this.jumpDozenAdvisor = string.Empty;
            this.jumpColumnAdvisor = string.Empty;

            // Check there's something to work with
            if (this.historyList.Count == 0)
                {
                    // Exit
                    return;
                }

            /*                        
             * Set previous D/C
             */

            // Start from previous spin
            for (int h = 1; h < this.historyList.Count; h++)
                {
                    // Set dozen for current iteration
                    int dozen = this.roulette.GetDozen(this.historyList[h]);

                    // If dozen is zero...
                    if (dozen == 0)
                        {
                            // ...jump to next iteration
                            continue;
                        }

                    // Set column for current iteration
                    int column = this.roulette.GetColumn(this.historyList[h]);

                    /* Process dozens */

                    // Add if there's room and it doesn't exist
                    if (this.prevDozensList.Count < 3 && !this.prevDozensList.Contains(dozen))
                        {
                            // Add current one
                            this.prevDozensList.Add(dozen);
                        }

                    /* Process columns */

                    // Add if there's room and it doesn't exist
                    if (this.prevColumnsList.Count < 3 && !this.prevColumnsList.Contains(column))
                        {
                            // Add current one
                            this.prevColumnsList.Add(column);
                        }

                    /* Check for halt */
                    if (this.prevDozensList.Count == 3 && this.prevColumnsList.Count == 3)
                        {
                            // Halt for loop
                            break;
                        }
                }

            /*                         
            * Set current D/C
            */

            // Start from current spin
            for (int h = 0; h < this.historyList.Count; h++)
                {
                    // Set dozen for current iteration
                    int dozen = this.roulette.GetDozen(this.historyList[h]);

                    // If dozen is zero...
                    if (dozen == 0)
                        {
                            // ...jump to next iteration
                            continue;
                        }

                    // Set column for current iteration
                    int column = this.roulette.GetColumn(this.historyList[h]);

                    /* Process dozens */

                    // Add if there's room and it doesn't exist
                    if (this.currentDozensList.Count < 3 && !this.currentDozensList.Contains(dozen))
                        {
                            // Add current one
                            this.currentDozensList.Add(dozen);
                        }

                    /* Process columns */

                    // Add if there's room and it doesn't exist
                    if (this.currentColumnsList.Count < 3 && !this.currentColumnsList.Contains(column))
                        {
                            // Add current one
                            this.currentColumnsList.Add(column);
                        }

                    /* Check for halt */
                    if (this.currentDozensList.Count == 3 && this.currentColumnsList.Count == 3)
                        {
                            // Halt for loop
                            break;
                        }
                }

            /*                        
             * Advisors
             */

            /* LD */

            // Check if there's something to work with
            if (this.currentDozensList.Count > 0)
                {
                    // Last one is mandatory!
                    this.lastTwoDozensAdvisor = this.currentDozensList[0].ToString();

                    // If there's a second one, must add it too
                    if (this.currentDozensList.Count > 1)
                        {
                            // Add second
                            this.lastTwoDozensAdvisor += "," + this.currentDozensList[1].ToString();
                        }
                }

            /* JD */

            // Check if there's something to work with
            if (this.currentDozensList.Count > 0)
                {
                    // Char array
                    char[] jumpDozen = "123".Replace(this.currentDozensList[0].ToString(), string.Empty).ToCharArray();

                    // The other two, excluding last one
                    this.jumpDozenAdvisor = jumpDozen[0] + "," + jumpDozen[1];
                }

            /* LC */

            // Check if there's something to work with
            if (this.currentColumnsList.Count > 0)
                {
                    // Last one is mandatory!
                    this.lastTwoColumnsAdvisor = this.currentColumnsList[0].ToString();

                    // If there's a second one, must add it too
                    if (this.currentColumnsList.Count > 1)
                        {
                            // Add second
                            this.lastTwoColumnsAdvisor += "," + this.currentColumnsList[1].ToString();
                        }
                }

            /* JC */

            // Check if there's something to work with
            if (this.currentColumnsList.Count > 0)
                {
                    // Char array
                    char[] jumpColumn = "123".Replace(this.currentColumnsList[0].ToString(), string.Empty).ToCharArray();

                    // The other two, excluding last one
                    this.jumpColumnAdvisor = jumpColumn[0] + "," + jumpColumn[1];
                }
        }

        /// <summary>
        /// Updates the tracker data grid view.
        /// </summary>
        private void UpdateTrackerDataGridView()
        {
            // LD
            this.tracker[0].Advisor = this.lastTwoDozensAdvisor;
            this.tracker[0].Registry = string.Join(string.Empty, this.lastTwoDozensList.GetRange(this.lastTwoDozensList.Count > 30 ? this.lastTwoDozensList.Count - 30 : 0, this.lastTwoDozensList.Count > 30 ? 30 : this.lastTwoDozensList.Count).ToArray());

            // JD
            this.tracker[1].Advisor = this.jumpDozenAdvisor;
            this.tracker[1].Registry = string.Join(string.Empty, this.jumpDozenList.GetRange(this.jumpDozenList.Count > 30 ? this.jumpDozenList.Count - 30 : 0, this.jumpDozenList.Count > 30 ? 30 : this.jumpDozenList.Count).ToArray());

            // LC
            this.tracker[2].Advisor = this.lastTwoColumnsAdvisor;
            this.tracker[2].Registry = string.Join(string.Empty, this.lastTwoColumnsList.GetRange(this.lastTwoColumnsList.Count > 30 ? this.lastTwoColumnsList.Count - 30 : 0, this.lastTwoColumnsList.Count > 30 ? 30 : this.lastTwoColumnsList.Count).ToArray());

            // JC
            this.tracker[3].Advisor = this.jumpColumnAdvisor;
            this.tracker[3].Registry = string.Join(string.Empty, this.jumpColumnList.GetRange(this.jumpColumnList.Count > 30 ? this.jumpColumnList.Count - 30 : 0, this.jumpColumnList.Count > 30 ? 30 : this.jumpColumnList.Count).ToArray());

            // Refresh
            this.trackerDataGridView.Refresh();
        }

        /// <summary>
        /// Processes adding a new item to the tracker
        /// </summary>
        /// <param name="n">Passed number</param>
        private void AddNumber(int n)
        {
            // Variable for holding last addition to registry
            string reg = string.Empty;

            // Insert number into history list
            this.historyList.Insert(0, n);

            // Set previous and current D/C variables
            this.SetDC();

            // Check for zero
            if (n == 0)
                {
                    // Add zero to all in the registry
                    this.lastTwoDozensList.Add("0");
                    this.jumpDozenList.Add("0");
                    this.lastTwoColumnsList.Add("0");
                    this.jumpColumnList.Add("0");

                    // Update
                    this.UpdateTrackerDataGridView();

                    // Exit 
                    return;
                }

            // Check there is at least 1 element in history
            if (this.historyList.Count == 0)
                {
                    // Less than two: halt.
                    return;
                }

            // Get last D/C
            int lastDozen = this.roulette.GetDozen(n);
            int lastColumn = this.roulette.GetColumn(n);

            /* Process LD */

            // If current one is present in either first or second of prevDozens list = win
            for (int i = 0; i < this.prevDozensList.Count; i++)
                {
                    // Test against current one
                    if (lastDozen == this.prevDozensList[i])
                        { 
                            // Win
                            reg = "w";

                            // Halt
                            break;
                        }

                    // Second iteration
                    if (i == 1)
                        {
                            // Lose
                            reg = "L";

                            // Exit loop
                            break;
                        }
                }

            // Add hyphen if there's nothing
            if (reg.Length == 0)
                {
                    // Add hyphen
                    reg = "-";
                }

            // Add reg to ld
            this.lastTwoDozensList.Add(reg);

            /* Process JD */

            // Reset reg
            reg = string.Empty;

            // If current one is different from last dozen in prevDozens = win

            // Check there are items to work with
            if (this.prevDozensList.Count > 0)
                {
                    // Check last dozen vs beforelast
                    if (lastDozen != this.prevDozensList[0])
                        {
                            // Win
                            reg = "w";
                        }
                    else
                        {
                            // Lose
                            reg = "L";
                        }
                }

            // Add hyphen if there's nothing to add
            if (reg.Length == 0)
                {
                    // Add hyphen
                    reg = "-";
                }

            // Add reg to jd
            this.jumpDozenList.Add(reg);

            /* Process LC */

            // If current one is present in either first or second of prevColumns list = win

            // Reset reg
            reg = string.Empty;

            for (int i = 0; i < this.prevColumnsList.Count; i++)
                {
                    // Test against current one
                    if (lastColumn == this.prevColumnsList[i])
                        {
                            // Win
                            reg = "w";

                            // Halt
                            break;
                        }

                    // Second iteration
                    if (i == 1)
                        {
                            // Lose
                            reg = "L";

                            // Exit loop
                            break;
                        }
                }

            // Add hyphen if there's nothing
            if (reg.Length == 0)
                {
                    // Add hyphen
                    reg = "-";
                }

            // Add reg to lc
            this.lastTwoColumnsList.Add(reg);

            /* Process JC */

            // Reset reg
            reg = string.Empty;

            // If current one is different from last Column in prevColumns = win

            // Check for items to work with
            if (this.prevColumnsList.Count > 0)
                {
                    // Check last Column vs beforelast
                    if (lastColumn != this.prevColumnsList[0])
                        {
                            // Win
                            reg = "w";
                        }
                    else
                        {
                            // Lose
                            reg = "L";
                        }
                }

            // Add hyphen if there's nothing to add
            if (reg.Length == 0)
                {
                    // Add hyphen
                    reg = "-";
                }

            // Add reg to jc
            this.jumpColumnList.Add(reg);

            // Update DataGridView
            this.UpdateTrackerDataGridView();
        }

        /// <summary>
        /// Remove number from tracker
        /// </summary>
        private void RemoveNumber()
        {
            // Check there's something to work with
            if (this.historyList.Count == 0)
                {
                    // Exit
                    return;
                }

            // Remove last number from history
            this.historyList.RemoveAt(0);

            // Check there's something to remove
            if (this.lastTwoDozensList.Count > 0)
                {
                    // Remove last from Lw trackers
                    this.lastTwoDozensList.RemoveAt(this.lastTwoDozensList.Count - 1);
                    this.jumpDozenList.RemoveAt(this.jumpDozenList.Count - 1);
                    this.lastTwoColumnsList.RemoveAt(this.lastTwoColumnsList.Count - 1);
                    this.jumpColumnList.RemoveAt(this.jumpColumnList.Count - 1);
                }

            // SetD/C
            this.SetDC();

            // Update datagridview
            this.UpdateTrackerDataGridView();
        }

        /// <summary>
        /// Clears advisors and registry on trackerDataGridView
        /// </summary>
        private void ClearDgv()
        {
            // LD
            this.tracker[0].Advisor = string.Empty;
            this.tracker[0].Registry = string.Empty;

            // JD
            this.tracker[1].Advisor = string.Empty;
            this.tracker[1].Registry = string.Empty;

            // LC
            this.tracker[2].Advisor = string.Empty;
            this.tracker[2].Registry = string.Empty;

            // JC
            this.tracker[3].Advisor = string.Empty;
            this.tracker[3].Registry = string.Empty;
        }
    }
}