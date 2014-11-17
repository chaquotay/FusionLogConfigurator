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
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FusLogConfig
{
    internal class CommandLine
    {
        private static readonly Regex ForceLogPattern = new Regex(@"^/force(\+|\-)$");
        private static readonly Regex FailuresLogPattern = new Regex(@"^/failures(\+|\-)$");
        private static readonly Regex PathPattern = new Regex(@"^/path\:(.*)$");
        private static readonly Regex ResourcesPattern = new Regex(@"^/resources(\+|\-)$");

        public static string Format(FusionLogConfiguration configuration)
        {
            var arguments = new[]
                                {
                                    "/force" + (configuration.ForceLog ? '+' : '-'),
                                    "/failures" + (configuration.LogFailures ? '+' : '-'),
                                    "/resources" + (configuration.LogResourceBinds ? '+' : '-'),
                                    "\"/path:" + (configuration.LogDirectory ?? "") + "\""
                                };
            return string.Join(" ", arguments);
        }

        private delegate bool OptionParse(string arg);

        public static FusionLogConfiguration Parse(string[] args)
        {
            var delta = new FusionLogConfiguration();
            foreach(var arg in args)
            {
                ParseOption(arg, delta);
            }
            return delta;
        }

        private static void ParseOption(string arg, FusionLogConfiguration delta)
        {
            foreach(var parse in OptionParses(delta))
            {
                if (parse(arg)) return;
            }
        }

        private static IEnumerable<OptionParse> OptionParses(FusionLogConfiguration delta)
        {
            
            {
                yield return FlagParse(ForceLogPattern, f => delta.ForceLog = f);
                yield return FlagParse(FailuresLogPattern, f => delta.LogFailures = f);
                yield return FlagParse(ResourcesPattern, f => delta.LogResourceBinds = f);
                yield return StringParse(PathPattern, s => delta.LogDirectory = s);
            }
        }

        private static OptionParse FlagParse(Regex pattern, Action<bool> flagConsumer)
        {
            return arg =>
                       {
                           var match = pattern.Match(arg);
                           if(match.Success)
                           {
                               var flag = match.Groups[1].Value == "+";
                               flagConsumer(flag);
                               return true;
                           }
                           return false;
                       };
        }

        private static OptionParse StringParse(Regex pattern, Action<string > stringConsumer)
        {
            return arg =>
                       {
                           var match = pattern.Match(arg);
                           if (match.Success)
                           {
                               var flag = match.Groups[1].Value;
                               stringConsumer(flag);
                               return true;
                           }
                           return false;
                       };
        }
    }
}