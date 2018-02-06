// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace IsBroOff
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallBroButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FindOutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InstructionsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker QueryDatePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StatusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Action ("CallBroButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CallBroButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("FindOutButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FindOutButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("QueryDatePicker_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void QueryDatePicker_ValueChanged (UIKit.UIDatePicker sender);

        void ReleaseDesignerOutlets ()
        {
            if (CallBroButton != null) {
                CallBroButton.Dispose ();
                CallBroButton = null;
            }

            if (FindOutButton != null) {
                FindOutButton.Dispose ();
                FindOutButton = null;
            }

            if (InstructionsLabel != null) {
                InstructionsLabel.Dispose ();
                InstructionsLabel = null;
            }

            if (QueryDatePicker != null) {
                QueryDatePicker.Dispose ();
                QueryDatePicker = null;
            }

            if (ResultLabel != null) {
                ResultLabel.Dispose ();
                ResultLabel = null;
            }

            if (StatusLabel != null) {
                StatusLabel.Dispose ();
                StatusLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}