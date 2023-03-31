using WiredBrainCoffie.StorageApp.Entities;
using WiredBrainCoffie.StorageApp.Repository;
using WiredBrainCoffie.StorageApp.Entities.Base;
using WiredBrainCoffie.StorageApp.Data;
// var  orgaRepoanother = new GenericRepositoryWithRemove<Organization>();
// orgaRepoanother.Add(new Organization{Name="Nokia"});
// orgaRepoanother.Add(new Organization{Name="Apple"});
// orgaRepoanother.Add(new Organization{Name="Vivo"});
// orgaRepoanother.Add(new Organization{Name="Sony"});
// orgaRepoanother.Save();

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContetxt());
var employeelistRepo = new ListsRepository<Employee>();
// Console.WriteLine("---------------- Comning From the SQL Repository ----------------------");
AddEmployee(employeeRepository);
// GetEmployeeById(employeeRepository,1);
// Console.WriteLine("----------------------------------------------");
AddEmployee(employeelistRepo);
// GetEmployeeById(employeelistRepo,1);
Console.WriteLine("---------------");
getAll(employeeRepository);
Console.WriteLine("---------------");
getAll(employeelistRepo);

// getEmployeeById
// write the method so that can be used in both
// List Repository and SQLrepository
static void GetEmployeeById(IRepository<Employee> employeeRepository,int Id){
    var employee = employeeRepository.GetByID(Id);
    Console.WriteLine($"Employee With {Id} is : {employee.FirstName}");

}

static void AddEmployee(IRepository<Employee> employeeRepository){
    employeeRepository.Add(new Employee{FirstName="Tanvir"});
    employeeRepository.Add(new Employee{FirstName="Ornob"});
    employeeRepository.Add(new Employee{FirstName="Ornik"});
    employeeRepository.Add(new Employee{FirstName="Aaaron"});
    employeeRepository.Save();
    
}
static void getAll(IRepository<Employee> employeeRepository){
    var employees =  employeeRepository.GetAll();
    foreach(var employee in employees){
        Console.WriteLine($" Id :{employee.Id} --- Name: {employee.FirstName}");
    }

}



