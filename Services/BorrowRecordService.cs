using AutoMapper;
using LibApi.Entities;
using LibApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace LibApi.Services;

public interface IBorrowRecordService
{
    int Create(CreateBorrowRecordDto dto);
}

public class BorrowRecordService(LibDbContext context, IMapper mapper) : IBorrowRecordService
{
    public int Create(CreateBorrowRecordDto dto)
    {
        const string sql = "SELECT \"CreateBorrowRecord\"(@p1, @p2, @p3, @p4)";
        object[] parameters =
        [
            new NpgsqlParameter("p1", dto.MemberId),
            new NpgsqlParameter("p2", dto.BookId),
            new NpgsqlParameter("p3", dto.BorrowDate),
            new NpgsqlParameter("p4", dto.DueDate)
        ];

        return context.Database
            .SqlQueryRaw<int>(sql, parameters)
            .AsEnumerable()
            .FirstOrDefault();
    }
}