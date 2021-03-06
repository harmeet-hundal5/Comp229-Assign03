CREATE PROCEDURE [dbo].[Student_CRUD]
       @Action VARCHAR(10)
      ,@StudentID INT = NULL
      ,@FirstMidName VARCHAR(100) = NULL
      ,@LastName VARCHAR(100) = NULL
	   ,@CourseID VARCHAR(100) = NULL
	    ,@EnrollmentID VARCHAR(100) = NULL
AS
BEGIN
      SET NOCOUNT ON;
 
      --SELECT
    IF @Action = 'SELECT'
      BEGIN
            SELECT StudentID, FirstMidName, LastName
            FROM Students
      END
 
      --INSERT
    IF @Action = 'INSERT'
      BEGIN
            INSERT INTO Students(FirstMidName, LastName)
            VALUES (@FirstMidName, @LastName)
      END
 
      --UPDATE
    IF @Action = 'UPDATE'
      BEGIN
            UPDATE Students
            SET FirstMidName = @FirstMidName, LastName = @LastName
            WHERE StudentID = @StudentID

          UPDATE Enrollments
            SET CourseID = @CourseID 
            WHERE StudentID = @StudentID and EnrollmentID = @EnrollmentID 
			
      END
 
      --DELETE
    IF @Action = 'DELETE'
      BEGIN
            DELETE FROM Students
            WHERE StudentID = @StudentID
      END
END