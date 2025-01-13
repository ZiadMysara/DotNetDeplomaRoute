namespace Assignment04.Question_02
{
    internal class BasicAuthenticationService : IAuthenticationService
    {
        // log in
        public bool AuthenticateUser(string username, string password)
        {
            if (DateBase.Users.Any(u => u.Username == username && u.Password == password))
            {
                return true;
            }
            return false;

        }

        // 
        public bool AuthorizeUser(string username, string password)
        {
            if (username.Contains("$") || username.Contains("#") || username.Contains("@") || username.Contains("!"))
            {
                return false;
            }
            return DateBase.AddUser(new User(username, password));

        }
    }
}
