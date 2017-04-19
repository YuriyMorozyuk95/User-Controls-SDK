using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace CxControlLibrary
{
    class ShadowOptions
    {
        private Color _color;
        private double _direction;
        private double _softness;
        private double _opacity;
        private UIElement _control;

        public static void OnDropShadow(UIElement ob)
        {
            // Get a reference to the Button.
            var UI = ob;

            //Color = "Black"
            //            Direction = "270"
            //            ShadowDepth = "1"
            //            Softness = "0.75"
            //            Opacity = "1" />

            // Initialize a new DropShadowBitmapEffect that will be applied
            // to the Button.
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();

            // Set the color of the shadow to Black.
            Color myShadowColor = new Color();
            myShadowColor.ScA = 1; // Note that the alpha value is ignored by Color property. The Opacity property is used to control the alpha.
            myShadowColor.ScB = 0;
            myShadowColor.ScG = 0;
            myShadowColor.ScR = 0;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 270;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 1;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 0.75;

            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 1;

            // Apply the bitmap effect to the Button.
            UI.BitmapEffect = myDropShadowEffect;

        }
        public static void OffDropShadow(UIElement ob)
        {
            // Get a reference to the Button.
            UIElement UI = ob;

            // Initialize a new DropShadowBitmapEffect that will be applied
            // to the Button.
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();

            // Set the color of the shadow to Black.
            Color myShadowColor = new Color();
            myShadowColor.ScA = 1; // Note that the alpha value is ignored by Color property. The Opacity property is used to control the alpha.
            myShadowColor.ScB = 0;
            myShadowColor.ScG = 0;
            myShadowColor.ScR = 0;
            myDropShadowEffect.Color = myShadowColor;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = 0;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = 0;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = 0;

            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = 0;

            // Apply the bitmap effect to the Button.
            UI.BitmapEffect = myDropShadowEffect;
        }

        public ShadowOptions()
        { }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public double Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }
        public double Softness
        {
            get
            {
                return _softness;
            }
            set
            {
                _softness=value;
            }
        }
        public double Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                _opacity = value;
            }
        }
        public UIElement Control
        {
            get
            {
                return _control;
            }
            set
            {
                _control = value;
            }
        }

        public void SetShadow()
        {
            DropShadowBitmapEffect myDropShadowEffect = new DropShadowBitmapEffect();

            // Set the color of the shadow to Black.
            Color myShadowColor = Color;

            // Set the direction of where the shadow is cast to 320 degrees.
            myDropShadowEffect.Direction = Direction;

            // Set the depth of the shadow being cast.
            myDropShadowEffect.ShadowDepth = Softness;

            // Set the shadow softness to the maximum (range of 0-1).
            myDropShadowEffect.Softness = Opacity;

            // Set the shadow opacity to half opaque or in other words - half transparent.
            // The range is 0-1.
            myDropShadowEffect.Opacity = Opacity;

            // Apply the bitmap effect to the Button.
            Control.BitmapEffect = myDropShadowEffect;
        }
    }
}
