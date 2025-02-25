﻿using System;
using System.Diagnostics;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using PizzaIllico.Mobile.Pages;
using PizzaIllico.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PizzaIllico.Mobile
{
    public partial class App
    {
        public App() : base(() => new HomePage(), RegisterServices)
        {
#if DEBUG
            Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine($"{arg1} : {arg2}")));
#endif
            InitializeComponent();
        }

        private static void RegisterServices()
        {
            DependencyService.RegisterSingleton<IApiService>(new ApiService());
            
            DependencyService.RegisterSingleton<IPizzaApiService>(new PizzaApiService());
        }
    }
}