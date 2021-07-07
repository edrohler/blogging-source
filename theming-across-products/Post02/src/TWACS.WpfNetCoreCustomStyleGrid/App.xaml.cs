using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ColorEditor;

namespace TWACS.WpfNetCoreCustomStyleGrid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MaterialPalette.Palette.AccentNormalColor = ColorConverter.ColorFromString("#FFFF9800");
            MaterialPalette.Palette.AccentHoverColor = ColorConverter.ColorFromString("#FFFFA824");
            MaterialPalette.Palette.AccentPressedColor = ColorConverter.ColorFromString("#FFFF4C00");
            MaterialPalette.Palette.DividerColor = ColorConverter.ColorFromString("#1E000000");
            MaterialPalette.Palette.IconColor = ColorConverter.ColorFromString("#FF000000");
            MaterialPalette.Palette.MainColor = ColorConverter.ColorFromString("#FFFFFFFF");
            MaterialPalette.Palette.MarkerColor = ColorConverter.ColorFromString("#FF000000");
            MaterialPalette.Palette.ValidationColor = ColorConverter.ColorFromString("#FFD50000");
            MaterialPalette.Palette.ComplementaryColor = ColorConverter.ColorFromString("#FFE0E0E0");
            MaterialPalette.Palette.AlternativeColor = ColorConverter.ColorFromString("#FFF5F5F5");
            MaterialPalette.Palette.MarkerInvertedColor = ColorConverter.ColorFromString("#FFFFFFFF");
            MaterialPalette.Palette.PrimaryColor = ColorConverter.ColorFromString("#FFFAFAFA");
            MaterialPalette.Palette.PrimaryNormalColor = ColorConverter.ColorFromString("#FF03A9F4");
            MaterialPalette.Palette.PrimaryFocusColor = ColorConverter.ColorFromString("#FF1EB6FD");
            MaterialPalette.Palette.PrimaryHoverColor = ColorConverter.ColorFromString("#FF1EB6FD");
            MaterialPalette.Palette.PrimaryPressedColor = ColorConverter.ColorFromString("#FFFF4C00");
            MaterialPalette.Palette.RippleColor = ColorConverter.ColorFromString("#FFFFFFFF");
            MaterialPalette.Palette.ReadOnlyBackgroundColor = ColorConverter.ColorFromString("#00FFFFFF");
            MaterialPalette.Palette.ReadOnlyBorderColor = ColorConverter.ColorFromString("#FFABABAB");
            MaterialPalette.Palette.DialogBackgroundColor = ColorConverter.ColorFromString("#FFFFFFFF");
            MaterialPalette.Palette.SelectedUnfocusedColor = ColorConverter.ColorFromString("#FFEEEEEE");
            MaterialPalette.Palette.DividerSolidColor = ColorConverter.ColorFromString("#FFE1E1E1");
            MaterialPalette.Palette.PrimaryOpacity = 0.87;
            MaterialPalette.Palette.SecondaryOpacity = 0.54;
            MaterialPalette.Palette.DisabledOpacity = 0.26;
            MaterialPalette.Palette.DividerOpacity = 0.38;

            this.InitializeComponent();
        }
    }
}
