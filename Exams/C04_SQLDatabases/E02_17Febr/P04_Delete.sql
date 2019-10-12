DELETE
  FROM StudentsTeachers
 WHERE StudentsTeachers.TeacherId IN (SELECT t.Id
                                                  FROM Teachers AS t
												 WHERE t.Phone LIKE '%72%');

DELETE
  FROM Teachers
 WHERE Teachers.Phone LIKE '%72%';