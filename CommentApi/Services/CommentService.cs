using System.Collections.Generic;
using System.Linq;
using CommentApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CommentApi.Services
{
    public class CommentService
    {
        private readonly IMongoCollection<CommentItem> _comments;

        public CommentService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("CommentstoreDb"));
            var database = client.GetDatabase("CommentstoreDb");
            _comments = database.GetCollection<CommentItem>("Comments");
        }

        public List<CommentItem> Get()
        {
            return _comments.Find(comment => true).ToList();
        }

        public CommentItem Get(string id)
        {
            return _comments.Find<CommentItem>(comment => comment.Id == id).FirstOrDefault();
        }

        public CommentItem Create(CommentItem comment)
        {
            _comments.InsertOne(comment);
            return comment;
        }

        public void Update(string id, CommentItem commentIn)
        {
            _comments.ReplaceOne(comment => comment.Id == id, commentIn);
        }

        public void Remove(CommentItem commentIn)
        {
            _comments.DeleteOne(comment => comment.Id == commentIn.Id);
        }

        public void Remove(string id)
        {
            _comments.DeleteOne(comment => comment.Id == id);
        }

    }
}
