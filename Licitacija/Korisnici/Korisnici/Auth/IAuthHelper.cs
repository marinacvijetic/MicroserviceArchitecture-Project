namespace Korisnici.Auth
{
    public interface IAuthHelper
    {
        public bool Authorize(string key);
    }
}
