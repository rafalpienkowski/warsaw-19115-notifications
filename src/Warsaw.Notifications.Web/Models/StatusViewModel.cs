using System;

namespace Warsaw.Notifications.Web.Models 
{
    public class StatusViewModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ChangeDate { get; set; }

        public override string ToString()
        {
            return $"{Name} {Description} {ChangeDate}";
        }
    }
}