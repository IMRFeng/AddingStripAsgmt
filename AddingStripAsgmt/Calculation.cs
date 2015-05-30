using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace AddingStripAsgmt
{
    class Calculation
    {
        private ArrayList theCalcs;
        private ListBox lstDisplay;

        /// <summary>
        /// Constructor initializes the reference to the listbox and starts a new ArrayList
        /// </summary>
        /// <param name="lb">ListBox</param>
        public Calculation(ListBox lb)
        {
            lstDisplay = lb;
            theCalcs = new ArrayList();
        }

        /// <summary>
        /// Add a CalcLine object to the ArrayList then redisplay the calculations
        /// </summary>
        /// <param name="cl">CalcLine</param>
        public void Add(CalcLine cl)
        {
            this.theCalcs.Add(cl);
            this.Redisplay();
        }

        /// <summary>
        /// Get the sie of ArrayList
        /// </summary>
        /// <returns>int</returns>
        public int obtainTheCalsSize()
        {
            return theCalcs.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double obtainTotal()
        {
            double total = 0;

            foreach (CalcLine cl in this.theCalcs)
            {
                total = cl.NextResult(total);
            }
            return total;            
        }

        /// <summary>
        /// Clear the ArrayList and the listbox
        /// </summary>
        public void Clear()
        {
            theCalcs.Clear();
            lstDisplay.Items.Clear();
        }

        /// <summary>
        /// Clear the listbox and then for each line in the calculation.
        /// If the line is an ordinary calculation add the text version of the CalcLine 
        ///   to the listbox and calculate the result of the calculation so far. 
        /// If the line is for a total or subtotal add the text for the total or subtotal to the listbox. 
        /// If the line is for a total, the result of the calculation so far is reset to zero
        /// </summary>
        public void Redisplay()
        {
            lstDisplay.DataSource = null;
            double total = 0;

            foreach (CalcLine cl in this.theCalcs)
            {
                total = cl.NextResult(total);

                if (cl.Op.Equals(Operator.total) || cl.Op.Equals(Operator.subtotal))
                {
                    cl.total = total;
                }
            }

            lstDisplay.DataSource = theCalcs;
            //lstDisplay.SelectedItems.Clear();
            lstDisplay.SetSelected(0, false);
        }

        /// <summary>
        /// Return a reference to the nth CalcLine object in the ArrayList
        /// </summary>
        /// <param name="n">int</param>
        /// <returns>CalcLine</returns>
        public CalcLine Find(int n)
        {
            return (CalcLine)this.theCalcs[n];
        }

        /// <summary>
        /// Replace the nth CalcLine object in the ArrayList with the newCalc object, 
        /// and then redisplay the calculations
        /// </summary>
        /// <param name="newCalc">CalcLine</param>
        /// <param name="n">int</param>
        public void Replace(CalcLine newCalc, int n)
        {
            this.theCalcs.RemoveAt(n);
            this.theCalcs.Insert(n, newCalc);
            this.Redisplay();
        }

        /// <summary>
        /// Insert the newCalc CalcLine object in the ArrayList immediately before the nth object, 
        /// and then redisplay the calculations
        /// </summary>
        /// <param name="newCalc">CalcLine</param>
        /// <param name="n">int</param>
        public void Insert(CalcLine newCalc, int n)
        {
            this.theCalcs.Insert(n, newCalc);
            this.Redisplay();
        }

        /// <summary>
        /// Delete the nth CalcLine object in the ArrayList, and then redisplay the calculations
        /// </summary>
        /// <param name="n">int</param>
        public void Delete(int n)
        {
            this.theCalcs.RemoveAt(n);
            this.Redisplay();
        }

        /// <summary>
        /// Save all the CalcLine objects in the ArrayList as lines of text in the given file
        /// </summary>
        /// <param name="filename">string</param>
        public void SaveToFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            Array pArray = this.theCalcs.ToArray();
            StringBuilder sb = new StringBuilder();
            CalcLine clValue;

            for (int i = 0; i < pArray.Length; i++)
            {
                clValue = (CalcLine)pArray.GetValue(i);

                if (clValue.Op.Equals(Operator.total))
                {
                    sb.AppendLine("=");
                }
                else if (clValue.Op.Equals(Operator.subtotal))
                {
                    sb.AppendLine("#");
                }
                else
                {
                    sb.AppendLine(clValue.ToString());
                }
            }
            sw.Write(sb);
            sw.Close();
        }

        /// <summary>
        /// Clear the ArrayList and then open the given file and convert the lines of the file 
        /// to a set of CalcLine objects held in the ArrayList. Then redisplay the calculations
        /// </summary>
        /// <param name="filename">string</param>
        public void LoadFromFile(string filename)
        {
            lstDisplay.DataSource = null;
            this.theCalcs.Clear(); //Clear the ArrayList

            StreamReader sr = new StreamReader(filename);
            string personData = sr.ReadLine();
            string errorMsg = "";

            while (personData != null)
            {
                if (personData.Length == 1 && (personData.Equals("#") || personData.Equals("=")))
                {
                    CalcLine cl = new CalcLine(personData);
                    cl.total = this.obtainTotal();
                    this.Add(cl);

                    personData = sr.ReadLine();// Read line by line
                    continue;
                }

                double otxtValue = 0;
                if (personData.Length > 1 && !double.TryParse(personData.Substring(1), out otxtValue))
                {
                    errorMsg = "The value of following a operator must be a number!";
                    break;
                }

                char firstCharacter = personData[0];
                if (this.obtainTheCalsSize() == 0 && (firstCharacter == '+' || firstCharacter == '-'))
                {
                    if (personData.Length > 1)
                    {
                        CalcLine cl = new CalcLine(personData);
                        this.Add(cl);
                    }
                }
                else if (this.obtainTheCalsSize() > 0 && (firstCharacter == '+' || firstCharacter == '-' || firstCharacter == '*' || firstCharacter == '/'))//check if the txtValue starts with + and -.
                {
                    if (personData.Length > 1)
                    {
                        CalcLine cl = new CalcLine(personData);
                        this.Add(cl);
                    }
                }
                else
                {
                    errorMsg = "The first character may only be +, - or the Enter key!";
                    break;
                }

                personData = sr.ReadLine();// Read line by line
            }

            if (!errorMsg.Equals(""))
            {
                lstDisplay.DataSource = null;
                this.theCalcs.Clear();

                MessageBox.Show(errorMsg);
            }

            sr.Close();//Close Stream Reader
        }
    }
}
