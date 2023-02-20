namespace PPTA_Excercises.Excercise_2.Authenticator
{
    public class LoginDialog
    {
        private readonly IAuthenticator authenticator;

        public LoginDialog(IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        /// <summary>
        /// Shows the control that enables to login by the user
        /// </summary>
        public void Show()
        {
            // request to the GUI that shows login dialog
        }

        /// <summary>
        /// Button event while user submits <paramref name="userName"/> and <paramref name="password"/>
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Submit(string userName, string password)
        {
            if (authenticator.Authenticate(userName, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            // some GUI operations
            return true;
        }
    }

    
}
