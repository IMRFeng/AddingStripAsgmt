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
    public partial class AddStripForm : Form
    {
        private Calculation cal;

        public AddStripForm()
        {
            InitializeComponent();

            cal = new Calculation(lstDisplay);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double otxtValue = 0;
            int txtChangeValueLength = txtChangeValue.Text.Length;
            if (txtChangeValueLength > 1 && !double.TryParse(txtChangeValue.Text.Substring(1, txtChangeValueLength - 1), out otxtValue))
            {
                MessageBox.Show("The value of following a operator must be a number!");
            }

            char firstCharacter = txtChangeValue.Text[0];
            if (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/')//check if the txtValue starts with + and -.
            {
                int index = lstDisplay.SelectedIndex;
                CalcLine cl = new CalcLine(txtChangeValue.Text);
                cal.Replace(cl, index);

                txtChangeValue.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lstDisplay.SelectedIndex;

            cal.Delete(index);

            txtChangeValue.Text = "";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            double otxtValue = 0;
            int txtChangeValueLength = txtChangeValue.Text.Length;

            if (txtChangeValueLength > 1 && !double.TryParse(txtChangeValue.Text.Substring(1, txtChangeValueLength - 1), out otxtValue))
            {
                MessageBox.Show("The value of following a operator must be a number!");
            }

            char firstCharacter = txtChangeValue.Text[0];
            if (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/')//check if the txtValue starts with + and -.
            {
                int index = lstDisplay.SelectedIndex;
                CalcLine cl = new CalcLine(txtChangeValue.Text);
                cal.Insert(cl, index);
                txtChangeValue.Text = "";
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            lstDisplay.DataSource = null;
            cal.Clear();
            txtValue.Text = "";
            txtChangeValue.Text = "";
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (openOptDlg.ShowDialog() == DialogResult.OK)
            {
                txtValue.Text = "";
                txtChangeValue.Text = "";

                cal.LoadFromFile(openOptDlg.FileName);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (saveOptDlg.FileName.Equals(""))
            {
                if (saveOptDlg.ShowDialog() == DialogResult.OK)
                {
                    cal.SaveToFile(saveOptDlg.FileName);
                }
            }
            else
            {
                cal.SaveToFile(saveOptDlg.FileName);
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (saveOptDlg.ShowDialog() == DialogResult.OK)
            {
                cal.SaveToFile(saveOptDlg.FileName);
            }
        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int txtValueLength = txtValue.Text.Length;
                if (txtValueLength > 0 && (txtValue.Text[0] != '+' && txtValue.Text[0] != '-') && cal.obtainTheCalsSize() == 0)
                {
                    MessageBox.Show("The first character may only be +, - or the Enter key!");
                    return;
                }
                else if (txtValueLength == 0 && cal.obtainTheCalsSize() == 0)
                {
                    MessageBox.Show("There no caculations!");
                    return;
                }
                else
                {
                    if (Regex.IsMatch(txtValue.Text, @"^+\-*") && txtValueLength > 1)
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
                            MessageBox.Show("The value of following a operator must be a number!");
                        }
                        
                    }
                    else if (txtValueLength == 1 && txtValue.Text.Equals("="))
                    {
                        CalcLine cl = new CalcLine("=");
                        cl.total = cal.obtainTotal();
                        cal.Add(cl);
                        this.ActiveControl = null;
                    }
                }
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            int txtValueLenght = txtValue.Text.Length;

            if (txtValueLenght > 0)
            {
                char firstCharacter = txtValue.Text[0];
                if (cal.obtainTheCalsSize() == 0 && (firstCharacter == '+' || firstCharacter == '-'))
                {
                    if (txtValueLenght > 1)
                    {
                        char lastCharacter = txtValue.Text[txtValueLenght - 1];

                        addNewRow(lastCharacter);
                    }
                }
                else if (cal.obtainTheCalsSize() > 0 && (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/'))//check if the txtValue starts with + and -.
                {
                    if (txtValueLenght > 1)
                    {
                        char lastCharacter = txtValue.Text[txtValueLenght - 1];

                        addNewRow(lastCharacter);
                    }
                }
                else
                {
                    MessageBox.Show("The first character may only be +, - or the Enter key!");
                }
            }
        }
        
        private void addNewRow(char lastCharacter)
        {
            int txtValueLenght = txtValue.Text.Length;
            double otxtValue = 0;
            
            if (lastCharacter == '+' || lastCharacter == '-' || lastCharacter == '*' || lastCharacter == '/')
            {
                if (txtValueLenght > 1 && !double.TryParse(txtValue.Text.Substring(1, txtValueLenght - 2 > 1 ? txtValueLenght - 2 : 1), out otxtValue))
                {
                    MessageBox.Show("The value of following a operator must be a number!");
                    return;
                }
                CalcLine cl = new CalcLine(txtValue.Text.Substring(0, txtValueLenght - 1));
                cal.Add(cl);

                txtValue.Text = txtValue.Text.Substring(txtValueLenght - 1);
                this.ActiveControl = null;
            }
            else if (lastCharacter == '#' || lastCharacter == '=')
            {
                if (txtValueLenght > 1 && !double.TryParse(txtValue.Text.Substring(1, txtValueLenght - 2 > 1 ? txtValueLenght - 2 : 1), out otxtValue))
                {
                    MessageBox.Show("The value of following a operator must be a number!");
                    return;
                }
                CalcLine cl = new CalcLine(txtValue.Text.Substring(0, txtValueLenght - 1));
                cal.Add(cl);

                cl = new CalcLine(txtValue.Text.Substring(txtValueLenght - 1));
                cl.total = cal.obtainTotal();
                cal.Add(cl);

                txtValue.Text = "";
                this.ActiveControl = null;
            }
        }

        private void lstDisplay_Click(object sender, EventArgs e)
        {
            if (cal.obtainTheCalsSize() > 0)
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

    }
}
