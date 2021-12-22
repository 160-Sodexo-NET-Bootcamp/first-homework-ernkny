using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErenKinay_Odev1_WebApi.Controllers
{
    // Book Properties
    public class Book
    {
        public int Id { get; set; }
        public int KitapSeriNo { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public int SayfaSayisi { get; set; }
        public string  YayinEvi { get; set; }

    }


    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        List<Book> Books = new List<Book>();
        public BookController()
        {
            //List of books. There are 6 object inside of list
           List<Book> _book = new List<Book>() { 
       
            new Book { Id=1,KitapAdi="Zengin Baba Fakir Baba",KitapSeriNo=123324,SayfaSayisi=251,YayinEvi="Yakamoz",Yazar="Robert T."},
            new Book { Id=2,KitapAdi="Karamazov Kardeşler",KitapSeriNo=123424,SayfaSayisi=1250,YayinEvi="Pegasus",Yazar="Dostoyevski"},
            new Book { Id=3,KitapAdi="Simyacı",KitapSeriNo=123327,SayfaSayisi=251,YayinEvi="İnkilap",Yazar="Paulo Coelho"},
            new Book { Id=4,KitapAdi="Hayvan Çiftliği",KitapSeriNo=523324,SayfaSayisi=130,YayinEvi="Pegasus",Yazar="George Orwell"},
            new Book { Id=5,KitapAdi="Şeker Portakalı",KitapSeriNo=423324,SayfaSayisi=180,YayinEvi="Yakamoz",Yazar="José Mauro De Vasconcelos"},
            new Book { Id=6,KitapAdi="Küçük Prens",KitapSeriNo=193324,SayfaSayisi=101,YayinEvi="İş Bankası",Yazar="Antoine de Saint-Exupéry"}

             };
            Books = _book;
        }
       


        // When that action call, result will be books list
        [HttpPost]
        public IActionResult GetAll()
        {
            return Ok(Books.ToList());
        }
        
        // When that action call with id, result will pair with id and it will show
        [HttpGet("{id}")]
        public IActionResult  GetFromRoute([FromRoute]int id)
        {

            var result = Books.SingleOrDefault(x => x.Id == id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        // When that action call with id, result will pair with id and it will show
        [HttpGet]
        public IActionResult GetFromQuery([FromQuery] int id)
        {
            var result = Books.SingleOrDefault(x => x.Id == id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        // When that action call, 
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {

            Books.Add(book);
            return Ok(Books.ToList());
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody]Book book)
        {
            var result = Books.Where(x => x.Id == id).FirstOrDefault();
            if (result!=null)
            {
                result.KitapAdi = book.KitapAdi;
                result.KitapSeriNo = book.KitapSeriNo;
                result.SayfaSayisi = book.SayfaSayisi;
                result.YayinEvi = book.YayinEvi;
                result.Yazar = book.Yazar;
                return Ok(Books.ToList());
            }
            return NotFound();
        }

        [HttpDelete]

        public void Delete(int id)
        {
            var result = Books.Where(x => x.Id == id).FirstOrDefault();
            Books.Remove(result);

        }
    }
}
