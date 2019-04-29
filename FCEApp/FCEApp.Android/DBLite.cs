using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FCEApp.Droid;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(DBLite))]
namespace FCEApp.Droid
{
    public class DBLite : IDBLite
    {
        public string DatabasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DB3.DATABASE_NAME);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}