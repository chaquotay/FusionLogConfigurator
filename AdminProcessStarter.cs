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

using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace FusLogConfig
{
    internal class AdminProcessStarter
    {
        private const int ElevationDeniedByUser = 1223;

        private static bool IsAdmin
        {
            get {
                var windowsIdentity = WindowsIdentity.GetCurrent();
                var windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public static bool ElevationRequired {
            get { return !IsAdmin; }
        }

        public static bool StartSelf(string arguments)
        {
            var path = Assembly.GetExecutingAssembly().CodeBase;
            return Start(path, arguments);
        }

        public static bool Start(string exe, string arguments)
        {
            var start = new ProcessStartInfo(exe, arguments);
            var proc = new Process {StartInfo = start};
            return Start(proc);
        }

        public static bool Start(Process process)
        {
            if (ElevationRequired)
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "runas";
            }

            try
            {
                process.Start();
            }
            catch (Win32Exception ex)
            {
                // TODO: Feedback to user
                var elevationDeniedByUser = ex.NativeErrorCode == ElevationDeniedByUser;
                return false;
            }
            catch
            {
                // TODO: Feedback to user
                return false;
            }
            process.WaitForExit();
            return true;
        }
    }
}
