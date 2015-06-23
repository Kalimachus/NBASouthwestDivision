using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.IO;




namespace BadgerTech
{
   public class MyUser
    {
       private static String _username;
       private static String _password;
       private static String _teamname;
       private static String _name;
       private static String _UserSalt;
       private static string _UserHash;
       private static int _teamID;
       private static int _pid;
       private static int _maxpid;


       public static int _MaxPID
       {
           get { return _maxpid; }
           set { _maxpid = value; }
       }

       public static String _Username
       {
            get { return _username;}
            set{  _username = value;}
       }

       public static String _Password
       {
           get { return _password; }
           set { _password = value; }
       }

       public static string _Salt
       {
           get { return _UserSalt; }
           set { _UserSalt = value;}
       }

       public static string _Hash
       {
           get { return _UserHash; }
           set { _UserHash = value; }
       }

       public static String _Teamname
       {
           get { return _teamname; }
           set { _teamname = value; }
       }

       public static int _TeamID
       {
           get { return _teamID; }
           set { _teamID = value; }
       }

       public static string _Name
       {
           get { return _name; }
           set { _name = value;}
        }

       public static int _PID
       {
           get { return _pid; }
           set { _pid = value; }
       }   
    }


}




