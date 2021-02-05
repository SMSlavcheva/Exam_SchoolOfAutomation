namespace BasicSelenium.Models
{
    public class User
    {
        private string _firstName;
        private string _sirName;
        private string _email;
        private string _pass;
        private string _country;
        private string _city;
        private bool _is_admin = false;
        private string _title;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string SirName
        {
            get { return _sirName; }
            set { _sirName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public bool IsAdmin
        {
            get { return _is_admin; }
            set { _is_admin = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
