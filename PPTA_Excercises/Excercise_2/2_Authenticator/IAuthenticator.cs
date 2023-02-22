namespace PPTA_Excercises.Excercise_2.Authenticator
{
    public interface IAuthenticator
    {
        public bool? Authenticate(string userName, string password);
    }
}
