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
    public class WriterManager : IWriterServices
{
    private readonly IWriterDal _writerDal;

    public WriterManager(IWriterDal writerDal)
    {
        _writerDal = writerDal;
    }

    public async Task<string> CreateWriterAsync(Writer writer)
    {
        await _writerDal.AddAsync(writer);
        return writer.Id; // Assuming Id is set after addition
    }

    public async Task<bool> DeleteWriterAsync(string writerId)
    {
        var writer = await _writerDal.GetByIdAsync(writerId);
        if (writer != null)
        {
            await _writerDal.DeleteAsync(writerId);
            return true;
        }
        return false;
    }

    public async Task<List<Writer>> GetAllWritersAsync()
    {
        return (await _writerDal.GetAllAsync()).ToList();
    }

    public Task<Writer> GetWriterByIdAsync(string writerId)
    {
        return _writerDal.GetByIdAsync(writerId);
    }

    public async Task<bool> UpdateWriterAsync(string writerId, Writer writer)
    {
        var existingWriter = await _writerDal.GetByIdAsync(writerId);
        if (existingWriter == null)
            return false;

        existingWriter.UserName = writer.UserName;
        existingWriter.Email = writer.Email;


        await _writerDal.UpdateAsync(existingWriter);
        return true;
    }
}

}