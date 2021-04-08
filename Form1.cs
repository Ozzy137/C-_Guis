﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2_Arrays_APP
{
    public partial class Form1 : Form
    {
        private const int MAX_SIZE = 5;
        private int[] firstArray = new int[MAX_SIZE];
        private int[] secondArray = new int[MAX_SIZE];
        private int[] thirdArray = new int[MAX_SIZE];
        private string[] allNumbers = new string[MAX_SIZE];
        private int i = 0;
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {


            // Tests whether both textboxes have values
            if (txtBxFstArr.Text == "" || txtBxSecArr.Text == "")
            {
                MessageBox.Show("Please Enter Values Into Both Arrays", "Warning!");
            }
            else
            {
                // Tests whether the entered values are numeric
                if (!double.TryParse(txtBxFstArr.Text, out _) || !double.TryParse(txtBxSecArr.Text, out _))
                {
                    txtBxFstArr.Clear();
                    txtBxSecArr.Clear();

                    txtBxFstArr.Focus();

                    MessageBox.Show("Please Enter Numeric Values for Both Arrays", "Warning!");
                }
                else
                {
                    // Adds the user input values to the arrays
                    if (count <= 4)
                    {
                        try
                        {
                            int numOne = Convert.ToInt32(txtBxFstArr.Text);
                            int numTwo = Convert.ToInt32(txtBxSecArr.Text);
                            firstArray[i] = numOne;
                            secondArray[i] = numTwo;

                            lstFrsArr.Items.Add(txtBxFstArr.Text);
                            lstSecArr.Items.Add(txtBxSecArr.Text);


                            thirdArray[i] = firstArray[i] * secondArray[i];

                            ++count;
                            i++;

                        }
                        catch (FormatException err)
                        {
                            MessageBox.Show(err.Message, "Waring!");
                        }
                        catch(OverflowException Ove)
                        {
                            MessageBox.Show(Ove.Message, "Warning");
                        }
                        catch(IndexOutOfRangeException rang)
                        {
                            MessageBox.Show(rang.Message, "Warning");
                        }
                        txtBxFstArr.Clear();
                        txtBxSecArr.Clear();


                    }
                    else
                    {
                        // Warns user that the array is full
                        MessageBox.Show("You have reached the 5 number Limit for the Arrays", "Warning!");
                        txtBxFstArr.Clear();
                        txtBxSecArr.Clear();
                    }

                }
                txtBxFstArr.Focus();
            }
        }

        private void btnDisp_Click(object sender, EventArgs e)
        {
            for (int h = 0; h <= 4; h++)
            {
                allNumbers[h] = "\n\n" + "First Array Values: " + Convert.ToString(firstArray[h]) + "\n" + "Second Array: " + Convert.ToString(secondArray[h]) + "\n" + "Third Array: " + Convert.ToString(thirdArray[h]) + "\n";
                lblArrVal.Text += allNumbers[h];
            }
            lblArrVal.Visible = true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBxFstArr.Clear();
            txtBxSecArr.Clear();
            txtBxFstArr.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            i = 0;
            count = 0;
            lblArrVal.Visible = false;
            txtBxFstArr.Clear();
            txtBxSecArr.Clear();
            txtBxFstArr.Focus();
            lstFrsArr.Items.Clear();
            lstSecArr.Items.Clear();
            Array.Clear(firstArray, 0, firstArray.Length);
            Array.Clear(secondArray, 0, secondArray.Length);
            Array.Clear(thirdArray, 0, thirdArray.Length);
            lblArrVal.Text = "Array Values";
        }
    }
}
