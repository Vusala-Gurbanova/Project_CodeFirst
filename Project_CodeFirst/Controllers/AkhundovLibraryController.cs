using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_CodeFirst.Services;

namespace Project_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AkhundovLibraryController : ControllerBase
    {
        ILibraryService _libraryService;
        public AkhundovLibraryController(ILibraryService service)
        {
            _libraryService = service;
        }

        [HttpGet]
        [Route("[action]")]

        public IActionResult GetAkhundovLibraryList()
        {
            try
            {
                var books = _libraryService.GetAkhundovLibraryList();
                if (books == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(books);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]

        public IActionResult GetBookDetailsById(int BookId)
        {
            try
            {
                var requiredBook = _libraryService.GetBookDetailsById(BookId);
                if (requiredBook == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(BookId);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult PostAkhundovLibrary(AkhundovLibrary NewBook)
        {
            try
            {
                var addbook = _libraryService.PostAkhundovLibrary(NewBook);
                return Ok(addbook);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("[action]/id")]
        public IActionResult GetBookDetailsById(AkhundovLibrary akhundovLibrary, int PutBookId)
        {
            try
            {
                var updatelist = _libraryService.GetBookDetailsById(PutBookId);
                return Ok(updatelist);
            }
            catch (Exception)

            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("[action]/id")]

        public IActionResult DeleteBookDetailsById(int DeletedBookId)
        {
            try
            {
                var deletedBook = _libraryService.DeleteBookDetailsById(DeletedBookId);
                return Ok(deletedBook);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }


    } 
}
