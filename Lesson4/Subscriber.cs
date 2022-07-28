namespace Lesson4
{
    internal class Subscriber
    {
        private string id;
        private string phoneNumber;
        private string name;
        public string ID
        {
            get => this.id;
            set => this.id = value;
        }
        public string PhoneNumber
        {
            get => this.phoneNumber;
            set => this.phoneNumber = value;
        }
        public string Name
        {
            get => name; 
            set => this.name = value;
        }
        public Subscriber(string id, string name, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

    }
}