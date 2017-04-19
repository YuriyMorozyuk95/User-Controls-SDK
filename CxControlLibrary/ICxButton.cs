using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CxControlLibrary
{
    public enum ButtonStateType
    { Regular, Hover, Pressed, Dissabled }
    interface ICxButton
    {
        ButtonStateType ButtonState { get; set; }
        bool Enabled { get; set; }
        Image Icon { get; set; }
        Brush ForegroundColor { get; set; }
        String Label { get; set; }
        bool IsToggle { get; set; }
        bool Cheked { get; set; }

        Dictionary<ButtonStateType,String> IconPathSourse { get; set; }
        void FactoryIconPathSourse();

        Uri RegularIconPath { get; set; }
        Uri HoverIconPath { get; set; }
        Uri PressedIconPath { get; set; }
        Uri DissabledIconPath { get; set; }
    }
}
