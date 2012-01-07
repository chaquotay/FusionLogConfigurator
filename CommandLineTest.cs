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

using NUnit.Framework;

namespace FusLogConfig
{
    [TestFixture]
    public class CommandLineTest
    {
        [Test]
        public void TestParseForce()
        {
            var delta = Parse();
            Assert.IsFalse(delta.ForceLog);

            delta = Parse("/force+");
            Assert.IsTrue(delta.ForceLog);

            delta = Parse("/force-");
            Assert.IsFalse(delta.ForceLog);
        }

        [Test]
        public void TestParseFailures()
        {
            var delta = Parse();
            Assert.IsFalse(delta.LogFailures);

            delta = Parse("/failures+");
            Assert.IsTrue(delta.LogFailures);

            delta = Parse("/failures-");
            Assert.IsFalse(delta.LogFailures);
        }

        [Test]
        public void TestParsePath()
        {
            var delta = Parse();
            Assert.IsNull(delta.LogPath);

            delta = Parse(@"/path:c:\foo\bar\baz");
            Assert.AreEqual(@"c:\foo\bar\baz", delta.LogPath);
        }

        private FusionLogConfiguration Parse(params string[] args)
        {
            return CommandLine.Parse(args);
        }
    }
}