using System;
using Xamarin.Forms;

namespace SmartHome
{
    public class DeviceTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _doorBellTemplate;
        private readonly DataTemplate _smokeTemplate;
        private readonly DataTemplate _thermostatTemplate;

        public DeviceTemplateSelector()
        {
            _doorBellTemplate = new DataTemplate(typeof(DoorBellViewCell));
            _smokeTemplate = new DataTemplate(typeof(SmokeDetectorViewCell));
            _thermostatTemplate = new DataTemplate(typeof(ThermostatViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is DoorBell)
            {
                return _doorBellTemplate;
            }

            if (item is SmokeDetector)
            {
                return _smokeTemplate;
            }

            if (item is Thermostat)
            {
                return _thermostatTemplate;
            }

            throw new Exception("Could not find the device type");
        }
    }
}