using System.Collections.Generic;
using CommentApi.Models;
using CommentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comment             **READ**
        [HttpGet]
        public ActionResult<List<CommentItem>> GetCommentItem()
        {
            return _commentService.Get();
        }

        // GET: api/Comment/5           **READ**
        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public ActionResult<CommentItem> GetCommentItem(string id)
        {
            var commentItem = _commentService.Get(id);

            if (commentItem == null)
            {
                return NotFound();
            }

            return commentItem;

        }

        // POST: api/Comment            **CREATE**
        [HttpPost]
        public ActionResult<CommentItem> Create(CommentItem comment)
        {
            _commentService.Create(comment);
            
            return CreatedAtRoute("GetComment", new { id = comment.Id.ToString() }, comment);
        }

        // PUT: api/Comment/5           **UPDATE**
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, CommentItem commentIn)
        {
            var comment = _commentService.Get(id);

            if (comment == null)  
            {
                return NotFound();
            }

            _commentService.Update(id, commentIn);

            return NoContent();

        }

        // DELETE: api/Comment/5        **DELETE**
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteCommentItem(string id)
        {
            var commentItem = _commentService.Get(id);

            if (commentItem == null)
            {
                return NotFound();
            }

            _commentService.Remove(commentItem.Id);

            return NoContent();
        }


    }


}