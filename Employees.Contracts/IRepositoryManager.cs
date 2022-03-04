namespace Employees.Contracts
{
    public interface IRepositoryManager
    {

        IEmployeeRepository Employee{ get; }
        
    }
}