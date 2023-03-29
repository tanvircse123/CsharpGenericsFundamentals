using WiredBrainCoffie.StorageApp.Entities;
using WiredBrainCoffie.StorageApp.Repository;
using WiredBrainCoffie.StorageApp.Entities.Base;

var  orgaRepoanother = new GenericRepositoryWithRemove<Organization>();
var orga1 = new Organization{Name="Samsung"};
orgaRepoanother.Add(orga1);
orgaRepoanother.Add(new Organization{Name="Nokia"});
orgaRepoanother.Add(new Organization{Name="Apple"});
orgaRepoanother.Add(new Organization{Name="Vivo"});
orgaRepoanother.Add(new Organization{Name="Sony"});

var item = orgaRepoanother.GetByID(1);
orgaRepoanother.Remove(item);
orgaRepoanother.Save();


