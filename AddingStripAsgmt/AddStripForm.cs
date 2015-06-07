using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

namespace AddingStripAsgmt
{
    /// <summary>
    /// A class for the main form 
    /// 
    /// Author: Victor Feng
    /// Email: VictorF@foxmail.com
    /// Created Date: 13/5/2015
    /// </summary>
    public partial class AddStripForm : Form
    {
        private Calculation cal;
        private bool addingStripSaved;

        public AddStripForm()
        {
            InitializeComponent();

            cal = new Calculation(lstDisplay);
            addingStripSaved = false;
        }

        /// <summary>
        /// When the [Update] button is clicked, check that the text in the bottom textbox does not break the rules for a calculation line.
        /// And the text in the bottom textbox will replace the currently selected line in the listbox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double otxtValue = 0;
            int txtChangeValueLength = txtChangeValue.Text.Length;
            if (txtChangeValueLength > 1 && !double.TryParse(txtChangeValue.Text.Substring(1, txtChangeValueLength - 1), out otxtValue))
            {
                MessageBox.Show("Please enter a number after the begining operator.");
            }
            else if (lstDisplay.Items.Count > 0 && txtChangeValueLength > 1)
            {
                char firstCharacter = txtChangeValue.Text[0];
                if (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/')//check if the txtValue starts with + and -.
                {
                    if (lstDisplay.SelectedIndex != -1)
                    {
                        int index = lstDisplay.SelectedIndex;
                        CalcLine cl = new CalcLine(txtChangeValue.Text);
                        cal.Replace(cl, index);

                        txtChangeValue.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("First data entry must use either '+' or '-' as the begining operator.");
                }
            }
            else
            {
                MessageBox.Show("Invalid update!");
            }
        }

        /// <summary>
        /// If the user clicks [Delete], the program will ask if the user wants to delete the selected line 
        ///   and if the user responds Yes then the selected line will be removed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstDisplay.Items.Count > 0 && lstDisplay.SelectedIndex != -1 && lstDisplay.SelectedItem.ToString().IndexOf("<") == -1)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Warning",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int index = lstDisplay.SelectedIndex;

                    cal.Delete(index);

                    txtChangeValue.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Invalid delete!");
            }
        }

        /// <summary>
        /// If the user clicks [Insert] the program will insert a new line in the calculation immediately before the selected line. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            double otxtValue = 0;
            int txtChangeValueLength = txtChangeValue.Text.Length;

            if (txtChangeValueLength > 1 && !double.TryParse(txtChangeValue.Text.Substring(1, txtChangeValueLength - 1), out otxtValue))
            {
                MessageBox.Show("Please enter a number after the begining operator.");
            }
            else if (lstDisplay.Items.Count > 0 && txtChangeValueLength > 1)
            {
                char firstCharacter = txtChangeValue.Text[0];
                if (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/')//check if the txtValue starts with + and -.
                {
                    int index = lstDisplay.SelectedIndex;
                    CalcLine cl = new CalcLine(txtChangeValue.Text);
                    cal.Insert(cl, index);
                    txtChangeValue.Text = "";
                }
                else
                {
                    MessageBox.Show("First data entry must use either '+' or '-' as the begining operator.");
                }
            }
            else
            {
                MessageBox.Show("Invalid insert!");
            }
        }

        /// <summary>
        /// Starts a new calculation and displays a blank listbox and blank text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (!cal.saved)
            {
                if (MessageBox.Show("You have not save your changed data. Confirm?", "New Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cal.saved = true;

                    clearFormValue();                    
                }
            }
            else
            {
                clearFormValue();
            }
        }

        /// <summary>
        /// Displays an OpenDialogBox and lets the user pick a previously created .cal file. 
        /// The data in the file is read and used to create a new Calculation object and display its calculation lines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (!cal.saved)
            {
                if (MessageBox.Show("You have not save your changed data. Confirm?", "Open File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (openOptDlg.ShowDialog() == DialogResult.OK)
                    {
                        txtValue.Text = "";
                        txtChangeValue.Text = "";

                        cal.LoadFromFile(openOptDlg.FileName);
                    }
                }
            }
            else
            {
                if (openOptDlg.ShowDialog() == DialogResult.OK)
                {
                    txtValue.Text = "";
                    txtChangeValue.Text = "";

                    cal.LoadFromFile(openOptDlg.FileName);
                }
            }

            saveOptDlg.FileName = openOptDlg.FileName;
        }

