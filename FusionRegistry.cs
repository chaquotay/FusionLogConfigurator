/* FusionLogConfigurator - a .NET Fusion log configuration utility
 * Copyright (C) 2012  Stephan Müller
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace FusLogConfig
{
    internal static class FusionRegistry
    {
        public static FusionLogConfiguration ReadLogConfiguration()
        {
            var cfg = new FusionLogConfiguration();

            using (var fusionKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Fusion", false))
            {
                cfg.LogFailures = ToBoolValue(fusionKey.GetValue("LogFailures"));
                cfg.ForceLog = ToBoolValue(fusionKey.GetValue("ForceLog"));
                cfg.LogResourceBinds = ToBoolValue(fusionKey.GetValue("LogResourceBinds"));
                cfg.LogPath = (string)fusionKey.GetValue("LogPath");
            }
            
            return cfg;
        }

        private static bool ToBoolValue(object value)
        {
            return 1.Equals(value);
        }

        public static void WriteLogConfiguration(FusionLogConfiguration configuration)
        {
            using (var fusionKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Fusion", true))
            {
                fusionKey.SetValue("LogFailures", ToInt(configuration.LogFailures));
                fusionKey.SetValue("ForceLog", ToInt(configuration.ForceLog));
                fusionKey.SetValue("LogPath", configuration.LogPath);
                fusionKey.SetValue("LogResourceBinds", ToInt(configuration.LogResourceBinds));
            }
        }

        private static int ToInt(bool value)
        {
            return value ? 1 : 0;
        }
    }
}