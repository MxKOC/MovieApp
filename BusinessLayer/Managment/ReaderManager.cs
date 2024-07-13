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
    public class ReaderManager : IReaderServices
{
    private readonly IReaderDal _readerDal;

    public ReaderManager(IReaderDal readerDal)
    {
        _readerDal = readerDal;
    }

    public async Task<string> CreateReaderAsync(Reader reader)
    {
        await _readerDal.AddAsync(reader);
        return reader.Id; // Assuming Id is set after addition
    }

    public async Task<bool> DeleteReaderAsync(string readerId)
    {
        var reader = await _readerDal.GetByIdAsync(readerId);
        if (reader != null)
        {
            await _readerDal.DeleteAsync(readerId);
            return true;
        }
        return false;
    }

    public async Task<List<Reader>> GetAllReadersAsync()
    {
        return (await _readerDal.GetAllAsync()).ToList();
    }

    public Task<Reader> GetReaderByIdAsync(string readerId)
    {
        return _readerDal.GetByIdAsync(readerId);
    }

    public async Task<bool> UpdateReaderAsync(string readerId, Reader reader)
    {
        var existingReader = await _readerDal.GetByIdAsync(readerId);
        if (existingReader == null)
            return false;

        existingReader.UserName = reader.UserName;
        existingReader.Email = reader.Email;


        await _readerDal.UpdateAsync(existingReader);
        return true;
    }
}

}