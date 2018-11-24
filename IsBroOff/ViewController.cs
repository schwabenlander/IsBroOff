using System;
using System.Net.Http;
using Foundation;
using IsBroOff.Models;
using Newtonsoft.Json;
using UIKit;
using Plugin.Connectivity;

namespace IsBroOff
{
    public partial class ViewController : UIViewController
    {
        readonly string BaseUri = "https://isbrooff.azurewebsites.net";
        readonly DateTime KnownFirstDayOff = new DateTime(2018, 1, 7);

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void FindOutButton_TouchUpInside(UIButton sender)
        {
            var date = DateTime.Parse(QueryDatePicker.Date.ToString());

            if (date <= KnownFirstDayOff)
            {
                var dateErrorAlert =
                    UIAlertController.Create("Invalid Date",
                                             $"Please choose a date after {KnownFirstDayOff.ToShortDateString()}.",
                                             UIAlertControllerStyle.Alert);
                dateErrorAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(dateErrorAlert, true, null);

                return;
            }

            StatusLabel.Hidden = true;
            StatusLabel.Text = "Please wait...";
            StatusLabel.Hidden = false;

            if (CrossConnectivity.Current.IsConnected &&
                Reachability.IsHostReachable(BaseUri))
            {
                IsBroOffApiCall(date);
            }
            else 
            {
                ClearLabels();
                StatusLabel.Text = "Unable to connect to server.";
                StatusLabel.Hidden = false;
            }
        }

        partial void QueryDatePicker_ValueChanged(UIDatePicker sender)
        {
            ClearLabels();
        }

        private void ClearLabels()
        {
            ResultLabel.Hidden = true;
            StatusLabel.Hidden = true;
            ResultLabel.Text = String.Empty;
            StatusLabel.Text = String.Empty;
            CallBroButton.Hidden = true;
        }

        //private bool IsBroOff(DateTime queryDate)
        //{
        //    var result = IsBroOffApiCallAsync(queryDate);
        //
        //    if (queryDate < KnownFirstDayOff)
        //        throw new ArgumentOutOfRangeException();
        //
        //    var daysSinceKnownFirstDayOff = (queryDate.Date - KnownFirstDayOff.Date).Days;
        //    var carrier = daysSinceKnownFirstDayOff % 8;
        //
        //    if (carrier >= 0 && carrier < 4)
        //        return true;
        //
        //    return false;
        //}

        private async void IsBroOffApiCall(DateTime queryDate)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };

            HttpResponseMessage response =
                await client.GetAsync(
                    $"/api/calendar/{queryDate.Year}/{queryDate.Month}/{queryDate.Day}");

            var result = await response.Content.ReadAsStringAsync();

            var scheduleResponse = JsonConvert.DeserializeObject<ScheduleResponse>(result);

            var broIsOff = scheduleResponse.IsBroOff;

            if (broIsOff)
            {
                ResultLabel.TextColor = UIColor.Green;
                ResultLabel.Text = "Yes!";

                StatusLabel.Text = $"Bro is off on {queryDate.ToLongDateString()}";
                StatusLabel.Hidden = false;

                CallBroButton.Hidden = false;
            }
            else
            {
                ResultLabel.TextColor = UIColor.Red;
                ResultLabel.Text = "No";

                StatusLabel.Text = $"Bro has work on {queryDate.ToLongDateString()}";
                StatusLabel.Hidden = false;
            }

            ResultLabel.Hidden = false;
        }

        partial void CallBroButton_TouchUpInside(UIButton sender)
        {
            var url = new NSUrl("tel:+97433498773");
            if (!UIApplication.SharedApplication.OpenUrl(url))
            {
                var notSupportedAlert =
                     UIAlertController.Create("Not Supported",
                                              "You cannot make voice calls using this device.",
                                              UIAlertControllerStyle.Alert);
                notSupportedAlert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(notSupportedAlert, true, null);
            };
        }
    }
}
