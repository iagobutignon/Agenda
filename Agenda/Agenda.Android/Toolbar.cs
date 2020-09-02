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

namespace Agenda.Droid
{
    public class Toolbar : Activity
    {
        public Window window;
        public void CorToolBar()
        {
            window.SetStatusBarColor(Android.Graphics.Color.Argb(200, 0, 0, 0));
        }
    }
}