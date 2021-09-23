using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Dnd5e
{
    public class ClosableTab : TabItem
    {
        private ClosableHeader closableTabHeader;

        public ClosableTab()
        {
            closableTabHeader = new ClosableHeader();
            this.Header = closableTabHeader;

            closableTabHeader.buttonClose.MouseEnter +=
                new MouseEventHandler(buttonCloseMouseEnter);
            closableTabHeader.buttonClose.MouseLeave +=
                new MouseEventHandler(buttonCloseMouseLeave);
            closableTabHeader.buttonClose.Click +=
                new RoutedEventHandler(buttonCloseClick);
            closableTabHeader.buttonClose.SizeChanged +=
                new SizeChangedEventHandler(labelTabtitleSizeChanged);
        }
        public string Title
        {
            set
            {
                ((ClosableHeader)this.Header).labelTabTitle.Content = value;
            }
        }
        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((ClosableHeader)this.Header).buttonClose.Visibility = Visibility.Visible;
        }

        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((ClosableHeader)this.Header).buttonClose.Visibility = Visibility.Hidden;
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((ClosableHeader)this.Header).buttonClose.Visibility = Visibility.Visible;
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            ((ClosableHeader)this.Header).buttonClose.Visibility = Visibility.Hidden;
        }
        void buttonCloseMouseEnter(object sender, MouseEventArgs e)
        {
            ((ClosableHeader)this.Header).buttonClose.Foreground = Brushes.Red;
        }
        void buttonCloseMouseLeave(object sender, MouseEventArgs e)
        {
            ((ClosableHeader)this.Header).buttonClose.Foreground = Brushes.Black;
        }
        void buttonCloseClick(object sender, RoutedEventArgs e)
        {
            ((TabControl)this.Parent).Items.Remove(this);
        }
        void labelTabtitleSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((ClosableHeader)this.Header).buttonClose.Margin = new Thickness(
                ((ClosableHeader)this.Header).labelTabTitle.ActualWidth + 5, 3, 4, 0);
        }
    }
}
