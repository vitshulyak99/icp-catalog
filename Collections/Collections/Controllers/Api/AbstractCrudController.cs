using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers.Api
{
    public abstract class AbstractCrudController<T> : ApiController
    {
        protected const int DefaultPageSetSize = 10; 

        [HttpGet]
        public IActionResult Get() =>Get (1) ;
        
        [HttpGet("{page:int}")]
        public IActionResult Get(int page)=>Get(page,DefaultPageSetSize);
        
        [HttpGet("{page:int}/{count:int}")]
        public abstract IActionResult Get(int page,int count);

        [HttpPost]
        public abstract IActionResult Create([FromBody] T model);

        [HttpPut]
        public abstract IActionResult Update([FromBody] T model);

        [HttpDelete("{id}")]
        public abstract IActionResult Delete(string id);
    }
}