using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BddWithXamarinUITest
{
	public static class TestHelpers
	{
		public static iOSAppConfigurator SetDeviceByName(this iOSAppConfigurator configurator, string simulatorName)
		{
			var deviceId = GetDeviceID(simulatorName);
			return configurator.DeviceIdentifier(deviceId);
		}

		public static string GetDeviceID(string simulatorName)
		{
			if (!TestEnvironment.Platform.Equals(TestPlatform.Local))
			{
				return string.Empty;
			}

			// See below for the InstrumentsRunner class.
			IEnumerable<Simulator> simulators = new InstrumentsRunner().GetListOfSimulators();

			var simulator = (from sim in simulators
				where sim.Name.Equals(simulatorName)
				select sim).FirstOrDefault();

			if (simulator == null)
			{
				throw new ArgumentException("Could not find a device identifier for '" + simulatorName + "'.", "simulatorName");
			}
			else
			{
				return simulator.GUID;
			}
		}
	}
}