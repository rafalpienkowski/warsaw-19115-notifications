namespace Warsaw.Notifications.Domain.Components.Models
{
    public struct District
    {
        internal District(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}