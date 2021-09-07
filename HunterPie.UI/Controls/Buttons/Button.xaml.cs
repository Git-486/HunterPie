﻿using HunterPie.UI.Architecture;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HunterPie.UI.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for NativeButton.xaml
    /// </summary>
    public partial class Button : ClickableControl
    {
        private readonly Storyboard _rippleAnimation;

        public new object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(Button));

        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }
        public static new readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(Button), new PropertyMetadata(Brushes.WhiteSmoke));

        public Button()
        {
            InitializeComponent();

            _rippleAnimation = FindResource("PART_RippleAnimation") as Storyboard;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            var targetWidth = Math.Max(ActualWidth, ActualHeight) * 2;
            var mousePosition = e.GetPosition(this);
            var startMargin = new Thickness(mousePosition.X, mousePosition.Y, 0, 0);
            PART_Ripple.Margin = startMargin;
            (_rippleAnimation.Children[0] as DoubleAnimation).To = targetWidth;
            (_rippleAnimation.Children[1] as ThicknessAnimation).From = startMargin;
            (_rippleAnimation.Children[1] as ThicknessAnimation).To = new Thickness(mousePosition.X - targetWidth / 2, mousePosition.Y - targetWidth / 2, 0, 0);
            PART_Ripple.BeginStoryboard(_rippleAnimation);

            e.Handled = true;
        }
    }
}
