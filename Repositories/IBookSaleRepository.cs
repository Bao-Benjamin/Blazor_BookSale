using BlazorBookSale.Models;

namespace BlazorBookSale.Repositories;

public interface IBookSaleRepository{
    Task AddNewSale(Booksale booksale);
}