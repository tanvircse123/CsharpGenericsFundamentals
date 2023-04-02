using WiredBrainCoffie.StorageApp.Entities;
using WiredBrainCoffie.StorageApp.Repository;
using WiredBrainCoffie.StorageApp.Entities.Base;
using WiredBrainCoffie.StorageApp.Data;
using System.Text.Json;
using WiredBrainCoffie.StorageApp.Extension;
// var  orgaRepoanother = new GenericRepositoryWithRemove<Organization>();
// orgaRepoanother.Add(new Organization{Name="Nokia"});
// orgaRepoanother.Add(new Organization{Name="Apple"});
// orgaRepoanother.Add(new Organization{Name="Vivo"});
// orgaRepoanother.Add(new Organization{Name="Sony"});
// orgaRepoanother.Save();

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContetxt());
var employeelistRepo = new ListsRepository<Employee>();
var orgaRepo = new SqlRepository<Organization>(new StorageAppDbContetxt());


// Console.WriteLine("---------------- Comning From the SQL Repository ----------------------");
//AddEmployee(employeeRepository);
// GetEmployeeById(employeeRepository,1);
// Console.WriteLine("----------------------------------------------");
AddOrganizations(orgaRepo);
AddEmployees(employeeRepository);


//AddEmployee(employeelistRepo);
// GetEmployeeById(employeelistRepo,1);
//Console.WriteLine("---------------");
//getAll(employeeRepository);
//Console.WriteLine("---------------");
//getAll(employeelistRepo);

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

static void AddEmployees(IRepository<Employee> employeeRepo){
    var employees = new []
    {
        new Employee{FirstName="Tanvir"},
        new Employee{FirstName="Ornob"},
        new Employee{FirstName="Ornik"},
        new Employee{FirstName="Aaaron"},
        new Employee{FirstName="Tanvir Rahman"},
    };
    employeeRepo.AddbatchEx<Employee>(employees);
    Console.WriteLine("Added And Saved");    
}



static void AddOrganizations(IRepository<Organization> organizationRepository){
    var organizations = new []
    {
        new Organization{Name="pluralsight"},
        new Organization{Name="udemy"},
        new Organization{Name="coursera"},
        new Organization{Name="codecademy"},
        new Organization{Name="udaccity"},

    };
    AddBatch<Organization>(organizationRepository,organizations);
    Console.WriteLine("Added And Saved");
}


// adding static generic method
static void AddBatch<T>(IRepository<T> repository,T[] items) where T:EntityBase{
    foreach(var item in items){
        repository.Add(item);
    }
    repository.Save();
}


static void getAllElements<T>(IRepository<T> repository) where T:EntityBase{
    var items  =  repository.GetAll().ToList();
    var itemjson = JsonSerializer.Serialize(items);
    Console.WriteLine(itemjson);
    
}

getAllElements<Employee>(employeeRepository);
Console.WriteLine("----------------------------------");
getAllElements<Organization>(orgaRepo);

