using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// wrap all of the data I am going to send from the controller to the view in a single view model class
    /// </summary>
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        //Listing 9-1. Adding a Property in the ProductsListViewModel .cs File in the Models/ViewModels Folder
        public string CurrentCategory { get; set; }
    }
}
