using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using WingtipToys.Logic;
using WingtipToys.Models;

namespace WingtipToys.DotvvmSite.ViewModels
{
    public abstract class SiteViewModel : DotvvmViewModelBase
    {

        public int CartCount { get; set; }

        public abstract string PageTitle { get; }

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryDto> Categories { get; set; }


        public void LogOut()
        {
            Context.GetAuthentication().SignOut();
            Context.RedirectToLocalUrl("~/");
        }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                using (var usersShoppingCart = new ShoppingCartActions())
                {
                    CartCount = usersShoppingCart.GetCount();
                }

                Categories = GetCategories();
            }

            return base.PreRender();
        }

        private List<CategoryDto> GetCategories()
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;

            return query
                .Select(q => new CategoryDto()
                {
                    CategoryName = q.CategoryName
                })
                .ToList();
        }

        public class CategoryDto
        {
            public string CategoryName { get; set; }
        }
    }
}

