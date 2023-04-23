--Create Course Table
Create Table tblCourse
(
	Id INT Primary key NOT NULL,
	Name VARCHAR(50)
);
GO
--Insert data into the course table
INSERT INTO tblCourse values(101,'Asp.NET')
INSERT INTO tblCourse values(102,'php')
INSERT INTO tblCourse values(103,'C-SHARP')
INSERT INTO tblCourse values(104,'Java')
GO
-- Create student Table

CREATE TABLE tblStudent
(
	StudentId INT identity(1,1) primary key NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	City VARCHAR(15),
	CourseId INT,
	PictureURL VARCHAR(1000)
);
	

--Insert data into Student Table

	INSERT INTO tblStudent VALUES('PRATIKSHYA','F','BARIPADA',101, '')
	INSERT INTO tblStudent VALUES('MERRY','F','DHENKANAL',102, '')
	INSERT INTO tblStudent VALUES('AWWKASH','M','BARIPADA',101, '')
	INSERT INTO tblStudent VALUES('RITIKA','F','BARIPADA',103, '')
	INSERT INTO tblStudent VALUES('CHINMOY','M','CHANDIGARH',104, '')
	INSERT INTO tblStudent VALUES('PRIYANKA','F','PURI',104, '')
	INSERT INTO tblStudent VALUES('NYONIKA','F','PUNE',101, '')
	INSERT INTO tblStudent VALUES('VENKAT','M','BANGALURU',103, '')

	SELECT * FROM tblStudent
	SELECT * FROM tblCourse

-- Add foreign key into Student Table References to the Course Table

ALTER TABLE Student
ADD FOREIGN KEY(CourseId)
REFERENCES Course(Id)
GO

SELECT * FROM tblCourse
SELECT * FROM tblStudent


