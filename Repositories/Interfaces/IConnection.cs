using System.Data;

namespace Repositories.Interfaces
{
    public interface IConnection
    {
        void Open();
        void Close();
        IDbCommand CreateCommand();
    }
}
