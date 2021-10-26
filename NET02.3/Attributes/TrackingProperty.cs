using System;
namespace NET02._3.Attributes
{
    public class TrackingProperty : Attribute
    {
        public string ColumnName { get; set; }
        public TrackingProperty(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
