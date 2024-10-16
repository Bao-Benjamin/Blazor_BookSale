using BlazorBookSale.Models;
using BlazorBookSale.Repositories;

namespace BlazorBookSales.Reponsitories;

public class BookSaleReponsitory : IBookSaleRepository{
    BooksalesContext bookSaleContext;
    public BookSaleReponsitory(BooksalesContext context){
        this.bookSaleContext = context;
    }
    public async Task AddNewSale(Booksale bookSale){
        await this.bookSaleContext.AddAsync(bookSale);
        await this.bookSaleContext.SaveChangesAsync();
        
    }
}