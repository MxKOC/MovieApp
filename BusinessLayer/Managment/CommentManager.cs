using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;

namespace BusinessLayer.Manager
{
    public class CommentManager : ICommentServices
{
    private readonly ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }
    public Task<Comment> GetCommentByIdAsync(string commentId)
    {
        return _commentDal.GetByIdAsync(commentId);
    }
    public async Task<string> CreateCommentAsync(Comment comment)
    {
        await _commentDal.AddAsync(comment);
        return comment.CommentId; // Assuming Id is set after addition
    }

    public async Task<bool> DeleteCommentAsync(string commentId)
    {
        var comment = await _commentDal.GetByIdAsync(commentId);
        if (comment != null)
        {
            await _commentDal.DeleteAsync(commentId);
            return true;
        }
        return false;
    }


    public Task<IEnumerable<Comment>> GetAllCommentByReaderIdAsync(string ReaderId)
    {
        return _commentDal.GetByReaderIdAsync(ReaderId);
    }

    public async Task<Comment> UpdateCommentAsync(string commentId, Comment comment)
    {
        var existingComment = await _commentDal.GetByIdAsync(commentId);
        if (existingComment == null)
            return null;

        existingComment.Content = comment.Content;


        await _commentDal.UpdateAsync(existingComment);
        return existingComment;
    }
}

}