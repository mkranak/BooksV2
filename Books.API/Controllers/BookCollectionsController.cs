using AutoMapper;
using Books.API.Filters;
using Books.API.ModelBinders;
using Books.API.Models;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/bookcollections")]
    [ApiController]
    [BooksResultFilter]
    public class BookCollectionsController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookCollectionsController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository ?? 
                throw new ArgumentNullException(nameof(booksRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(booksRepository));
        }

        // api/bookcollections/{id1,id2,...)
        [HttpGet("({bookIds})", Name = "GetBookCollection")]
        public async Task<IActionResult> GetBookCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> bookIds)
        {
            var bookEntities = await _booksRepository.GetBooksAsync(bookIds);

            if (bookIds.Count() != bookEntities.Count())
                return NotFound();

            return Ok(bookEntities);
        }

        /// <summary>
        /// Creates a book collection.
        /// </summary>
        /// <param name="bookCollection">The book collection.</param>
        /// <returns>The created book collection.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateBookCollection(
            IEnumerable<BookForCreation> bookCollection)
        {
            var bookEntities = _mapper.Map<IEnumerable<Entities.Book>>(bookCollection);

            foreach (var bookEntity in bookEntities)
            {
                _booksRepository.AddBook(bookEntity);
            }

            await _booksRepository.SaveChangesAsync();

            var booksToReturn = await _booksRepository.GetBooksAsync(
                bookEntities.Select(b => b.Id).ToList());

            var bookIds = string.Join(",", booksToReturn.Select(b => b.Id));

            return CreatedAtRoute("GetBookCollection",
                new { bookIds },
                booksToReturn);
        }
    }
}
