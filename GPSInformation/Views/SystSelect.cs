using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Views
{
    /// <summary>
    /// esta clase sirve para mapear selects
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class SystSelect
    {
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Value { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Label { get; set; }
    }
}
