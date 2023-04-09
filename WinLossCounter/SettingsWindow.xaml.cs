using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WinLossCounter;

public partial class SettingsWindow : Window
{
    public SettingsConfig Settings { get; set; }

    public SettingsWindow(SettingsConfig settings)
    {
        InitializeComponent();

        Settings = settings;
        FilepathText.Text = Settings.Filepath;
        FormatText.Text = Settings.Format;

        this.Closed += SettingsWindow_Closed;
        SaveButton.Click += SaveButton_Click;
        FilepathText.TextChanged += FilepathText_TextChanged;
        FormatText.TextChanged += FormatText_TextChanged;
    }

    private void SettingsWindow_Closed(object? sender, EventArgs e)
    {
        Settings.Save();
    }

    private void FilepathText_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tbx = (TextBox)sender;
        Settings.Filepath = tbx.Text;
    }

    private void FormatText_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tbx = (TextBox)sender;
        Settings.Format = tbx.Text;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
