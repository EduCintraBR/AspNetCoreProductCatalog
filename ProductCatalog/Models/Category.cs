using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace ProductCatalog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Product> Products { get; set; }

        //public void Validate()
        //{   
        //    AddNotifications(
        //      new Contract()
        //            .HasMaxLen(Title, 100, "Title", "O título da Categoria não pode ter mais que 100 caracteres")
        //            .HasMinLen(Title, 2, "Title", "O título da Categoria deve ter no minímo 2 caracteres")
        //    );
        //}
    }
}
