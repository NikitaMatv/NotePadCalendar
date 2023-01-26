using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NotePadCalendar.Model;

namespace NotePadCalendar
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NorthificationBaseEntities DB = new NorthificationBaseEntities();
        public static User LoggedUser;
    }
}
