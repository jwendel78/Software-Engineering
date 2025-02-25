﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workflowLoginForm
{
    public class User
    {
        // Class level objects
        private DatabaseTools databaseTools;
        private UserManager userManager;

        // Variables
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Job { get; set; }

        // Constructor for displaying names of users in a particular job on admin screen
        public User (string username)
        {
            this.Username = username;
        }

        // Constructor for login
        public User (string username, string password)
        {
            userManager = new UserManager();
            this.Username = username;
            this.Password = password;
            this.Job = userManager.GetJob(username); // Sets job from the database with given username
        }

        // Constructor for registering a new user
        public User (string firstname, string lastname, string email, string username, string password, string job)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.Username = username;
            this.Password = password;
            this.Job = job;
        }

        // For future use to delete the user when exiting or logging out
        public void LogOut (User user)
        {
            user.Username = null;
            user.Password = null;
            user.Job = null;

        }

        public override string ToString()
        {
            return string.Format("Name: {0}", this.Username);      
        }

        /**
        public bool hasRole(string job)
        {
            if (this.Job.Equals(job))
            {
                return true;
            }

            return false;
        }
        */

    }

}