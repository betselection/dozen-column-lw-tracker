//  TrackerData.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Tracker data.
/// </summary>
namespace Dozen_47_Column__Lw__Tracker
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Tracker data class for DataGridView-based trackers
    /// </summary>
    public class TrackerData
    {
        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The advisor.
        /// </summary>
        private string advisor;

        /// <summary>
        /// The registry.
        /// </summary>
        private string registry;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dozen_47_Column__Lw__Tracker.TrackerData"/> class.
        /// </summary>
        /// <param name="name">Name string.</param>
        public TrackerData(string name)
        {
            // Set name
            this.name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the advisor.
        /// </summary>
        /// <value>The advisor.</value>
        public string Advisor
        {
            get
            {
                return this.advisor;
            }

            set
            {
                this.advisor = value;
            }
        }

        /// <summary>
        /// Gets or sets the registry.
        /// </summary>
        /// <value>The registry.</value>
        public string Registry
        {
            get
            {
                return this.registry;
            }

            set
            {
                this.registry = value;
            }
        }
    }
}