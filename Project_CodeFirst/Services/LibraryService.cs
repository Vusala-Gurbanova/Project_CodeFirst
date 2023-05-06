namespace Project_CodeFirst.Services
{
    public class LibraryService : ILibraryService
    {
        public BookContext _context;

        public LibraryService (BookContext context)
        {
            _context = context;
        }

        public List<AkhundovLibrary> GetAkhundovLibraryList()
        {
            List<AkhundovLibrary> bookslist;
            try
            {
                bookslist = _context.Set<AkhundovLibrary>().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return bookslist;
        }

       
        public AkhundovLibrary GetBookDetailsById(int BookId)
        {
            AkhundovLibrary requiredBook;
            try
            {
                requiredBook = _context.Find<AkhundovLibrary>(BookId);
            }
            catch (Exception)
            {
                throw;
            }
            return requiredBook;
        }

                
  

        ResponseModel ILibraryService.DeleteBookDetailsById(int BookId)
        {
            ResponseModel model = new ResponseModel();

            try
            {
                AkhundovLibrary deletebook = GetBookDetailsById(BookId);
                if (deletebook != null)
                {
                    _context.Remove<AkhundovLibrary>(deletebook);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Book Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Book not found, please recheck";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error" + ex.Message;
            }
            return model;
        }

        ResponseModel ILibraryService.PostAkhundovLibrary(AkhundovLibrary NewBook)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                _context.Add<AkhundovLibrary>(NewBook);
                _context.SaveChanges();
                response.IsSuccess = true;
                response.Message = "New book added successfully";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error. Please recheck entered information" + ex.Message;
            }
            finally
            {
                _context.Dispose();
            }
            return response;
        }

        ResponseModel ILibraryService.PutBookDetailsById(AkhundovLibrary akhundovLibrary, int PutBookId)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var library = _context.Find<AkhundovLibrary>(PutBookId);

                if (library != null)
                {
                    library.Book = akhundovLibrary.Book;
                    library.BookAuthor = akhundovLibrary.BookAuthor;
                    library.ProductionYear = akhundovLibrary.ProductionYear;
                    library.Cost = akhundovLibrary.Cost;
                    _context.Update<AkhundovLibrary>(library);
                    response.Message = "Information Updated Successfully";
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Book Not Found";
                }


            }
            catch (Exception ex)

            {
                response.IsSuccess = false;
                response.Message = "Error" + ex.Message;

            }
            finally
            {
                _context.Dispose();
            }
            return response;
        }
    }

}
