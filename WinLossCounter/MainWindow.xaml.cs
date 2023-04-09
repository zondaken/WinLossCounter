using System;
using System.IO;
using System.Windows;

namespace WinLossCounter;

public partial class MainWindow : Window
{
    private int _wins;
    private int _loses;

    public SettingsConfig Settings { get; set; }

    public int Wins
    {
        get => _wins;
        set
        {
            if (_wins == value) return;
            _wins = value;
            WinText.Text = value.ToString();
            WriteFile();
        }
    }

    public int Loses
    {
        get => _loses;
        set
        {
            if (_loses == value) return;
            _loses = value;
            LoseText.Text = value.ToString();
            WriteFile();
        }
    }

    public MainWindow()
    {
        InitializeComponent();

        _wins = 0;
        _loses = 0;

        Settings = SettingsConfig.Load();
        WriteFile();

        this.Closed += MainWindow_Closed; ;
        SettingsButton.Click += SettingsButton_Click;
        AddWinButton.Click += AddWinButton_Click;
        AddLoseButton.Click += AddLoseButton_Click;
    }

    private void MainWindow_Closed(object? sender, EventArgs e)
    {
        Settings.Save();
        File.Delete(Settings.Filepath);
    }

    private void AddWinButton_Click(object sender, RoutedEventArgs e)
    {
        Wins += 1;
    }

    private void AddLoseButton_Click(object sender, RoutedEventArgs e)
    {
        Loses += 1;
    }

    private void SettingsButton_Click(object sender, RoutedEventArgs e)
    {
        new SettingsWindow(Settings).ShowDialog();
    }

    private void WriteFile()
    {
        string contents = Settings.Format
            .Replace("{0}", Wins.ToString())
            .Replace("{1}", Loses.ToString());

        File.WriteAllText(Settings.Filepath, contents);
    }
}
