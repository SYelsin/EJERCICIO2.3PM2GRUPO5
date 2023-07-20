using Ejercicio2_3Grupo5.Controllers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace Ejercicio2_3Grupo5
{
    public partial class App : Application
    {
        static DBProc dBProc;

        public static DBProc Instancia
        {
            get
            {
                if (dBProc == null)
                {
                    String dbname = "Proc.db3";
                    String dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    String dbfulp = Path.Combine(dbpath, dbname);
                    dBProc = new DBProc(dbfulp);
                }

                return dBProc;
            }
        }
        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