        /// <summary>
        /// If the “Adding strip” data has not been saved before, Save runs the Save As option. 
        /// If the “Adding strip” data is for an existing “Adding strip” data file, 
        ///    the data in the Calculation object is saved back to that file without displaying a SaveDialogBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (!addingStripSaved)
            {
                if (saveOptDlg.ShowDialog() == DialogResult.OK)
                {
                    cal.SaveToFile(saveOptDlg.FileName);
                    addingStripSaved = true;
                }
            }
            else
            {
                cal.SaveToFile(saveOptDlg.FileName);
            }
        }

        /// <summary>
        /// Displays a SaveDialogBox with either the name of the opened file or if it is a new file being saved, 
        ///   gives a default name “Calculation1.cal”. 
        /// The data in the Calculation object is saved as a text file using the filename the user chooses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (saveOptDlg.ShowDialog() == DialogResult.OK)
            {
                cal.SaveToFile(saveOptDlg.FileName);
                addingStripSaved = true;
            }
        }

        /// <summary>
        /// Prints the lines of the calculation object using a print preview form to display the printout first 
        ///   and then print if the user chooses to do so.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            PreviewDlg.Document = prDoc;
            PreviewDlg.ShowDialog();
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// If the terminating character is the Enter key, add a new CalcLine object for a total to the calculation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int txtValueLength = txtValue.Text.Length;
                if (cal.obtainTheCalsSize() == 0 && (txtValue.Text.IndexOf('#') != -1 || txtValue.Text.IndexOf('=') != -1))
                {
                    MessageBox.Show("No Caculation available. \n So no subtotal or total can be displayed.");
                    return;
                }
                else  if (txtValueLength == 0 && cal.obtainTheCalsSize() == 0)
                {
                    MessageBox.Show("No Caculation available. Enter key is not allowed.");
                    return;
                }
                else if (txtValueLength > 0 && (txtValue.Text[0] != '+' && txtValue.Text[0] != '-') && cal.obtainTheCalsSize() == 0)
                {
                    MessageBox.Show("First data entry must use either '+' or '-' as the begining operator.");
                    return;
                }
                else
                {
                    char firstCharacter = txtValue.Text[0];
                    if (txtValueLength > 1 && (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/'))
                    {
                        double otxtValue = 0;
                        if (double.TryParse(txtValue.Text.Substring(1), out otxtValue))
                        {
                            CalcLine cl = new CalcLine(txtValue.Text);
                            cal.Add(cl);

                            cl = new CalcLine("=");
                            cl.total = cal.obtainTotal();
                            cal.Add(cl);

                            txtValue.Text = "";
                            this.ActiveControl = null;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a number after the begining operator.");
                        }
                        
                    }
                    else if (txtValueLength == 1 && txtValue.Text.Equals("="))
                    {
                        CalcLine cl = new CalcLine("=");
                        cl.total = cal.obtainTotal();
                        cal.Add(cl);
                        this.ActiveControl = null;
                    }
                    else if (txtValueLength == 1 && txtValue.Text.Equals("#"))
                    {
                        CalcLine cl = new CalcLine("#");
                        cl.total = cal.obtainTotal();
                        cal.Add(cl);
                        this.ActiveControl = null;
                    }
                }
            }
        }

        /// <summary>
        /// Validate the entered data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            int txtValueLenght = txtValue.Text.Length;

            if (txtValueLenght > 0)
            {
                char firstCharacter = txtValue.Text[0];
                if (cal.obtainTheCalsSize() == 0 && (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '#' || firstCharacter == '='))
                {
                    if (txtValueLenght > 1)
                    {
                        char lastCharacter = txtValue.Text[txtValueLenght - 1];

                        addNewRowToArrayList(lastCharacter);
                    }
                }
                else if (cal.obtainTheCalsSize() > 0 && (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/'))//check if the txtValue starts with + and -.
                {
                    if (txtValueLenght > 1)
                    {
                        char lastCharacter = txtValue.Text[txtValueLenght - 1];

                        addNewRowToArrayList(lastCharacter);
                    }
                }
                else if (cal.obtainTheCalsSize() > 0)
                {
                    MessageBox.Show("Incorrect data format.");
                }
                else
                {
                    MessageBox.Show("First data entry must use either '+' or '-' as the begining operator.");
                }
            }
        }

        /// <summary>
        /// If the listbox is clicked, the text from the clicked line will show in the bottom textbox unless the line is for a subtotal or a total, 
        ///   in which case # or = will show in the bottom textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstDisplay_Click(object sender, EventArgs e)
        {
            if (cal.obtainTheCalsSize() > 0 && lstDisplay.SelectedItem != null)
            {
                string displayedText = lstDisplay.SelectedItem.ToString();
                if (displayedText.IndexOf('<') == -1)
                {
                    txtChangeValue.Text = displayedText;
                }
                else
                {
                    txtChangeValue.Text = "";
                }
            }
        }

        /// <summary>
        /// The program will detect if the user has made changes after a file is opened, a new file is created or a file is saved. 
        /// If there are changes, the user will be given a chance to save their changes before any action takes place that would lose the changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStripForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cal.saved)
            {
                if (MessageBox.Show("You have not save your changed data. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void prDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            cal.printPage(e);
        }
        
        private void addNewRowToArrayList(char lastCharacter)
        {
            int txtValueLenght = txtValue.Text.Length;
            double otxtValue = 0;

            if (txtValueLenght > 1 && !double.TryParse(txtValue.Text.Substring(1, txtValueLenght - 2 > 1 ? txtValueLenght - 2 : 1), out otxtValue))
            {
                MessageBox.Show("Please enter a number after the begining operator.");
                return;
            }

            if (lastCharacter == '+' || lastCharacter == '-' || lastCharacter == '*' || lastCharacter == '/')
            {
                CalcLine cl = new CalcLine(txtValue.Text.Substring(0, txtValueLenght - 1));
                cal.Add(cl);

                txtValue.Text = txtValue.Text.Substring(txtValueLenght - 1);
                this.ActiveControl = null;
            }
            else if (lastCharacter == '#' || lastCharacter == '=')
            {                
                CalcLine cl = new CalcLine(txtValue.Text.Substring(0, txtValueLenght - 1));
                cal.Add(cl);

                cl = new CalcLine(txtValue.Text.Substring(txtValueLenght - 1));
                cl.total = cal.obtainTotal();
                cal.Add(cl);

                txtValue.Text = "";
                this.ActiveControl = null;
            }
        }

        private void clearFormValue()
        {
            lstDisplay.DataSource = null;
            cal.Clear();
            txtValue.Text = "";
            txtChangeValue.Text = "";
            saveOptDlg.FileName = "Calculation1";
            addingStripSaved = false;
        }
    }
}
