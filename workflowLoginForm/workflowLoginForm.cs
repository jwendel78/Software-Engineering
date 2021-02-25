﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace workflowLoginForm
{
    public partial class workflowLoginForm : Form
    {
        public workflowLoginForm()
        {
            InitializeComponent();
        }

        Dictionary<string, int> registrationTable = new Dictionary<string, int>(); // Dictionary that stores a registered username to an ID
        private String getAuthorizedPassword(string userName)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;

            try
            {
                cn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ian\Source\Repos\WORK-FLOW\workflowLoginForm\UserLoginData.mdf";
                cmd.Connection = cn;
                cmd.CommandText = "SELECT userPassword FROM AuthorizedUsers WHERE userName = @username";
                cmd.Parameters.AddWithValue("@username", userName);

                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();

                return dr.GetString(0);
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message, "Warning!");

                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string enteredPassword = txtPassword.Text;

            try
            {
                if (enteredPassword == getAuthorizedPassword(txtUserName.Text))
                {
                    MessageBox.Show("Welcome to the Work Flow", "Successful Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Something Broke");
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            // Create a new class for user registration with SQL Server
            RegisterForm rform = new RegisterForm(); // Creates instance of Register Form class
            rform.ShowDialog(); // Shows the register form on the screen
        }

        private void workflowLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
