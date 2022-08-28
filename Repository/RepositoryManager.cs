using Contracts;

namespace Repository;

public class RepositoryManager: IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICompanyRepository> _companyRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;
    public ICompanyRepository CompanyRepository => _companyRepository.Value;
    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        _employeeRepository =  new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
    }

    public void Save() => _repositoryContext.SaveChanges();
}