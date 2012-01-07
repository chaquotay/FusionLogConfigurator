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

using System;
using System.Windows.Forms;

namespace FusLogConfig
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length>0)
            {
                var cfg = CommandLine.Parse(args);
                FusionRegistry.WriteLogConfiguration(cfg);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigDialog());
        }
    }
}
