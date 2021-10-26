using NET02._3.Attributes;

namespace NET02._3
{
    [TrakingEntity]
    class Student
    {
        [TrackingProperty("Name")]
        public string Name { get; set; }
        [TrackingProperty("Surname")]
        public string Surname { get; set; }
        [TrackingProperty("Age")]
        public int Age { get; set; }
    }
}
