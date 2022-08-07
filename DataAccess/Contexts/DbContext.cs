using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contexts
{
    static class DbContext
    {

        static DbContext()
        {
            Admins = new List<Admin>();
            Owners = new List<Owner>();
            Drugstores = new List<Drugstore>();
            Druggists = new List<Druggist>();
            Drugs = new List<Drug>();

            string password1 = "s";
            string hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("1", hashedPassword1);
            Admins.Add(admin1);

            string password2 = "z";
            string hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("2", hashedPassword2);
            Admins.Add(admin2);
        }


        public static List<Owner> Owners { get; set; }
        public static List<Drugstore> Drugstores { get; set; }
        public static List<Druggist>  Druggists{ get; set; }
        public static List<Drug> Drugs{ get; set; }
        public static List<Admin> Admins { get; set; }

    }
}



