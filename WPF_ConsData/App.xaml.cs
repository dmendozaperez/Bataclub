﻿using Bata;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace WPF_ConsData
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-pe"); ;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-pe");

            FrameworkElement.LanguageProperty.OverrideMetadata(
             typeof(FrameworkElement),
             new FrameworkPropertyMetadata(
                   XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            //WpfSingleInstance.Make();
            base.OnStartup(e);
        }
    }
}
