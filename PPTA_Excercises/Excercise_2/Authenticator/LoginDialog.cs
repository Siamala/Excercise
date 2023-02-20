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

    // test cases:
    // 1. Test if dialog closes successfully before user name and password are submitted. Use dummy authenticator
    // 2. Test if Submit returns false when wrong user name and password are provided and true when credenitals are correct. Use dummy authenticator
    // 3. Test if LoginDialog correctly invokes authenticator class:
    // authenticator should only be invoked once and should have the user name and password passed to the Submit method. Use authenticator spy
    // 4. Assume some expectedUserName and expectedPassword and test if LoginDialog correctly invokes Authenticator like in previous test
    // and validate all values provided to authenticator. Use mock authenticator
    // 5. Assume some arbitrary user name and password that are considered as correct credentials and check if LoginDialog's Submit method returns correct result
    // after providing correct and incorrect credentials. Use fake authenticator
}
