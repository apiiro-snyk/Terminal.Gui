﻿using System.CommandLine;
using JetBrains.Annotations;
using UICatalog.Scenarios;

namespace Terminal.Gui.ViewsTests;

[TestSubject (typeof (Shortcut))]
public class ShortcutTests
{

    [Fact]
    public void Constructor_Defaults ()
    {
        Shortcut shortcut = new Shortcut ();

        Assert.NotNull (shortcut);
        Assert.True (shortcut.CanFocus);
        Assert.IsType<DimAuto> (shortcut.Width);
        Assert.IsType<DimAuto> (shortcut.Height);

        // TOOD: more
    }

    [Theory]
    [InlineData ("", "", KeyCode.Null, 2)]
    [InlineData ("C", "", KeyCode.Null, 3)]
    [InlineData ("", "H", KeyCode.Null, 5)]
    [InlineData ("", "", KeyCode.K, 5)]
    [InlineData ("C", "", KeyCode.K, 6)]
    [InlineData ("C", "H", KeyCode.Null, 6)]
    [InlineData ("", "H", KeyCode.K, 8)]
    [InlineData ("C", "H", KeyCode.K, 9)]
    public void NaturalSize (string command, string help, Key key, int expectedWidth)
    {
        Shortcut shortcut = new Shortcut ()
        {
            Title = command,
            HelpText = help,
            Key = key,
        };

        Assert.IsType<DimAuto> (shortcut.Width);
        Assert.IsType<DimAuto> (shortcut.Height);

        shortcut.LayoutSubviews ();
        shortcut.SetRelativeLayout (new Size (100, 100));

        // |0123456789
        // | C  H  K |
        Assert.Equal (expectedWidth, shortcut.Frame.Width);
    }

    [Theory]
    [InlineData (5, 0, 3, 6)]
    [InlineData (6, 0, 3, 6)]
    [InlineData (7, 0, 3, 6)]
    [InlineData (8, 0, 3, 6)]
    [InlineData (9, 0, 3, 6)]
    [InlineData (10, 0, 4, 7)]
    [InlineData (11, 0, 5, 8)]
    public void Set_Width_Layouts_Correctly (int width, int expectedCmdX, int expectedHelpX, int expectedKeyX)
    {
        Shortcut shortcut = new Shortcut ()
        {
            Width = width,
            Title = "C",
            Text = "H",
            Key = Key.K
        };

        shortcut.LayoutSubviews ();
        shortcut.SetRelativeLayout (new Size (100, 100));

        // 0123456789
        // -C--H--K- 
        Assert.Equal (expectedCmdX, shortcut.CommandView.Frame.X);
        Assert.Equal (expectedHelpX, shortcut.HelpView.Frame.X);
        Assert.Equal (expectedKeyX, shortcut.KeyView.Frame.X);
    }

    [Fact]
    public void CommandView_Text_And_Title_Track ()
    {
        Shortcut shortcut = new Shortcut ()
        {
            Title = "T",
        };

        Assert.Equal (shortcut.Title, shortcut.CommandView.Text);

        shortcut = new Shortcut ()
        {
        };
        shortcut.CommandView = new View ()
        {
            Text = "T"
        };
        Assert.Equal (shortcut.Title, shortcut.CommandView.Text);
    }

    [Fact]
    public void HelpText_And_Text_Are_The_Same ()
    {
        Shortcut shortcut = new Shortcut ()
        {
            Text = "H",
        };

        Assert.Equal (shortcut.Text, shortcut.HelpText);

        shortcut = new Shortcut ()
        {
            HelpText = "H",
        };

        Assert.Equal (shortcut.Text, shortcut.HelpText);
    }

    [Theory]
    [InlineData (KeyCode.Null, "")]
    [InlineData (KeyCode.F1, "F1")]
    public void KeyView_Text_Tracks_Key (Key key, string expected)
    {
        Shortcut shortcut = new Shortcut ()
        {
            Key = key,
        };

        Assert.Equal (expected, shortcut.KeyView.Text);
    }

    // Test Key
    [Fact]
    public void Key_Defaults_To_Empty ()
    {
        Shortcut shortcut = new Shortcut ();

        Assert.Equal (Key.Empty, shortcut.Key);
    }

    [Fact]
    public void Key_Can_Be_Set ()
    {
        Shortcut shortcut = new Shortcut ();

        shortcut.Key = Key.F1;

        Assert.Equal (Key.F1, shortcut.Key);
    }

