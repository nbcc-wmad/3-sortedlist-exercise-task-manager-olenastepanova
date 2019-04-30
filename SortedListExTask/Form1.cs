//AUTHOR: OLENA STEPANOVA
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> tasks = new Dictionary<string, string>();

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void AddTask()
        {
            if (string.IsNullOrEmpty(txtTask.Text))
            {
                MessageBox.Show("You must enter a task", "Invalid Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (tasks.ContainsKey(dtpTaskDate.Text))
                {
                    MessageBox.Show("Only one task per day is allowed", "Invalid Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else {
                    string date = dtpTaskDate.Text;
                    string taskName = txtTask.Text;

                    tasks.Add(date, taskName);
                    txtTask.Clear();

                    lstTasks.Items.Add(tasks.Keys.ElementAt(tasks.Count - 1));
                }
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintAll();
        }

        private void PrintAll()
        {
            if (tasks.Count != 0)
            {
                string msg = string.Empty;
                foreach (KeyValuePair<string, string> kvalue in tasks)
                {
                    msg += $"{kvalue.Key} {kvalue.Value} \n";
                }

                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("Enter your tasks first", "Invalid Data", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            RemoveTaskFromList();
        }

        private void RemoveTaskFromList()
        {
            if(lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task to remove", "Invalid Data", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else
            {
                tasks.Remove(lstTasks.SelectedItem.ToString());
                lstTasks.Items.Remove(lstTasks.SelectedItem);

            }
        }



        private void lstTasks_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex != -1)
            {
                string taskName = tasks[lstTasks.SelectedItem.ToString()];
                lblTaskDetails.Text = taskName;
                
            }
            else
            {
                lblTaskDetails.ResetText();
            }
        }
    }
}
