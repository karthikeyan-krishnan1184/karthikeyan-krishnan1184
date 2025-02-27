﻿using System.Collections.Generic;
using System.IO;

namespace ProjectPhase1.Repositories
{
    public class PipeDelimitedFileTeachersRepository : ITeachersRepository
    {
        private string _filename;

        public PipeDelimitedFileTeachersRepository(string filename)
        {
            _filename = filename;
        }

        public IEnumerable<Teacher> Load()
        {
            var teachersAsPipeDelimited = File.ReadAllLines(_filename);
            var teachers = new List<Teacher>();
            foreach (var teacherAsPipeDelimited in teachersAsPipeDelimited)
            {
                var splits = teacherAsPipeDelimited.Split('|');
                var teacher = new Teacher(int.Parse(splits[0]), splits[1], splits[2]); 
                teachers.Add(teacher);
            }
            return teachers;
        }

        public void Save(IEnumerable<Teacher> teachers)
        {
            var teachersAsPipeDelimited = new List<string>();
            foreach (var teacher in teachers)
            {
                var teacherAsPipeDelimited = $"{teacher.ID}|{teacher.FirstName}|{teacher.LastName}"; 
                teachersAsPipeDelimited.Add(teacherAsPipeDelimited);
            }
            File.WriteAllLines(_filename, teachersAsPipeDelimited);
        }
    }
}
