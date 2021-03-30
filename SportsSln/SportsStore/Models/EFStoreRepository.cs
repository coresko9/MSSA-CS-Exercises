using System.Linq;
namespace SportsStore.Models 
{ 
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;
        public EFStoreRepository(StoreDbContext ctx) 
        { 
            context = ctx; 
        } 
        public IQueryable<FamMember> famMembers => context.famMembers;  //Select * From Products
    } 
}

