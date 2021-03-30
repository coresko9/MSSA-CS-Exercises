using System.Collections.Generic;
using SportsStore.Models;

namespace SportsStore.Models.ViewModels 
{
    public class ProductsListViewModel
    { 
        public IEnumerable<FamMember> famMembers { get; set; }
        public PagingInfo PagingInfo { get; set; } 
    }
}

