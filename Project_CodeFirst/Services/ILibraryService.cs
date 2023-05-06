namespace Project_CodeFirst.Services
{
    public interface ILibraryService
    {
        List<AkhundovLibrary> GetAkhundovLibraryList();

        AkhundovLibrary GetBookDetailsById(int BookId);

        ResponseModel PostAkhundovLibrary(AkhundovLibrary NewBook);

        ResponseModel PutBookDetailsById(AkhundovLibrary akhundovLibrary, int PutBookId);

        ResponseModel DeleteBookDetailsById(int DeletedBookId);


    }
}