    [Fact]
    public void Key_Can_Be_Set_To_Empty ()
    {
        Shortcut shortcut = new Shortcut ();

        shortcut.Key = Key.Empty;

        Assert.Equal (Key.Empty, shortcut.Key);
    }

    // Test KeyBindingScope

    // Test Key gets bound correctly
    [Fact]
    public void KeyBindingScope_Defaults_To_HotKey ()
    {
        Shortcut shortcut = new Shortcut ();

        Assert.Equal (KeyBindingScope.HotKey, shortcut.KeyBindingScope);
    }

    [Fact]
    public void KeyBindingScope_Can_Be_Set ()
    {
        Shortcut shortcut = new Shortcut ();

        shortcut.KeyBindingScope = KeyBindingScope.Application;

        Assert.Equal (KeyBindingScope.Application, shortcut.KeyBindingScope);
    }

    [Fact]
    public void Setting_Key_Binds_Key_To_CommandView_Accept ()
    {
        Shortcut shortcut = new Shortcut ();

        shortcut.Key = Key.F1;

        // TODO:
    }


    [Theory]
    [InlineData (Orientation.Horizontal)]
    [InlineData (Orientation.Vertical)]
    public void Orientation_SetsCorrectly (Orientation orientation)
    {
        var shortcut = new Shortcut
        {
            Orientation = orientation
        };

        Assert.Equal (orientation, shortcut.Orientation);
    }

    [Theory]
    [InlineData (AlignmentModes.StartToEnd)]
    [InlineData (AlignmentModes.EndToStart)]
    public void AlignmentModes_SetsCorrectly (AlignmentModes alignmentModes)
    {
        var shortcut = new Shortcut
        {
            AlignmentModes = alignmentModes
        };

        Assert.Equal (alignmentModes, shortcut.AlignmentModes);
    }

    [Fact]
    public void Action_SetsAndGetsCorrectly ()
    {
        bool actionInvoked = false;
        var shortcut = new Shortcut
        {
            Action = () => { actionInvoked = true; }
        };

        shortcut.Action.Invoke ();

        Assert.True (actionInvoked);
    }

    [Fact]
    public void ColorScheme_SetsAndGetsCorrectly ()
    {
        var colorScheme = new ColorScheme ();
        var shortcut = new Shortcut
        {
            ColorScheme = colorScheme
        };

        Assert.Same (colorScheme, shortcut.ColorScheme);
    }

    [Fact]
    public void Subview_Visibility_Controlled_By_Removal ()
    {
        var shortcut = new Shortcut ();

        Assert.True (shortcut.CommandView.Visible);
        Assert.Contains (shortcut.CommandView, shortcut.Subviews);
        Assert.True (shortcut.HelpView.Visible);
        Assert.DoesNotContain (shortcut.HelpView, shortcut.Subviews);
        Assert.True (shortcut.KeyView.Visible);
        Assert.DoesNotContain (shortcut.KeyView, shortcut.Subviews);

        shortcut.HelpText = "help";
        Assert.True (shortcut.HelpView.Visible);
        Assert.Contains (shortcut.HelpView, shortcut.Subviews);
        Assert.True (shortcut.KeyView.Visible);
        Assert.DoesNotContain (shortcut.KeyView, shortcut.Subviews);

        shortcut.Key = Key.A;
        Assert.True (shortcut.HelpView.Visible);
        Assert.Contains (shortcut.HelpView, shortcut.Subviews);
        Assert.True (shortcut.KeyView.Visible);
        Assert.Contains (shortcut.KeyView, shortcut.Subviews);

        shortcut.HelpView.Visible = false;
        shortcut.ShowHide();
        Assert.False (shortcut.HelpView.Visible);
        Assert.DoesNotContain (shortcut.HelpView, shortcut.Subviews);
        Assert.True (shortcut.KeyView.Visible);
        Assert.Contains (shortcut.KeyView, shortcut.Subviews);

        shortcut.KeyView.Visible = false;
        shortcut.ShowHide ();
        Assert.False (shortcut.HelpView.Visible);
        Assert.DoesNotContain (shortcut.HelpView, shortcut.Subviews);
        Assert.False (shortcut.KeyView.Visible);
        Assert.DoesNotContain (shortcut.KeyView, shortcut.Subviews);

    }

}
