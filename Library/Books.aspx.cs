using AutoMapper;
using Library.Repositories;
using Library.Services.Interfaces;
using Library.ViewModels;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

public partial class Books : System.Web.UI.Page
{
    [Dependency]
    public IBookService BookService { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("/Account/Login/");
        }
    }

    public async Task<IEnumerable<BookViewModel>> BookList_GetData()
    {
        return (await BookService.GetAllBooksAsync())
            .Select(book => Mapper.Map<Book, BookViewModel>(book));
    }

    public async void BookList_DeleteItem(Guid id)
    {
        var isExist = await BookService.IsBookExistAsync(id);
        if (!isExist)
        {
            ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));

            return;
        }

        await BookService.DeleteBookAsync(id);
    }

    public async void BookList_UpdateItem(Guid id)
    {
        var bookViewModel = new BookViewModel();
        TryUpdateModel(bookViewModel);

        var isExist = await BookService.IsBookExistAsync(id);
        if (!isExist)
        {
            ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));

            return;
        }

        if (ModelState.IsValid)
        {
            await BookService.UpdateBookAsync(Mapper.Map<BookViewModel, Book>(bookViewModel));
        }
    }

    public async void BookForm_InsertItem()
    {
        var bookViewModel = new BookViewModel();
        TryUpdateModel(bookViewModel);
        if (ModelState.IsValid)
        {
            await BookService.AddBookAsync(Mapper.Map<BookViewModel, Book>(bookViewModel));
            Response.Redirect("~/Books/");
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Books/");
    }
}
