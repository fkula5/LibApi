using Microsoft.EntityFrameworkCore.Migrations;
using LibApi.Enums;

namespace LibApi.Migrations
{
    public partial class CreateBorrowRecordProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS \"CreateBorrowRecord\" CASCADE;");
            
            var createBorrowRecord = @"
                CREATE OR REPLACE FUNCTION ""CreateBorrowRecord""(
                    p_member_id INT,
                    p_book_id INT,
                    p_borrow_date TIMESTAMP,
                    p_due_date TIMESTAMP
                )
                RETURNS INT
                LANGUAGE plpgsql
                AS $$
                DECLARE
                    v_available_copies INT;
                    v_new_record_id INT;
                BEGIN
                    -- Check if book has any active borrows
                    SELECT COUNT(*)
                    INTO v_available_copies
                    FROM ""Books"" b
                    LEFT JOIN ""BorrowRecords"" br ON br.""BookId"" = b.""Id"" 
                        AND br.""Status""::text = 'Borrowed'
                    WHERE b.""Id"" = p_book_id
                    GROUP BY b.""Id"", b.""Copies""
                    HAVING b.""Copies"" > COUNT(br.""Id"");

                    -- If no copies available, throw an error
                    IF v_available_copies IS NULL THEN
                        RAISE EXCEPTION 'No available copies of this book';
                    END IF;

                    -- Create the borrow record
                    INSERT INTO ""BorrowRecords"" (
                        ""MemberId"",
                        ""BookId"",
                        ""BorrowDate"",
                        ""DueDate"",
                        ""ReturnDate"",
                        ""Status""
                    )
                    VALUES (
                        p_member_id,
                        p_book_id,
                        p_borrow_date,
                        p_due_date,
                        NULL,
                        0  -- 0 represents BorrowStatus.Borrowed
                    )
                    RETURNING ""Id"" INTO v_new_record_id;

                    RETURN v_new_record_id;
                END;
                $$;";

            migrationBuilder.Sql(createBorrowRecord);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS ""CreateBorrowRecord"" CASCADE;");
        }
    }
}