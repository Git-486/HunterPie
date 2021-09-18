﻿using HunterPie.Core.Settings.Types;
using HunterPie.UI.Settings.Converter;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HunterPie.UI.Settings.Internal
{
    internal class StringVisualConverter : IVisualConverter
    {
        public UIElement Build(object parent, PropertyInfo childInfo)
        {
            Observable<string> observable = (Observable<string>)childInfo.GetValue(parent);
            var binding = VisualConverterHelper.CreateBinding(observable);
            TextBox textbox = new();

            BindingOperations.SetBinding(textbox, TextBox.TextProperty, binding);

            return textbox;
        }
    }
}
