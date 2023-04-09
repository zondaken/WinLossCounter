using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLossCounter;

public class SettingsConfig
{
    public string Filepath { get; set; } = null!;
    public string Format { get; set; } = null!;

    private SettingsConfig() { }

    public void Save()
    {
        var dir = Environment.CurrentDirectory;
        var path = Path.Combine(dir, "config.txt");

        var contents = Filepath 
            + Environment.NewLine
            + Format;

        File.WriteAllText(path, contents);
    }

    public static SettingsConfig Load()
    {
        SettingsConfig config;

        var dir = Environment.CurrentDirectory;
        var path = Path.Combine(dir, "config.txt");

        if(!File.Exists(path))
        {
            config = new SettingsConfig();
            config.Filepath = Path.Combine(dir, "targetFile.txt");
            config.Format = "Wins: {0} / Loses: {1}";
            config.Save();
            return config;
        }

        var contents = File.ReadAllText(path);

        var split = contents.Split(Environment.NewLine);
        var targetPath = split[0];
        var targetFormat = split[1];
        
        config = new SettingsConfig();
        config.Filepath = targetPath;
        config.Format = targetFormat;

        return config;
    }
}
