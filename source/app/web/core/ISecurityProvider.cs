namespace app.web.core
{
    public interface ISecurityProvider
    {
        bool Qualify();
    }

    public class SecurityProvider: ISecurityProvider
    {
        public bool Qualify()
        {
            throw new System.NotImplementedException();
        }
    }
}