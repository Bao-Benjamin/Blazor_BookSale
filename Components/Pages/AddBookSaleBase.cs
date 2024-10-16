using BlazorBookSale.Models;
using BlazorBookSale.Repositories;
using Microsoft.AspNetCore.Components;

public partial class AddBookSaleBase : ComponentBase
{
    public Booksale bookSale{get;set;}=new Booksale();
    [Inject]
    IBookSaleRepository? bookSaleRepository{get;set;}
    
    [Inject]
    NavigationManager? navigationManager {get;set;}

    public async Task HandleValidSubmit()
    {
        await bookSaleRepository.AddNewSale(bookSale);
        navigationManager.NavigateTo("/");

    }
    public async Task Form_Calculate()
    {
         await HandleValidSubmit();
    }


}